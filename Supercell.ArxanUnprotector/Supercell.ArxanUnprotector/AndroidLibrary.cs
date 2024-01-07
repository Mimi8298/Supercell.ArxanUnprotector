namespace Supercell.ArxanUnprotector;

using System.Diagnostics;
using Supercell.ArxanUnprotector.Ranges.Providers;
using Supercell.ArxanUnprotector.Strings.Providers;
using ELFSharp.ELF;
using ELFSharp.ELF.Sections;
using ELFSharp.ELF.Segments;

public class AndroidLibrary : Library
{
    private readonly IELF _elf;

    public AndroidLibrary(string path) : base(new GenericMemoryRangeTableProvider(), new ArmStringEncryptionService())
    {
        _elf = ELFReader.Load(path);
        _fileData = File.ReadAllBytes(path);

        _memoryData = new byte[_elf.Segments.Where(x => x.Type == SegmentType.Load).Cast<Segment<uint>>().Max(s => s.Address + s.Size)];

        foreach (ISection section in _elf.Sections)
        {
            if (section is Section<uint> bitSection && bitSection.Type != ELFSharp.ELF.Sections.SectionType.NoBits)
            {
                _fileData.AsSpan((int) bitSection.Offset, (int) bitSection.Size).CopyTo(_memoryData.AsSpan((int) bitSection.LoadAddress, (int) bitSection.Size));
            }
        }
        
        MakeRelocation();
        
        _elf.Dispose();
    }

    public override IEnumerable<int> InitFunctions
    {
        get
        {
            Span<byte> data = GetSectionByName(".init_array", out _);
            Debug.Assert(data.Length % 4 == 0);
            List<int> addresses = new List<int>(data.Length / 4);

            while (!data.IsEmpty)
            {
                addresses.Add(BitConverter.ToInt32(data));
                data = data.Slice(4);
            }
            
            return addresses;
        }
    }

    public override IEnumerable<int> FiniFunctions
    {
        get
        {
            Span<byte> data = GetSectionByName(".fini_array", out _);
            Debug.Assert(data.Length % 4 == 0);
            List<int> addresses = new List<int>(data.Length / 4);

            while (!data.IsEmpty)
            {
                addresses.Add(BitConverter.ToInt32(data));
                data = data.Slice(4);
            }
            
            return addresses;
        }
    }
    
    public override int SectionCount => _elf.Sections.Count;

    public override Span<byte> GetSection(SectionType type, out int address)
    {
        string name = type switch
        {
            SectionType.Data => ".data",
            SectionType.Text => ".text",
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
        };
        
        return GetSectionByName(name, out address);
    }

    public override Span<byte> GetSectionAt(int index, out int address)
    {
        Section<uint> section = (Section<uint>) _elf.GetSection(index);
        address = (int) section.LoadAddress;
        return _memoryData.AsSpan((int) section.LoadAddress, (int) section.Size);
    }

    private Span<byte> GetSectionByName(string name, out int address)
    {
        Section<uint> section = (Section<uint>) _elf.GetSection(name);
        address = (int) section.LoadAddress;
        return _memoryData.AsSpan((int) section.LoadAddress, (int) section.Size);
    }

    public override Span<byte> Take(int address)
    {
        if (address < 0 || address > _memoryData.Length)
            throw new ArgumentOutOfRangeException(nameof(address));

        return _memoryData.AsSpan(address);
    }

    public override Span<byte> Take(int address, int length)
    {
        if (address < 0 || address > _memoryData.Length)
            throw new ArgumentOutOfRangeException(nameof(address));

        return _memoryData.AsSpan(address, length);
    }

    public override void Save(string filePath)
    {
        foreach (ISection section in _elf.Sections)
        {
            if (section is Section<uint> {Name: ".data" or "LOAD"} bitSection)
            {
                Array.Copy(_memoryData, bitSection.LoadAddress, _fileData, bitSection.Offset, bitSection.Size);
            }
        }
        
        File.WriteAllBytes(filePath, _fileData);
    }

    private void MakeRelocation()
    {
        SymbolTable<uint> symbolTable = _elf.Sections.OfType<SymbolTable<uint>>().Single();

        foreach (Section<uint> section in _elf.Sections.Where(s => s.Type == ELFSharp.ELF.Sections.SectionType.Relocation).Cast<Section<uint>>())
        {
            byte[] data = section.GetContents();

            for (int i = 0; i < data.Length; i += 8)
            {
                uint offset = BitConverter.ToUInt32(data, i);
                uint info = BitConverter.ToUInt32(data, i + 4);
                
                uint symbolIndex = info >> 8;
                uint type = info & 0xFF;

                switch (type)
                {
                    case 2:
                    {
                        SymbolEntry<uint> symbol = symbolTable!.Entries.ElementAt((int) symbolIndex);
                    
                        _memoryData[offset] = (byte) (symbol.Value);
                        _memoryData[offset + 1] = (byte) (symbol.Value >> 8);
                        _memoryData[offset + 2] = (byte) (symbol.Value >> 16);
                        _memoryData[offset + 3] = (byte) (symbol.Value >> 24);
                        break;
                    }
                }
            }
        }
    }
}