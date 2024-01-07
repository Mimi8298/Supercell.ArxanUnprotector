namespace Gee.External.Capstone.Arm64;

using System.Runtime.InteropServices;

/// <summary>
///     Native ARM64 Operand.
/// </summary>
[StructLayout(LayoutKind.Explicit, Size = 56)]
internal struct NativeArm64Operand
{
    /// <summary>
    ///     Vector Index.
    /// </summary>
    [FieldOffset(0)] public int VectorIndex;

    /// <summary>
    ///     Vector Arrangement Specifier.
    /// </summary>
    [FieldOffset(4)] public Arm64VectorArrangementSpecifier VectorArrangementSpecifier;

    /// <summary>
    ///     Vector Element Size Specifier.
    /// </summary>
    [FieldOffset(8)] public Arm64VectorElementSizeSpecifier VectorElementSizeSpecifier;

    /// <summary>
    ///     Shift.
    /// </summary>
    [FieldOffset(12)] public NativeArm64OperandShift Shift;

    /// <summary>
    ///     Extend Operation.
    /// </summary>
    [FieldOffset(20)] public Arm64ExtendOperation ExtendOperation;

    /// <summary>
    ///     Operand's Type.
    /// </summary>
    [FieldOffset(24)] public Arm64OperandType Type;

    /// <summary>
    ///     Operand's Value.
    /// </summary>
    [FieldOffset(32)] public NativeArm64OperandValue Value;

    /// <summary>
    ///     Operand's Access Type.
    /// </summary>
    [FieldOffset(48)] public OperandAccessType AccessType;
}