namespace Gee.External.Capstone.Arm64;

/// <summary>
///     ARM64 Memory Operand Value.
/// </summary>
public sealed class Arm64MemoryOperandValue
{
    /// <summary>
    ///     Create an ARM64 Memory Operand Value.
    /// </summary>
    /// <param name="disassembler">
    ///     A disassembler.
    /// </param>
    /// <param name="nativeMemoryOperandValue">
    ///     A native ARM64 memory operand value.
    /// </param>
    internal Arm64MemoryOperandValue(CapstoneDisassembler disassembler,
        ref NativeArm64MemoryOperandValue nativeMemoryOperandValue)
    {
        Base = Arm64Register.TryCreate(disassembler, nativeMemoryOperandValue.Base);
        Displacement = nativeMemoryOperandValue.Displacement;
        Index = Arm64Register.TryCreate(disassembler, nativeMemoryOperandValue.Index);
    }

    /// <summary>
    ///     Get Base Register.
    /// </summary>
    public Arm64Register Base { get; }

    /// <summary>
    ///     Get Displacement Value.
    /// </summary>
    public int Displacement { get; }

    /// <summary>
    ///     Get Index Register.
    /// </summary>
    public Arm64Register Index { get; }
}