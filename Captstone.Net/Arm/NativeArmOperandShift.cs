namespace Gee.External.Capstone.Arm;

using System.Runtime.InteropServices;

/// <summary>
///     Native ARM Operand Shift.
/// </summary>
[StructLayout(LayoutKind.Explicit, Size = 8)]
internal struct NativeArmOperandShift
{
    /// <summary>
    ///     Shift Operation.
    /// </summary>
    [FieldOffset(0)] public ArmShiftOperation Operation;

    /// <summary>
    ///     Shift Value.
    /// </summary>
    [FieldOffset(4)] public int Value;
}