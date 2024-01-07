namespace Supercell.ArxanUnprotector.Disassembler;

using Supercell.ArxanUnprotector;
using Supercell.ArxanUnprotector.Disassembler.References;
using Gee.External.Capstone.Arm;
using Gee.External.Capstone.Arm64;

public class Arm64Disassembler : IDisposable
{
    private readonly CapstoneArm64Disassembler _arm64Disassembler;
    
    public Dictionary<Arm64RegisterId, int> Registers { get; }

    public Arm64Disassembler(bool details = false)
    {
        _arm64Disassembler = new CapstoneArm64Disassembler(Arm64DisassembleMode.Arm);
        _arm64Disassembler.EnableSkipDataMode = true;
        _arm64Disassembler.EnableInstructionDetails = details;
        
        Registers = new Dictionary<Arm64RegisterId, int>();
        
        foreach (Arm64RegisterId register in Enum.GetValues<Arm64RegisterId>())
        {
            if (!Registers.ContainsKey(register))
            {
                Registers.Add(register, 0);
            }
        }
    }

    public IEnumerable<Arm64Instruction> Iterate(Library library)
    {
        byte[] data = library.GetSection(SectionType.Text, out int address).ToArray();
        return Iterate(data.ToArray(), address);
    }
    
    public IEnumerable<Arm64Instruction> Iterate(byte[] data, int address)
    {
        foreach (Arm64Instruction instruction in _arm64Disassembler.Iterate(data, address))
        {
            yield return instruction;
        }
    }

    public void Dispose()
    {
        _arm64Disassembler?.Dispose();
    }
}