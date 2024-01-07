namespace Supercell.ArxanUnprotector.Strings.Providers;

using System.Text;
using Supercell.ArxanUnprotector.Disassembler;
using Supercell.ArxanUnprotector.Ranges;
using Gee.External.Capstone.Arm;

public class ArmStringEncryptionService : IStringEncryptionService
{
    public Library Library { get; set; }

    public RangeTable FindStringTable()
    {
        int decryptFunctionAddress = Library.InitFunctions.First();

        ArmInstruction ldrJumpInstruction = null;
        ArmInstruction addJumpInstruction = null;
        
        using (ArmDisassembler disassembler = new ArmDisassembler(true))
        {
            Span<byte> functionBytes = Library.Take(decryptFunctionAddress, 0x10000);

            foreach (ArmInstruction instruction in disassembler.Iterate(functionBytes.ToArray(), decryptFunctionAddress))
            {
                if (ldrJumpInstruction != null)
                {
                    if (instruction.Id == ArmInstructionId.ARM_INS_ADD)
                    {
                        ArmOperand andRegister = instruction.Details.Operands[0];

                        if (andRegister.Type == ArmOperandType.Register)
                        {
                            ArmOperand ldrRegister = ldrJumpInstruction.Details.Operands[0];

                            if (andRegister.Register.Id == ldrRegister.Register.Id)
                            {
                                addJumpInstruction = instruction;
                                
                                int pc = disassembler.CalculateProgramCounterRegister(ldrJumpInstruction, null);
                                int offset = ldrJumpInstruction.Details.Operands[1].Memory.Displacement;
                                int pTableAddress = BitConverter.ToInt32(Library.Take(pc + offset));

                                int rangeTableStartAddress = pTableAddress + disassembler.CalculateProgramCounterRegister(addJumpInstruction, null);

                                if (RangeTableUtils.TryReadRangeTable(Library, rangeTableStartAddress, out RangeTable rangeTable))
                                {
                                    return rangeTable;
                                }
                            }
                        }
                    }
                }
                
                if (instruction.Id == ArmInstructionId.ARM_INS_LDR)
                {
                    ArmOperand operand2 = instruction.Details.Operands[1];

                    if (operand2 is {Type: ArmOperandType.Memory, Memory.Base.Id: ArmRegisterId.ARM_REG_PC})
                    {
                        ldrJumpInstruction = instruction;
                    }
                }
            }

            throw new NotSupportedException("Could not find String table.");
        }
    }

    public EncryptedStringKey FindKey()
    {
        int decryptFunctionAddress = Library.InitFunctions.First();
        
        ArmInstruction andKeyInstruction = null;
        ArmInstruction ldrJumpInstruction = null;
        ArmInstruction addJumpInstruction = null;

        using (ArmDisassembler disassembler = new ArmDisassembler(true))
        {
            Span<byte> functionBytes = Library.Take(decryptFunctionAddress, 0x10000);

            foreach (ArmInstruction instruction in disassembler.Iterate(functionBytes.ToArray(), decryptFunctionAddress))
            {
                if (ldrJumpInstruction != null)
                {
                    if (instruction.Id == ArmInstructionId.ARM_INS_ADD)
                    {
                        ArmOperand andRegister = instruction.Details.Operands[0];

                        if (andRegister.Type == ArmOperandType.Register)
                        {
                            ArmOperand ldrRegister = ldrJumpInstruction.Details.Operands[0];
                            
                            if (andRegister.Register.Id == ldrRegister.Register.Id)
                            {
                                addJumpInstruction = instruction;
                                break;
                            }
                        }
                    }
                }
                else if (andKeyInstruction != null)
                {
                    if (instruction.Id == ArmInstructionId.ARM_INS_LDR)
                    {
                        ArmOperand operand2 = instruction.Details.Operands[1];

                        if (operand2 is {Type: ArmOperandType.Memory, Memory.Base.Id: ArmRegisterId.ARM_REG_PC})
                        {
                            ldrJumpInstruction = instruction;
                        }
                    }
                }
                else
                {
                    if (instruction.Id == ArmInstructionId.ARM_INS_AND && instruction.Details.Operands[2] is {Type: ArmOperandType.Immediate, Immediate: 127 })
                    {
                        andKeyInstruction = instruction;
                    }
                }
            }

            if (ldrJumpInstruction == null)
                throw new NotSupportedException("Could not find String key.");
            
            int pc = disassembler.CalculateProgramCounterRegister(ldrJumpInstruction, null);
            int offset = ldrJumpInstruction.Details.Operands[1].Memory.Displacement;
            int pKeyAddress = BitConverter.ToInt32(Library.Take(pc + offset));

            return new EncryptedStringKey(pKeyAddress + disassembler.CalculateProgramCounterRegister(addJumpInstruction, null), 128, Library);
        }
    }
    
    public void Compute(Span<byte> bytes)
    {
        Span<byte> key = Library.EncryptedStringKey.Content;
        
        for (int i = 0; i < bytes.Length; i++)
        {
            bytes[i] ^= key[i % 128];
        }
    }
}