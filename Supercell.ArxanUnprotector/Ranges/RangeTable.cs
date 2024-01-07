namespace Supercell.ArxanUnprotector.Ranges;

using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Supercell.ArxanUnprotector;

public class RangeTable
{
    public const int EntrySize = 12;
    
    public int StartAddress { get; }
    public int EndAddress { get; }
    
    public Library Library { get; }

    // Lazy loaded
    private List<RangeTableEntry> _entries;
    private RangeTableChecksum? _entriesChecksum;
    private List<RangeTableChecksumLocation> _entriesChecksumLocations;

    public RangeTable(int startAddress, int endAddress, Library library)
    {
        StartAddress = startAddress;
        EndAddress = endAddress;
        Library = library;

        _entries = null;
        _entriesChecksum = null;
        _entriesChecksumLocations = null;
    }
    
    public void InvalidateCache()
    {
        _entries = null;
        _entriesChecksum = null;
        _entriesChecksumLocations = null;
    }

    public Span<byte> Content => Library.Take(StartAddress, EndAddress - StartAddress);

    public List<RangeTableEntry> Entries
    {
        get
        {
            _entries ??= GetEntries();
            return _entries;
        }
    }

    public RangeTableChecksum Checksum
    {
        get
        {
            _entriesChecksum ??= CalculateChecksum();
            return _entriesChecksum.Value;
        }
    }

    public List<RangeTableChecksumLocation> ChecksumLocations
    {
        get
        {
            _entriesChecksumLocations ??= FindChecksumLocation();
            return _entriesChecksumLocations;
        }
    }

    private List<RangeTableEntry> GetEntries()
    {
        List<RangeTableEntry> entries = new List<RangeTableEntry>();
        Span<byte> data = Content;
            
        do
        {
            ParseRange(data, StartAddress, out int address, out int length);
                
            if (length == 0)
                break;
                
            entries.Add(new RangeTableEntry(address, length, Library));
            data = data.Slice(EntrySize);
        } while (true);
            
        return entries;
    }

    private RangeTableChecksum CalculateChecksum()
    {
        RangeTableChecksum checksum = new RangeTableChecksum();
        List<RangeTableEntry> entries = Entries;

        for (int i = 0; i < entries.Count; i++)
        {
            entries[i].CalculateChecksum(ref checksum);
        }

        return checksum;
    }

    private List<RangeTableChecksumLocation> FindChecksumLocation()
    {
        RangeTableChecksum checksum = Checksum;

        List<RangeTableChecksumLocation> locations = new List<RangeTableChecksumLocation>();

        List<int> key1Addresses = Library.GetValueAddresses(checksum.Key1);
        List<int> key2Addresses = Library.GetValueAddresses(checksum.Key2);
        List<int> key3Addresses = Library.GetValueAddresses(checksum.Key3);

        if (key1Addresses.Count == key2Addresses.Count && key2Addresses.Count == key3Addresses.Count)
        {
            for (int i = 0; i < key1Addresses.Count; i++)
            {
                locations.Add(new RangeTableChecksumLocation(key1Addresses[i], key2Addresses[i], key3Addresses[i]));
            }   
        }

        return locations;
    }

    
    public override string ToString()
    {
        return $"RangeTable({StartAddress:x8}-{EndAddress:x8})";
    }

    public static void ParseRange(ReadOnlySpan<byte> data, int tableAddress, out int address, out int size)
    {
        if (data.Length < EntrySize + 8)
            throw new Exception("Invalid range table entry");
        
        ref int addressRef = ref Unsafe.As<byte, int>(ref MemoryMarshal.GetReference(data));
        
        int v1 = Unsafe.Add(ref addressRef, 0);
        int v2 = Unsafe.Add(ref addressRef, 1);
        int v3 = Unsafe.Add(ref addressRef, 2);
        int v4 = Unsafe.Add(ref addressRef, 3);
        int v5 = Unsafe.Add(ref addressRef, 4);

        address = v4 - v3 - v2 - v1 + tableAddress;
        size = v2 + v4 - v5;
    }
}