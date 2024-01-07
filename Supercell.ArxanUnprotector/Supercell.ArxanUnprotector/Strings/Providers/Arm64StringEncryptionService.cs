namespace Supercell.ArxanUnprotector.Strings.Providers;

using System.Text;
using Supercell.ArxanUnprotector.Disassembler;
using Supercell.ArxanUnprotector.Ranges;
using Gee.External.Capstone.Arm;
using Gee.External.Capstone.Arm64;

public class Arm64StringEncryptionService : IStringEncryptionService
{
    public Library Library { get; set; }
    
    public RangeTable FindStringTable()
    {
        int decryptFunctionAddress = Library.InitFunctions.First();

        using (Arm64Disassembler disassembler = new Arm64Disassembler(true))
        {
            Span<byte> functionBytes = Library.Take(decryptFunctionAddress, 0x10000);

            foreach (Arm64Instruction instruction in disassembler.Iterate(functionBytes.ToArray(), decryptFunctionAddress))
            {
                if (instruction.Id is Arm64InstructionId.ARM64_INS_ADR or Arm64InstructionId.ARM64_INS_ADRP)
                {
                    Arm64Register destinationRegister = instruction.Details.Operands[0].Register;
                    Arm64Operand adrRegister = instruction.Details.Operands[1];

                    if (adrRegister.Type == Arm64OperandType.Immediate)
                    {
                        disassembler.Registers[destinationRegister.Id] = (int) adrRegister.Immediate;
                        
                        if (RangeTableUtils.TryReadRangeTable(Library, disassembler.Registers[destinationRegister.Id], out RangeTable rangeTable) && rangeTable.Content.Length >= 0x10000)
                        {
                            return rangeTable;
                        }
                    }
                }
                else if (instruction.Id is Arm64InstructionId.ARM64_INS_ADD or Arm64InstructionId.ARM64_INS_SUB)
                {
                    Arm64Register destinationRegister = instruction.Details.Operands[0].Register;
                    Arm64Register sourceRegister = instruction.Details.Operands[1].Register;
                    Arm64Operand changeOperand = instruction.Details.Operands[2];
                    
                    int sign = instruction.Id is Arm64InstructionId.ARM64_INS_ADD ? 1 : -1;

                    if (changeOperand.Type == Arm64OperandType.Immediate)
                    {
                        disassembler.Registers[destinationRegister.Id] = disassembler.Registers[sourceRegister.Id] +
                                                                         (int) changeOperand.Immediate * sign;
                    }
                    else if (changeOperand.Type == Arm64OperandType.Register)
                    {
                        disassembler.Registers[destinationRegister.Id] = disassembler.Registers[sourceRegister.Id] +
                                                                         disassembler.Registers[changeOperand.Register.Id] * sign;
                    }
                    else
                    {
                        throw new Exception("Unknown operand type");
                    }
                    
                    if (RangeTableUtils.TryReadRangeTable(Library, disassembler.Registers[destinationRegister.Id], out RangeTable rangeTable) && rangeTable.Content.Length >= 0x10000)
                    {
                        return rangeTable;
                    }
                }
            }
        }
        
        throw new Exception("String table not found");
    }

    public EncryptedStringKey FindKey()
    {
        int decryptFunctionAddress = Library.InitFunctions.First();
        int potentialKeyAddress = 0;
        bool andDetected = false;

        using (Arm64Disassembler disassembler = new Arm64Disassembler(true))
        {
            Span<byte> functionBytes = Library.Take(decryptFunctionAddress, 0x10000);

            foreach (Arm64Instruction instruction in disassembler.Iterate(functionBytes.ToArray(), decryptFunctionAddress))
            {
                bool isPreviousInstructionIsPotentialKeyAddress = potentialKeyAddress != 0;
                
                if (instruction.Id is Arm64InstructionId.ARM64_INS_ADR or Arm64InstructionId.ARM64_INS_ADRP && andDetected)
                {
                    Arm64Register destinationRegister = instruction.Details.Operands[0].Register;
                    Arm64Operand adrRegister = instruction.Details.Operands[1];

                    if (adrRegister.Type == Arm64OperandType.Immediate)
                    {
                        disassembler.Registers[destinationRegister.Id] = potentialKeyAddress = (int) adrRegister.Immediate;
                        isPreviousInstructionIsPotentialKeyAddress = false;
                    }
                }
                else if (instruction.Id is Arm64InstructionId.ARM64_INS_ADD or Arm64InstructionId.ARM64_INS_SUB && andDetected)
                {
                    Arm64Register destinationRegister = instruction.Details.Operands[0].Register;
                    Arm64Register sourceRegister = instruction.Details.Operands[1].Register;
                    Arm64Operand changeOperand = instruction.Details.Operands[2];
                    
                    int sign = instruction.Id is Arm64InstructionId.ARM64_INS_ADD ? 1 : -1;

                    if (changeOperand.Type == Arm64OperandType.Immediate)
                    {
                        disassembler.Registers[destinationRegister.Id] = disassembler.Registers[sourceRegister.Id] +
                                                                         (int) changeOperand.Immediate * sign;
                    }
                    else if (changeOperand.Type == Arm64OperandType.Register)
                    {
                        disassembler.Registers[destinationRegister.Id] = disassembler.Registers[sourceRegister.Id] +
                                                                         disassembler.Registers[changeOperand.Register.Id] * sign;
                    }
                    else
                    {
                        throw new Exception("Unknown operand type");
                    }
                    
                    potentialKeyAddress = disassembler.Registers[destinationRegister.Id];
                }
                else if (instruction.Id == Arm64InstructionId.ARM64_INS_AND)
                {
                    if (instruction.Details.Operands[2] is {Type: Arm64OperandType.Immediate, Immediate: 127})
                    {
                        if (andDetected)
                            throw new Exception("AND detected twice");
                    
                        andDetected = true;   
                    }
                }

                if (isPreviousInstructionIsPotentialKeyAddress)
                {
                    return new EncryptedStringKey(potentialKeyAddress, 128, Library);
                }
            }
        }
        
        throw new Exception("Key not found");
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