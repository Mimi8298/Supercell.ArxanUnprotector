namespace Supercell.ArxanUnprotector.Disassembler;

using Supercell.ArxanUnprotector;
using Supercell.ArxanUnprotector.Disassembler.References;
using Gee.External.Capstone.Arm;

public class ArmDisassembler : IDisposable
{
    private readonly CapstoneArmDisassembler _armDisassembler;
    private readonly CapstoneArmDisassembler _thumbDisassembler;
    
    public Dictionary<ArmRegisterId, int> Registers { get; }

    public ArmDisassembler(bool details = false)
    {
        _armDisassembler = new CapstoneArmDisassembler(ArmDisassembleMode.Arm);
        _armDisassembler.EnableSkipDataMode = true;
        _armDisassembler.EnableInstructionDetails = details;
        _thumbDisassembler = new CapstoneArmDisassembler(ArmDisassembleMode.Thumb);
        _thumbDisassembler.EnableSkipDataMode = true;
        _thumbDisassembler.EnableInstructionDetails = details;
        
        Registers = new Dictionary<ArmRegisterId, int>();
        
        foreach (ArmRegisterId register in Enum.GetValues<ArmRegisterId>())
        {
            if (!Registers.ContainsKey(register))
            {
                Registers.Add(register, 0);
            }
        }
    }

    public IEnumerable<ArmInstruction> Iterate(Library library)
    {
        byte[] data = library.GetSection(SectionType.Text, out int address).ToArray();
        return Iterate(data.ToArray(), address);
    }
    
    public IEnumerable<ArmInstruction> Iterate(byte[] data, int address)
    {
        ArmInstruction previousInstruction = null;
        
        foreach (ArmInstruction instruction in _armDisassembler.Iterate(data, address))
        {
            Registers[ArmRegisterId.ARM_REG_PC] = CalculateProgramCounterRegister(instruction, previousInstruction);
            yield return instruction;
            previousInstruction = instruction;
        }

        previousInstruction = null;
        
        foreach (ArmInstruction instruction in _thumbDisassembler.Iterate(data, address))
        {
            Registers[ArmRegisterId.ARM_REG_PC] = CalculateProgramCounterRegister(instruction, previousInstruction);
            yield return instruction;
            previousInstruction = instruction;
        }
    }

    public int CalculateProgramCounterRegister(ArmInstruction instruction, ArmInstruction previousInstruction)
    {
        int programCounter = instruction.DisassembleMode == ArmDisassembleMode.Arm ? 8 : 4;

        if (previousInstruction != null && IsBranchInstruction(previousInstruction))
            programCounter /= 2;
        
        return (int) instruction.Address + programCounter;
    }

    private bool IsBranchInstruction(ArmInstruction instruction)
    {
        return instruction.Id is ArmInstructionId.ARM_INS_B or ArmInstructionId.ARM_INS_BL or ArmInstructionId.ARM_INS_BLX or ArmInstructionId.ARM_INS_BX or ArmInstructionId.ARM_INS_BXJ;
    }

    public void Dispose()
    {
        _armDisassembler?.Dispose();
        _thumbDisassembler?.Dispose();
    }
}