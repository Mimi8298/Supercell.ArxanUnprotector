namespace Gee.External.Capstone.Arm64;

using System.Runtime.InteropServices;

/// <summary>
///     Native ARM64 Instruction Detail.
/// </summary>
[StructLayout(LayoutKind.Explicit)]
internal struct NativeArm64InstructionDetail
{
    /// <summary>
    ///     Condition Code.
    /// </summary>
    [FieldOffset(0)] public Arm64ConditionCode ConditionCode;

    /// <summary>
    ///     Update Flags Flag.
    /// </summary>
    [FieldOffset(4)] public bool UpdateFlags;

    /// <summary>
    ///     Write Back Flag.
    /// </summary>
    [FieldOffset(5)] public bool WriteBack;

    /// <summary>
    ///     Instruction's Operand Count.
    /// </summary>
    [FieldOffset(6)] public byte OperandCount;

    /// <summary>
    ///     Instruction's Operands.
    /// </summary>
    [FieldOffset(8)] public Array8<NativeArm64Operand> Operands;
}