namespace Gee.External.Capstone.Arm;

using System.Runtime.InteropServices;

/// <summary>
///     Native ARM Memory Operand Value.
/// </summary>
[StructLayout(LayoutKind.Explicit, Size = 20)]
internal struct NativeArmMemoryOperandValue
{
    /// <summary>
    ///     Base Register.
    /// </summary>
    [FieldOffset(0)] public ArmRegisterId Base;

    /// <summary>
    ///     Index Register.
    /// </summary>
    [FieldOffset(4)] public ArmRegisterId Index;

    /// <summary>
    ///     Index Register's Scale.
    /// </summary>
    [FieldOffset(8)] public int Scale;

    /// <summary>
    ///     Displacement Value.
    /// </summary>
    [FieldOffset(12)] public int Displacement;

    /// <summary>
    ///     Index Register's Left Shift Value.
    /// </summary>
    [FieldOffset(16)] public int LeftShift;
}