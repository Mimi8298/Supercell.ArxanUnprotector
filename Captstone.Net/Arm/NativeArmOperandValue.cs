namespace Gee.External.Capstone.Arm;

using System.Runtime.InteropServices;

/// <summary>
///     Native ARM Operand Value.
/// </summary>
[StructLayout(LayoutKind.Explicit, Size = 20)]
internal struct NativeArmOperandValue
{
    /// <summary>
    ///     Register Value.
    /// </summary>
    [FieldOffset(0)] public int Register;

    /// <summary>
    ///     Immediate Value.
    /// </summary>
    [FieldOffset(0)] public int Immediate;

    /// <summary>
    ///     Floating Point Value.
    /// </summary>
    [FieldOffset(0)] public double FloatingPoint;

    /// <summary>
    ///     Memory Value.
    /// </summary>
    [FieldOffset(0)] public NativeArmMemoryOperandValue Memory;

    /// <summary>
    ///     SETEND Operation.
    /// </summary>
    [FieldOffset(0)] public ArmSetEndOperation SetEndOperation;
}