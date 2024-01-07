namespace Gee.External.Capstone.Arm;

using System.Runtime.InteropServices;

/// <summary>
///     Native ARM Instruction Detail.
/// </summary>
[StructLayout(LayoutKind.Explicit)]
internal struct NativeArmInstructionDetail
{
    /// <summary>
    ///     User Mode Flag.
    /// </summary>
    [FieldOffset(0)] public bool IsUserMode;

    /// <summary>
    ///     Vector Size.
    /// </summary>
    [FieldOffset(4)] public int VectorSize;

    /// <summary>
    ///     Vector Data Type.
    /// </summary>
    [FieldOffset(8)] public ArmVectorDataType VectorDataType;

    /// <summary>
    ///     CPS Mode.
    /// </summary>
    [FieldOffset(12)] public ArmCpsMode CpsMode;

    /// <summary>
    ///     CPS Flag.
    /// </summary>
    [FieldOffset(16)] public ArmCpsFlag CpsFlag;

    /// <summary>
    ///     Condition Code.
    /// </summary>
    [FieldOffset(20)] public ArmConditionCode ConditionCode;

    /// <summary>
    ///     Update Flags Flag.
    /// </summary>
    [FieldOffset(24)] public bool UpdateFlags;

    /// <summary>
    ///     Write Back Flag.
    /// </summary>
    [FieldOffset(25)] public bool WriteBack;

    /// <summary>
    ///     Memory Barrier Operation Operation.
    /// </summary>
    [FieldOffset(28)] public ArmMemoryBarrierOperation MemoryBarrierOperation;

    /// <summary>
    ///     Instruction's Operands' Count.
    /// </summary>
    [FieldOffset(32)] public byte OperandCount;

    /// <summary>
    ///     Instruction's Operands.
    /// </summary>
    [FieldOffset(40)] public Array36<NativeArmOperand> Operands;
}