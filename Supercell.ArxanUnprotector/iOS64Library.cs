namespace Supercell.ArxanUnprotector;

using System.Diagnostics;
using Supercell.ArxanUnprotector.Ranges.Providers;
using Supercell.ArxanUnprotector.Strings.Providers;
using ELFSharp.MachO;

public class iOS64Library : Library
{
    private readonly MachO _macho;
    
    public iOS64Library(string path) : base(new GenericMemoryRangeTableProvider(), new Arm64StringEncryptionService())
    {
        _fileData = File.ReadAllBytes(path);
        _macho = MachOReader.Load(path);

        Segment[] segments = _macho.GetCommandsOfType<Segment>().ToArray();

        _memoryData = new byte[(uint) segments.Max(s => s.Address + s.Size)];

        foreach (Section section in segments.Where(s => s.Address != 0).SelectMany(s => s.Sections))
        {
            _fileData.AsSpan((int) section.Offset, (int) section.Size).CopyTo(_memoryData.AsSpan((int) section.Address, (int) section.Size));
        }
    }

    public override IEnumerable<int> InitFunctions
    {
        get
        {
            Span<byte> data = GetSectionByName("__mod_init_func", out _);
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

    public override IEnumerable<int> FiniFunctions => throw new NotSupportedException();
    
    public override int SectionCount => _macho.GetCommandsOfType<Section>().Count();

    public override Span<byte> GetSection(SectionType section, out int address)
    {
        string name = section switch
        {
            SectionType.Data => "__data",
            SectionType.Text => "__text",
            _ => throw new ArgumentOutOfRangeException(nameof(section), section, null)
        };
        
        return GetSectionByName(name, out address);
    }

    public override Span<byte> GetSectionAt(int index, out int address)
    {
        Section section = _macho.GetCommandsOfType<Section>().ElementAt(index);
        address = (int) section.Address;
        return _memoryData.AsSpan(address, (int) section.Size);
    }

    private Span<byte> GetSectionByName(string name, out int address)
    {
        Section section = _macho.GetCommandsOfType<Segment>().SelectMany(s => s.Sections).Single(s => s.Name == name);

        address = (int) section.Address;
        return _memoryData.AsSpan(address, (int) section.Size);
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
        foreach (Section section in _macho.GetCommandsOfType<Segment>().Where(s => s.Address != 0).SelectMany(s => s.Sections))
        {
            if (section.Name is "__data" or "__text")
            {
                Array.Copy(_memoryData, (int) section.Address, _fileData, (int) section.Offset, (int) section.Size);
            }
        }
        
        File.WriteAllBytes(filePath, _fileData);
    }
}