namespace Supercell.ArxanUnprotector;

using Supercell.ArxanUnprotector.Ranges;
using Supercell.ArxanUnprotector.Ranges.Providers;
using Supercell.ArxanUnprotector.Strings;
using Supercell.ArxanUnprotector.Strings.Providers;
using Supercell.ArxanUnprotector.Utils;

public abstract class Library
{
    private static readonly byte[] _wutf8Table =
    {
        0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0,
        0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0,
        0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0,
        0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0,
        0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0,
        0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0,
        0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0,
        0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0,
        1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1,
        9,9, 9,9, 9,9, 9,9, 9,9, 9,9, 9,9, 9,9,
        7,7, 7,7, 7,7, 7,7, 7,7, 7,7, 7,7, 7,7,
        7,7, 7,7, 7,7, 7,7, 7,7, 7,7, 7,7, 7,7,
        8,8, 2,2, 2,2, 2,2, 2,2, 2,2, 2,2, 2,2,
        2,2, 2,2, 2,2, 2,2, 2,2, 2,2, 2,2, 2,2,
        10,3, 3,3, 3,3, 3,3, 3,3, 3,3, 3,4, 3,3,
        11,6, 6,6, 5,8, 8,8, 8,8, 8,8, 8,8, 8,8,

        0,12, 24,36, 60,96, 84,12, 12,12, 48,72,
        12,12, 12,12, 12,12, 12,12, 12,12, 12,12,
        12, 0, 12,12, 12,12, 12, 0, 12, 0, 12,12,
        12,24, 12,12, 12,12, 12,24, 12,24, 12,12,
        12,12, 12,12, 12,12, 12,24, 12,12, 12,12,
        12,24, 12,12, 12,12, 12,12, 12,24, 12,12,
        12,12, 12,12, 12,12, 12,36, 12,36, 12,12,
        12,36, 12,12, 12,12, 12,36, 12,36, 12,12,
        12,36, 12,12, 12,12, 12,12, 12,12, 12,12,
    };
    
    protected byte[] _fileData;
    protected byte[] _memoryData;
    protected int _memoryStartSlide;

    private readonly Dictionary<uint, List<int>> _valueAddressesIndex;
    
    private readonly IRangeTableProvider _rangeTableProvider;
    private readonly IStringEncryptionService _stringEncryptionService;
    
    // Lazy loaded
    private IReadOnlyList<RangeTable> _rangeTables;
    private RangeTable _encryptedStringRangeTable;
    private EncryptedStringKey? _encryptedStringKey;
    protected DataSectionRange[] _dataSectionRanges;

    public int FileSize => _fileData.Length;
    public int MemorySize => _memoryData.Length;

    protected Library(IRangeTableProvider rangeTableProvider, IStringEncryptionService stringEncryptionService)
    {
        _valueAddressesIndex = new Dictionary<uint, List<int>>();
        
        _rangeTableProvider = rangeTableProvider;
        _stringEncryptionService = stringEncryptionService;
        
        _rangeTableProvider.Library = this;
        _stringEncryptionService.Library = this;
    }

    public void InvalidateCache()
    {
        _rangeTables = null;
        _encryptedStringRangeTable = null;
        _encryptedStringKey = null;
    }

    public IReadOnlyList<RangeTable> RangeTables
    {
        get
        {
            _rangeTables ??= _rangeTableProvider.FindTables();
            return _rangeTables;
        }
    }

    public RangeTable EncryptedStringRangeTable
    {
        get
        {
            _encryptedStringRangeTable ??= _stringEncryptionService.FindStringTable();
            return _encryptedStringRangeTable;
        }
    }

    public EncryptedStringKey EncryptedStringKey
    {
        get
        {
            _encryptedStringKey ??= _stringEncryptionService.FindKey();
            return _encryptedStringKey.Value;
        }
    }

    public bool IsStringsEncrypted
    {
        get
        {
            ReadOnlySpan<byte> dataSection = GetSection(SectionType.Data, out _);
            return !dataSection.Contains(_wutf8Table.AsSpan());
        }
    }

    public List<int> GetValueAddresses(uint value)
    {
        if (_valueAddressesIndex.Count == 0)
            BuildValueAddressesIndex();
        
        if (!_valueAddressesIndex.TryGetValue(value, out List<int> values))
        {
            values = new List<int>();
            _valueAddressesIndex.Add(value, values);
        }

        return values;
    }
    
    private void BuildValueAddressesIndex()
    {
        Span<byte> dataSection = GetSection(SectionType.Data, out int dataAddress);
        
        for (int i = 0, j = dataAddress; i < (dataSection.Length & ~4u); i += 4, j += 4)
        {
            uint value = BitConverter.ToUInt32(_memoryData, j);

            if (!_valueAddressesIndex.TryGetValue(value, out List<int> values))
            {
                values = new List<int>(8);
                _valueAddressesIndex.Add(value, values);
            }

            values.Add(j);
        }
    }
    
    public void DecryptStrings()
    {
        if (!IsStringsEncrypted)
            throw new Exception("Strings are already decrypted.");
        
        EncryptStringsImpl();
    }

    public void EncryptStrings()
    {
        if (IsStringsEncrypted)
            throw new Exception("Strings are already encrypted.");
        
        EncryptStringsImpl();
    }
    
    public void ToggleStringEncryption()
    {
        if (IsStringsEncrypted)
            DecryptStrings();
        else
            EncryptStrings();
    }

    private void EncryptStringsImpl()
    {
        foreach (RangeTableEntry entry in EncryptedStringRangeTable.Entries)
        {
            _stringEncryptionService.Compute(Take(entry.Address, entry.Length));
        }
    }
    
    public abstract IEnumerable<int> InitFunctions { get; }
    public abstract IEnumerable<int> FiniFunctions { get; }
    
    public abstract int SectionCount { get; }
    
    public abstract Span<byte> GetSection(SectionType section, out int address);
    public abstract Span<byte> GetSectionAt(int index, out int address);
    
    public abstract Span<byte> Take(int address);
    public abstract Span<byte> Take(int address, int length);

    public abstract void Save(string filePath);
    
    public readonly struct DataSectionRange
    {
        public required int Start { get; init; }
        public required int End { get; init; }
        
        public bool Contains(int address)
        {
            return address >= Start && address < End;
        }
    }
}

public enum SectionType
{
    Data,
    Text
}