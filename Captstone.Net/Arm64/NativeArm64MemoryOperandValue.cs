namespace Gee.External.Capstone.Arm64;

using System.Runtime.InteropServices;

/// <summary>
///     Native ARM64 Memory Operand Value.
/// </summary>
[StructLayout(LayoutKind.Explicit, Size = 12)]
internal struct NativeArm64MemoryOperandValue
{
    /// <summary>
    ///     Base Register.
    /// </summary>
    [FieldOffset(0)] public Arm64RegisterId Base;

    /// <summary>
    ///     Index Register.
    /// </summary>
    [FieldOffset(4)] public Arm64RegisterId Index;

    /// <summary>
    ///     Displacement Value.
    /// </summary>
    [FieldOffset(8)] public int Displacement;
}