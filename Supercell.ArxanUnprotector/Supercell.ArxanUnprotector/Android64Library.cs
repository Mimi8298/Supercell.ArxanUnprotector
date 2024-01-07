namespace Supercell.ArxanUnprotector;

using System.Diagnostics;
using Supercell.ArxanUnprotector.Ranges.Providers;
using Supercell.ArxanUnprotector.Strings.Providers;
using ELFSharp.ELF;
using ELFSharp.ELF.Sections;
using ELFSharp.ELF.Segments;

public class Android64Library : Library
{
    private readonly IELF _elf;

    public Android64Library(string path) : base(new GenericMemoryRangeTableProvider(), new Arm64StringEncryptionService())
    {
        _elf = ELFReader.Load(path);
        _fileData = File.ReadAllBytes(path);

        _memoryData = new byte[_elf.Segments.Where(x => x.Type == SegmentType.Load).Cast<Segment<ulong>>().Max(s => s.Address + s.Size)];

        foreach (ISection section in _elf.Sections)
        {
            if (section is Section<ulong> bitSection && bitSection.Type != ELFSharp.ELF.Sections.SectionType.NoBits)
            {
                _fileData.AsSpan((int) bitSection.Offset, (int) bitSection.Size).CopyTo(_memoryData.AsSpan((int) bitSection.LoadAddress, (int) bitSection.Size));
            }
        }
        
        MakeRelocation();
        MakeRelocationAddends();
        
        _elf.Dispose();
    }

    public override IEnumerable<int> InitFunctions
    {
        get
        {
            Span<byte> data = GetSectionByName(".init_array", out _);
            Debug.Assert(data.Length % 8 == 0);
            List<int> addresses = new List<int>(data.Length / 8);

            while (!data.IsEmpty)
            {
                addresses.Add((int) BitConverter.ToInt64(data));
                data = data.Slice(8);
            }
            
            return addresses;
        }
    }

    public override IEnumerable<int> FiniFunctions
    {
        get
        {
            Span<byte> data = GetSectionByName(".fini_array", out _);
            Debug.Assert(data.Length % 8 == 0);
            List<int> addresses = new List<int>(data.Length / 8);

            while (!data.IsEmpty)
            {
                addresses.Add((int) BitConverter.ToInt64(data));
                data = data.Slice(8);
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
        Section<ulong> section = (Section<ulong>) _elf.GetSection(index);
        address = (int) section.LoadAddress;
        return _memoryData.AsSpan((int) section.LoadAddress, (int) section.Size);
    }

    private Span<byte> GetSectionByName(string name, out int address)
    {
        Section<ulong> section = (Section<ulong>) _elf.GetSection(name);
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
            if (section is Section<ulong> {Name: ".data" or "LOAD"} bitSection)
            {
                Array.Copy(_memoryData, (int) bitSection.LoadAddress, _fileData, (int) bitSection.Offset, (int) bitSection.Size);
            }
        }
        
        File.WriteAllBytes(filePath, _fileData);
    }

    private void MakeRelocation()
    {
        SymbolTable<ulong> symbolTable = _elf.Sections.OfType<SymbolTable<ulong>>().Single();

        foreach (Section<ulong> section in _elf.Sections.Where(s => s.Type == ELFSharp.ELF.Sections.SectionType.Relocation).Cast<Section<ulong>>())
        {
            byte[] data = section.GetContents();

            for (int i = 0; i < data.Length; i += 16)
            {
                ulong offset = BitConverter.ToUInt64(data, i);
                ulong info = BitConverter.ToUInt64(data, i + 8);
                
                ulong symbolIndex = info >> 8;
                ulong type = info & 0xFF;

                if (type == 2)
                {
                    SymbolEntry<ulong> symbol = symbolTable!.Entries.ElementAt((int) symbolIndex);
                    
                    _memoryData[offset] = (byte) (symbol.Value);
                    _memoryData[offset + 1] = (byte) (symbol.Value >> 8);
                    _memoryData[offset + 2] = (byte) (symbol.Value >> 16);
                    _memoryData[offset + 3] = (byte) (symbol.Value >> 24);
                    _memoryData[offset + 4] = (byte) (symbol.Value >> 32);
                    _memoryData[offset + 5] = (byte) (symbol.Value >> 40);
                    _memoryData[offset + 6] = (byte) (symbol.Value >> 48);
                    _memoryData[offset + 7] = (byte) (symbol.Value >> 56);
                }
            }
        }
    }

    private void MakeRelocationAddends()
    {
        SymbolTable<ulong> symbolTable = _elf.Sections.OfType<SymbolTable<ulong>>().Single();

        foreach (Section<ulong> section in _elf.Sections.Where(s => s.Type == ELFSharp.ELF.Sections.SectionType.RelocationAddends).Cast<Section<ulong>>())
        {
            byte[] data = section.GetContents();

            for (int i = 0; i < data.Length; i += 24)
            {
                ulong offset = BitConverter.ToUInt64(data, i);
                ulong info = BitConverter.ToUInt64(data, i + 8);
                ulong addend = BitConverter.ToUInt64(data, i + 16);
                
                uint symbolIndex = (uint) (info >> 32);
                uint type = (uint) (info & 0xFFFFFFFF);

                switch (type)
                {
                    case 1027: // R_AARCH64_RELATIVE
                        _memoryData[offset] = (byte) (addend);
                        _memoryData[offset + 1] = (byte) (addend >> 8);
                        _memoryData[offset + 2] = (byte) (addend >> 16);
                        _memoryData[offset + 3] = (byte) (addend >> 24);
                        _memoryData[offset + 4] = (byte) (addend >> 32);
                        _memoryData[offset + 5] = (byte) (addend >> 40);
                        _memoryData[offset + 6] = (byte) (addend >> 48);
                        _memoryData[offset + 7] = (byte) (addend >> 56);
                        break;
                    case 257: // R_AARCH64_ABS64
                        SymbolEntry<ulong> symbol = symbolTable!.Entries.ElementAt((int) symbolIndex);
                    
                        _memoryData[offset] = (byte) (symbol.Value);
                        _memoryData[offset + 1] = (byte) (symbol.Value >> 8);
                        _memoryData[offset + 2] = (byte) (symbol.Value >> 16);
                        _memoryData[offset + 3] = (byte) (symbol.Value >> 24);
                        _memoryData[offset + 4] = (byte) (symbol.Value >> 32);
                        _memoryData[offset + 5] = (byte) (symbol.Value >> 40);
                        _memoryData[offset + 6] = (byte) (symbol.Value >> 48);
                        _memoryData[offset + 7] = (byte) (symbol.Value >> 56);
                        break;
                }
            }
        }
    }
}