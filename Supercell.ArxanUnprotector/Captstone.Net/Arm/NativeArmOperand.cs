namespace Gee.External.Capstone.Arm;

using System.Runtime.InteropServices;

/// <summary>
///     Native ARM Operand.
/// </summary>
[StructLayout(LayoutKind.Explicit, Size = 48)]
internal struct NativeArmOperand
{
    /// <summary>
    ///     Vector Index.
    /// </summary>
    [FieldOffset(0)] public int VectorIndex;

    /// <summary>
    ///     Shift.
    /// </summary>
    [FieldOffset(4)] public NativeArmOperandShift Shift;

    /// <summary>
    ///     Operand's Type.
    /// </summary>
    [FieldOffset(12)] public ArmOperandType Type;

    /// <summary>
    ///     Operand's Value.
    /// </summary>
    [FieldOffset(16)] public NativeArmOperandValue Value;

    /// <summary>
    ///     Operand's Subtracted Flag.
    /// </summary>
    [FieldOffset(40)] public bool IsSubtracted;

    /// <summary>
    ///     Operand's Access Type.
    /// </summary>
    [FieldOffset(41)] public OperandAccessType AccessType;

    /// <summary>
    ///     Neon Lane Value.
    /// </summary>
    [FieldOffset(42)] public sbyte NeonLane;
}