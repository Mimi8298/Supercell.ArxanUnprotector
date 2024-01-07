namespace Gee.External.Capstone.Arm;

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

/// <summary>
///     ARM Operand.
/// </summary>
public sealed class ArmOperand
{
    /// <summary>
    ///     Operand's Access Type.
    /// </summary>
    private readonly OperandAccessType _accessType;

    /// <summary>
    ///     Floating Point Value.
    /// </summary>
    private readonly double _floatingPoint;

    /// <summary>
    ///     Immediate Value.
    /// </summary>
    private readonly int _immediate;

    /// <summary>
    ///     Memory Value.
    /// </summary>
    private readonly ArmMemoryOperandValue _memory;

    /// <summary>
    ///     Register Value.
    /// </summary>
    private readonly ArmRegister _register;

    /// <summary>
    ///     SETEND Operation.
    /// </summary>
    private readonly ArmSetEndOperation _setEndOperation;

    /// <summary>
    ///     Shift Register.
    /// </summary>
    private readonly ArmRegister _shiftRegister;

    /// <summary>
    ///     Shift Value.
    /// </summary>
    private readonly int _shiftValue;

    /// <summary>
    ///     System Register Value.
    /// </summary>
    private readonly ArmSystemRegister _systemRegister;

    /// <summary>
    ///     Create an ARM Operand.
    /// </summary>
    /// <param name="disassembler">
    ///     A disassembler.
    /// </param>
    /// <param name="nativeOperand">
    ///     A native ARM operand.
    /// </param>
    internal ArmOperand(CapstoneDisassembler disassembler, ref NativeArmOperand nativeOperand)
    {
        _accessType = !CapstoneDisassembler.IsDietModeEnabled ? nativeOperand.AccessType : OperandAccessType.Invalid;
        IsSubtracted = nativeOperand.IsSubtracted;
        NeonLane = nativeOperand.NeonLane;
        ShiftOperation = nativeOperand.Shift.Operation;
        Type = nativeOperand.Type;
        VectorIndex = nativeOperand.VectorIndex;
        // ...
        //
        // ...
        _shiftRegister = CreateShiftRegister(this, disassembler, ref nativeOperand);
        _shiftValue = CreateShiftValue(this, ref nativeOperand);
        // ...
        //
        // ...
        switch (Type)
        {
            case ArmOperandType.CImmediate:
                _immediate = nativeOperand.Value.Immediate;
                break;
            case ArmOperandType.FloatingPoint:
                _floatingPoint = nativeOperand.Value.FloatingPoint;
                break;
            case ArmOperandType.Immediate:
                _immediate = nativeOperand.Value.Immediate;
                break;
            case ArmOperandType.Memory:
                _memory = new ArmMemoryOperandValue(disassembler, ref nativeOperand.Value.Memory);
                break;
            case ArmOperandType.PImmediate:
                _immediate = nativeOperand.Value.Immediate;
                break;
            case ArmOperandType.Register:
                _register = ArmRegister.TryCreate(disassembler, (ArmRegisterId) nativeOperand.Value.Register);
                break;
            case ArmOperandType.SetEndOperation:
                _setEndOperation = nativeOperand.Value.SetEndOperation;
                break;
            case ArmOperandType.SystemRegister:
                _systemRegister = (ArmSystemRegister) nativeOperand.Value.Register;
                break;
        }

        // <summary>
        //      Create Shift Value.
        // </summary>
        int CreateShiftValue(ArmOperand @this, ref NativeArmOperand cNativeOperand)
        {
            int cShiftValue = 0;
            if (@this.ShiftOperation != ArmShiftOperation.Invalid) cShiftValue = cNativeOperand.Shift.Value;

            return cShiftValue;
        }

        // <summary>
        //      Create Shift Register.
        // </summary>
        ArmRegister CreateShiftRegister(ArmOperand @this, CapstoneDisassembler cDisassembler,
            ref NativeArmOperand cNativeArmOperand)
        {
            ArmRegister cShiftRegister = null;
            if (@this.ShiftOperation != ArmShiftOperation.Invalid)
                if (@this.ShiftOperation >= ArmShiftOperation.ARM_SFT_ASR_REG)
                    cShiftRegister =
                        ArmRegister.TryCreate(cDisassembler, (ArmRegisterId) cNativeArmOperand.Shift.Value);

            return cShiftRegister;
        }
    }

    /// <summary>
    ///     Get Operand's Access Type.
    /// </summary>
    /// <remarks>
    ///     Represents the operand's access type if, and only if, Diet Mode is disabled. To determine if Diet Mode
    ///     is disabled, call <see cref="IsDietModeEnabled" />.
    /// </remarks>
    /// <exception cref="System.NotSupportedException">
    ///     Thrown if Diet Mode is enabled.
    /// </exception>
    public OperandAccessType AccessType
    {
        get
        {
            CapstoneDisassembler.ThrowIfDietModeIsEnabled();
            return _accessType;
        }
    }

    /// <summary>
    ///     Get Floating Point Value.
    /// </summary>
    /// <remarks>
    ///     Represents the operand's floating point value if, and only if, the operand's type is
    ///     <see cref="ArmOperandType.FloatingPoint" />. To determine the operand's type, call
    ///     <see cref="Type" />.
    /// </remarks>
    /// <exception cref="System.InvalidOperationException">
    ///     Thrown if the operand's type is not <see cref="ArmOperandType.FloatingPoint" />.
    /// </exception>
    public double FloatingPoint
    {
        get
        {
            if (Type != ArmOperandType.FloatingPoint)
            {
                const string valueName = nameof(FloatingPoint);
                string detailMessage = $"A value ({valueName}) is invalid when the type is ({Type}).";
                throw new InvalidOperationException(detailMessage);
            }

            return _floatingPoint;
        }
    }

    /// <summary>
    ///     Get Immediate Value.
    /// </summary>
    /// <remarks>
    ///     Represents the operand's immediate value if the operand's type is
    ///     <see cref="ArmOperandType.CImmediate" />, <see cref="ArmOperandType.Immediate" />, or
    ///     <see cref="ArmOperandType.PImmediate" />. To determine the operand's type, call <see cref="Type" />.
    /// </remarks>
    /// <exception cref="System.InvalidOperationException">
    ///     Thrown if the operand's type is not <see cref="ArmOperandType.CImmediate" />,
    ///     <see cref="ArmOperandType.Immediate" />, or <see cref="ArmOperandType.PImmediate" />.
    /// </exception>
    public int Immediate
    {
        get
        {
            bool isTypeImmediate = Type == ArmOperandType.CImmediate;
            isTypeImmediate = isTypeImmediate || Type == ArmOperandType.Immediate;
            isTypeImmediate = isTypeImmediate || Type == ArmOperandType.PImmediate;
            if (!isTypeImmediate)
            {
                const string valueName = nameof(Immediate);
                string detailMessage = $"A value ({valueName}) is invalid when the type is ({Type}).";
                throw new InvalidOperationException(detailMessage);
            }

            return _immediate;
        }
    }

    /// <summary>
    ///     Determine if Diet Mode is Enabled.
    /// </summary>
    /// <remarks>
    ///     Indicates if Diet Mode is enabled. A boolean true indicates it is enabled. A boolean false otherwise.
    /// </remarks>
    public bool IsDietModeEnabled => CapstoneDisassembler.IsDietModeEnabled;

    /// <summary>
    ///     Get Subtracted Flag.
    /// </summary>
    public bool IsSubtracted { get; }

    /// <summary>
    ///     Get Memory Value.
    /// </summary>
    /// <remarks>
    ///     Represents the operand's memory value if, and only if, the operand's type is
    ///     <see cref="ArmOperandType.Memory" />. To determine the operand's type, call <see cref="Type" />.
    /// </remarks>
    /// <exception cref="System.InvalidOperationException">
    ///     Thrown if the operand's type is not <see cref="ArmOperandType.Memory" />.
    /// </exception>
    public ArmMemoryOperandValue Memory
    {
        get
        {
            if (Type != ArmOperandType.Memory)
            {
                const string valueName = nameof(Memory);
                string detailMessage = $"A value ({valueName}) is invalid when the type is ({Type}).";
                throw new InvalidOperationException(detailMessage);
            }

            return _memory;
        }
    }

    /// <summary>
    ///     Get Neon Lane Value.
    /// </summary>
    public sbyte NeonLane { get; }

    /// <summary>
    ///     Get Register Value.
    /// </summary>
    /// <remarks>
    ///     Represents the operand's register value if, and only if, the operand's type is
    ///     <see cref="ArmOperandType.Register" />. To determine the operand's type, call <see cref="Type" />.
    /// </remarks>
    /// <exception cref="System.InvalidOperationException">
    ///     Thrown if the operand's type is not <see cref="ArmOperandType.Register" />.
    /// </exception>
    public ArmRegister Register
    {
        get
        {
            if (Type != ArmOperandType.Register)
            {
                const string valueName = nameof(Register);
                string detailMessage = $"A value ({valueName}) is invalid when the type is ({Type}).";
                throw new InvalidOperationException(detailMessage);
            }

            return _register;
        }
    }

    /// <summary>
    ///     Get SETEND Operation.
    /// </summary>
    /// <remarks>
    ///     Represents the operand's SETEND operation if, and only if, the operand's type is
    ///     <see cref="ArmOperandType.SetEndOperation" />. To determine the operand's type, call
    ///     <see cref="Type" />.
    /// </remarks>
    /// <exception cref="System.InvalidOperationException">
    ///     Thrown if the operand's type is not <see cref="ArmOperandType.SetEndOperation" />.
    /// </exception>
    public ArmSetEndOperation SetEndOperation
    {
        get
        {
            if (Type != ArmOperandType.SetEndOperation)
            {
                const string valueName = nameof(SetEndOperation);
                string detailMessage = $"A value ({valueName}) is invalid when the type is ({Type}).";
                throw new InvalidOperationException(detailMessage);
            }

            return _setEndOperation;
        }
    }

    /// <summary>
    ///     Get Shift Operation.
    /// </summary>
    public ArmShiftOperation ShiftOperation { get; }

    /// <summary>
    ///     Get Shift Register.
    /// </summary>
    /// <remarks>
    ///     Conveniently represents the operand's shift register if the operand's shift operation is not
    ///     <see cref="ArmShiftOperation.Invalid" /> and greater than or equal to
    ///     <see cref="ArmShiftOperation.ARM_SFT_ASR_REG" />. To determine the operand's shift operation,
    ///     call <see cref="ShiftOperation" />.
    /// </remarks>
    /// <exception cref="System.InvalidOperationException">
    ///     Thrown if the shift operation is equal to <see cref="ArmShiftOperation.Invalid" />, or if the shift
    ///     operation is less than <see cref="ArmShiftOperation.ARM_SFT_ASR_REG" />.
    /// </exception>
    public ArmRegister ShiftRegister
    {
        get
        {
            if (ShiftOperation == ArmShiftOperation.Invalid)
            {
                const string valueName = nameof(ShiftRegister);
                string detailMessage = $"A value ({valueName}) is invalid when the type is ({ShiftOperation}).";
                throw new InvalidOperationException(detailMessage);
            }

            if (!(ShiftOperation >= ArmShiftOperation.ARM_SFT_ASR_REG))
            {
                const string valueName = nameof(ShiftRegister);
                string detailMessage = $"A value ({valueName}) is invalid when the type is ({ShiftOperation}).";
                throw new InvalidOperationException(detailMessage);
            }

            return _shiftRegister;
        }
    }

    /// <summary>
    ///     Get Shift Value.
    /// </summary>
    /// <remarks>
    ///     Represents the operand's shift value if, and only if, the operand's shift operation is not
    ///     <see cref="ArmShiftOperation.Invalid" />. To determine the operand's shift operation, call
    ///     <see cref="ShiftOperation" />.
    /// </remarks>
    /// <exception cref="System.InvalidOperationException">
    ///     Thrown if the shift operation is <see cref="ArmShiftOperation.Invalid" />.
    /// </exception>
    public int ShiftValue
    {
        get
        {
            if (ShiftOperation == ArmShiftOperation.Invalid)
            {
                const string valueName = nameof(ShiftValue);
                string detailMessage = $"A value ({valueName}) is invalid when the type is ({ShiftOperation}).";
                throw new InvalidOperationException(detailMessage);
            }

            return _shiftValue;
        }
    }

    /// <summary>
    ///     Get System Register.
    /// </summary>
    /// <remarks>
    ///     Represents the operand's system register if, and only if, the operand's type is
    ///     <see cref="ArmOperandType.SystemRegister" />. To determine the operand's type, call
    ///     <see cref="Type" />.
    /// </remarks>
    /// <exception cref="System.InvalidOperationException">
    ///     Thrown if the operand's type is not <see cref="ArmOperandType.SystemRegister" />.
    /// </exception>
    public ArmSystemRegister SystemRegister
    {
        get
        {
            if (Type != ArmOperandType.SystemRegister)
            {
                const string valueName = nameof(SystemRegister);
                string detailMessage = $"A value ({valueName}) is invalid when the type is ({Type}).";
                throw new InvalidOperationException(detailMessage);
            }

            return _systemRegister;
        }
    }

    /// <summary>
    ///     Get Operand's Type.
    /// </summary>
    public ArmOperandType Type { get; }

    /// <summary>
    ///     Get Vector Index.
    /// </summary>
    public int VectorIndex { get; }

    /// <summary>
    ///     Create ARM Operands.
    /// </summary>
    /// <param name="disassembler">
    ///     A disassembler.
    /// </param>
    /// <param name="nativeInstructionDetail">
    ///     A native ARM instruction detail.
    /// </param>
    /// <returns>
    ///     An array of ARM operands.
    /// </returns>
    internal static ArmOperand[] Create(CapstoneDisassembler disassembler,
        ref NativeArmInstructionDetail nativeInstructionDetail)
    {
        ArmOperand[] operands = new ArmOperand[nativeInstructionDetail.OperandCount];
        
        for (int i = 0; i < operands.Length; i++)
        {
            operands[i] = new ArmOperand(disassembler, ref nativeInstructionDetail.Operands.GetReference(i));
        }

        return operands;
    }
}