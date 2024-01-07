namespace Gee.External.Capstone.Arm64;

using System.Runtime.InteropServices;

/// <summary>
///     Native ARM64 Operand Shift.
/// </summary>
[StructLayout(LayoutKind.Explicit, Size = 8)]
internal struct NativeArm64OperandShift
{
    /// <summary>
    ///     Shift Operation.
    /// </summary>
    [FieldOffset(0)] public Arm64ShiftOperation Operation;

    /// <summary>
    ///     Shift Value.
    /// </summary>
    [FieldOffset(4)] public int Value;
}