namespace Gee.External.Capstone;

/// <summary>
///     Disassembled Instruction Detail.
/// </summary>
/// <typeparam name="TSelf">
///     This type.
/// </typeparam>
/// <typeparam name="TDisassembleMode">
///     The type of the hardware mode the instruction was disassembled for.
/// </typeparam>
/// <typeparam name="TGroup">
///     The type of the instruction's architecture specific instruction groups.
/// </typeparam>
/// <typeparam name="TGroupId">
///     The type of the instruction's architecture specific instruction group unique identifiers.
/// </typeparam>
/// <typeparam name="TInstruction">
///     The type of the instruction.
/// </typeparam>
/// <typeparam name="TInstructionId">
///     The type of the instruction's unique identifier.
/// </typeparam>
/// <typeparam name="TRegister">
///     The type of the instruction's architecture specific registers.
/// </typeparam>
/// <typeparam name="TRegisterId">
///     The type of the instruction's architecture specific register unique identifiers.
/// </typeparam>
public abstract class InstructionDetail<TSelf, TDisassembleMode, TGroup, TGroupId, TInstruction, TInstructionId,
    TRegister, TRegisterId>
    where TSelf : InstructionDetail<TSelf, TDisassembleMode, TGroup, TGroupId, TInstruction, TInstructionId, TRegister,
        TRegisterId>
    where TDisassembleMode : Enum
    where TGroup : InstructionGroup<TGroupId>
    where TGroupId : Enum
    where TInstruction : Instruction<TInstruction, TSelf, TDisassembleMode, TGroup, TGroupId, TInstructionId, TRegister,
        TRegisterId>
    where TInstructionId : Enum
    where TRegister : Register<TRegisterId>
    where TRegisterId : Enum
{
    /// <summary>
    ///     All Read Registers.
    /// </summary>
    private readonly TRegister[] _allReadRegisters;

    /// <summary>
    ///     All Written Registers.
    /// </summary>
    private readonly TRegister[] _allWrittenRegisters;

    /// <summary>
    ///     Explicitly Read Registers.
    /// </summary>
    private readonly Lazy<TRegister[]> _explicitlyReadRegisters;

    /// <summary>
    ///     Explicitly Written Registers.
    /// </summary>
    private readonly Lazy<TRegister[]> _explicitlyWrittenRegisters;

    /// <summary>
    ///     Instruction's Groups.
    /// </summary>
    private readonly TGroup[] _groups;

    /// <summary>
    ///     Implicitly Read Registers.
    /// </summary>
    private readonly TRegister[] _implicitlyReadRegisters;

    /// <summary>
    ///     Implicitly Written Registers.
    /// </summary>
    private readonly TRegister[] _implicitlyWrittenRegisters;

    /// <summary>
    ///     Create a Disassembled Instruction Detail.
    /// </summary>
    /// <param name="builder">
    ///     A builder to initialize the object with.
    /// </param>
    private protected InstructionDetail(
        InstructionDetailBuilder<TSelf, TDisassembleMode, TGroup, TGroupId, TInstruction, TInstructionId, TRegister,
            TRegisterId> builder)
    {
        _allReadRegisters = builder.AllReadRegisters;
        _allWrittenRegisters = builder.AllWrittenRegisters;
        DisassembleArchitecture = builder.DisassembleArchitecture;
        DisassembleMode = builder.DisassembleMode;
        _explicitlyReadRegisters = new Lazy<TRegister[]>(OnExplicitlyReadRegistersLazyInitialization);
        _explicitlyWrittenRegisters = new Lazy<TRegister[]>(OnExplicitlyWrittenRegistersLazyInitialization);
        _groups = builder.Groups;
        _implicitlyReadRegisters = builder.ImplicitlyReadRegisters;
        _implicitlyWrittenRegisters = builder.ImplicitlyWrittenRegisters;
    }

    /// <summary>
    ///     Get All Read Registers.
    /// </summary>
    /// <remarks>
    ///     Represents all the registers read by the instruction, both explicitly and implicitly, if Diet Mode is
    ///     disabled and the hardware architecture the instruction was disassembled for supports the operation.
    ///     This is effectively equivalent to the union of <see cref="ExplicitlyReadRegisters" /> and
    ///     <see cref="ImplicitlyReadRegisters" />. To determine if Diet Mode is disabled, call
    ///     <see cref="IsDietModeEnabled" />.
    /// </remarks>
    /// <exception cref="System.NotSupportedException">
    ///     Thrown if Diet Mode is enabled, or if the hardware architecture the instruction was disassembled for
    ///     does not support the operation.
    /// </exception>
    public TRegister[] AllReadRegisters
    {
        get
        {
            CapstoneDisassembler.ThrowIfDietModeIsEnabled();

            bool isDisassembleArchitectureUnsupported = IsDisassembleArchitectureUnsupported();
            if (isDisassembleArchitectureUnsupported)
            {
                const string detailMessage = "An operation is unsupported.";
                throw new NotSupportedException(detailMessage);
            }

            return _allReadRegisters;
        }
    }

    /// <summary>
    ///     Get All Written Registers.
    /// </summary>
    /// <remarks>
    ///     Represents all the registers written by the instruction, both explicitly and implicitly, if Diet Mode
    ///     is disabled and the hardware architecture the instruction was disassembled for supports the operation.
    ///     This is effectively equivalent to the union of <see cref="ExplicitlyWrittenRegisters" /> and
    ///     <see cref="ImplicitlyWrittenRegisters" />. To determine if Diet Mode is disabled, call
    ///     <see cref="IsDietModeEnabled" />.
    /// </remarks>
    /// <exception cref="System.NotSupportedException">
    ///     Thrown if Diet Mode is enabled, or if the hardware architecture the instruction was disassembled for
    ///     does not support the operation.
    /// </exception>
    public TRegister[] AllWrittenRegisters
    {
        get
        {
            CapstoneDisassembler.ThrowIfDietModeIsEnabled();

            bool isDisassembleArchitectureUnsupported = IsDisassembleArchitectureUnsupported();
            if (isDisassembleArchitectureUnsupported)
            {
                const string detailMessage = "An operation is unsupported.";
                throw new NotSupportedException(detailMessage);
            }

            return _allWrittenRegisters;
        }
    }

    /// <summary>
    ///     Get Instruction's Disassemble Architecture.
    /// </summary>
    /// <remarks>
    ///     Represents the hardware architecture the instruction was disassembled for.
    /// </remarks>
    public DisassembleArchitecture DisassembleArchitecture { get; }

    /// <summary>
    ///     Get Instruction's Disassemble Mode.
    /// </summary>
    /// <remarks>
    ///     Represents the hardware mode the instruction was disassembled for.
    /// </remarks>
    public TDisassembleMode DisassembleMode { get; }

    /// <summary>
    ///     Get Explicitly Read Registers.
    /// </summary>
    /// <remarks>
    ///     Represents the registers explicitly read by the instruction, if Diet Mode is disabled and the hardware
    ///     architecture the instruction was disassembled for supports the operation. To determine if Diet Mode is
    ///     disabled, call <see cref="IsDietModeEnabled" />.
    /// </remarks>
    /// <exception cref="System.NotSupportedException">
    ///     Thrown if Diet Mode is enabled, or if the hardware architecture the instruction was disassembled for
    ///     does not support the operation.
    /// </exception>
    public TRegister[] ExplicitlyReadRegisters
    {
        get
        {
            CapstoneDisassembler.ThrowIfDietModeIsEnabled();

            bool isDisassembleArchitectureUnsupported = IsDisassembleArchitectureUnsupported();
            if (isDisassembleArchitectureUnsupported)
            {
                const string detailMessage = "An operation is unsupported.";
                throw new NotSupportedException(detailMessage);
            }

            return _explicitlyReadRegisters.Value;
        }
    }

    /// <summary>
    ///     Get Explicitly Written Registers.
    /// </summary>
    /// <remarks>
    ///     Represents the registers explicitly written by the instruction, if Diet Mode is disabled and the
    ///     hardware architecture the instruction was disassembled for supports the operation. To determine if
    ///     Diet Mode is disabled, call <see cref="IsDietModeEnabled" />.
    /// </remarks>
    /// <exception cref="System.NotSupportedException">
    ///     Thrown if Diet Mode is enabled, or if the hardware architecture the instruction was disassembled for
    ///     does not support the operation.
    /// </exception>
    public TRegister[] ExplicitlyWrittenRegisters
    {
        get
        {
            CapstoneDisassembler.ThrowIfDietModeIsEnabled();

            bool isDisassembleArchitectureUnsupported = IsDisassembleArchitectureUnsupported();
            if (isDisassembleArchitectureUnsupported)
            {
                const string detailMessage = "An operation is unsupported.";
                throw new NotSupportedException(detailMessage);
            }

            return _explicitlyWrittenRegisters.Value;
        }
    }

    /// <summary>
    ///     Get Instruction's Groups.
    /// </summary>
    /// <remarks>
    ///     Represents the instruction groups the instruction belongs to if, and only if, Diet Mode is disabled.
    ///     To determine if Diet Mode is disabled, call <see cref="IsDietModeEnabled" />.
    /// </remarks>
    /// <exception cref="System.NotSupportedException">
    ///     Thrown if Diet Mode is enabled.
    /// </exception>
    public TGroup[] Groups
    {
        get
        {
            CapstoneDisassembler.ThrowIfDietModeIsEnabled();
            return _groups;
        }
    }

    /// <summary>
    ///     Get Implicitly Read Registers.
    /// </summary>
    /// <remarks>
    ///     Represents the registers implicitly read by the instruction, if Diet Mode is disabled and the hardware
    ///     architecture the instruction was disassembled for supports the operation. To determine if Diet Mode is
    ///     disabled, call <see cref="IsDietModeEnabled" />.
    /// </remarks>
    /// <exception cref="System.NotSupportedException">
    ///     Thrown if Diet Mode is enabled.
    /// </exception>
    public TRegister[] ImplicitlyReadRegisters
    {
        get
        {
            CapstoneDisassembler.ThrowIfDietModeIsEnabled();
            return _implicitlyReadRegisters;
        }
    }

    /// <summary>
    ///     Get Implicitly Written Registers.
    /// </summary>
    /// <remarks>
    ///     Represents the registers implicitly written by the instruction, if Diet Mode is disabled and the
    ///     hardware architecture the instruction was disassembled for supports the operation. To determine if
    ///     Diet Mode is disabled, call <see cref="IsDietModeEnabled" />.
    /// </remarks>
    /// <exception cref="System.NotSupportedException">
    ///     Thrown if Diet Mode is enabled.
    /// </exception>
    public TRegister[] ImplicitlyWrittenRegisters
    {
        get
        {
            CapstoneDisassembler.ThrowIfDietModeIsEnabled();
            return _implicitlyWrittenRegisters;
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
    ///     Determine if Instruction Belongs to an Instruction Group.
    /// </summary>
    /// <param name="instructionGroupName">
    ///     An instruction group's name.
    /// </param>
    /// <returns>
    ///     A boolean true if the instruction belongs to the instruction group. A boolean false otherwise.
    /// </returns>
    /// <exception cref="System.NotSupportedException">
    ///     Thrown if Diet Mode is enabled.
    /// </exception>
    public bool BelongsToGroup(string instructionGroupName)
    {
        // ...
        //
        // Throws an exception if the operation fails.
        bool belongsToGroup = Groups.Any(g => g.Name == instructionGroupName);
        return belongsToGroup;
    }

    /// <summary>
    ///     Determine if Instruction Belongs to an Instruction Group.
    /// </summary>
    /// <param name="instructionGroupId">
    ///     An instruction group's unique identifier.
    /// </param>
    /// <returns>
    ///     A boolean true if the instruction belongs to the instruction group. A boolean false otherwise.
    /// </returns>
    /// <exception cref="System.NotSupportedException">
    ///     Thrown if Diet Mode is enabled.
    /// </exception>
    public bool BelongsToGroup(TGroupId instructionGroupId)
    {
        // ...
        //
        // Throws an exception if the operation fails.
        bool belongsToGroup = Groups.Any(g => g.Id.Equals(instructionGroupId));
        return belongsToGroup;
    }

    private bool IsDisassembleArchitectureUnsupported()
    {
        return DisassembleArchitecture == DisassembleArchitecture.M68K ||
               DisassembleArchitecture == DisassembleArchitecture.Mips ||
               DisassembleArchitecture == DisassembleArchitecture.PowerPc ||
               DisassembleArchitecture == DisassembleArchitecture.XCore;
    }

    /// <summary>
    ///     Determine if a Register Was Explicitly Read.
    /// </summary>
    /// <param name="registerName">
    ///     A register's name.
    /// </param>
    /// <returns>
    ///     A boolean true if the register was explicitly read by the instruction. A boolean false otherwise.
    /// </returns>
    /// <exception cref="System.NotSupportedException">
    ///     Thrown if Diet Mode is enabled, or if the hardware architecture the instruction was disassembled for
    ///     does not support the operation.
    /// </exception>
    public bool IsRegisterExplicitlyRead(string registerName)
    {
        // ...
        //
        // Throws an exception if the operation fails.
        bool isRegisterExplicitlyRead = ExplicitlyReadRegisters.Any(r => r.Name == registerName);
        return isRegisterExplicitlyRead;
    }

    /// <summary>
    ///     Determine if a Register Was Explicitly Read.
    /// </summary>
    /// <param name="registerId">
    ///     A register's unique identifier.
    /// </param>
    /// <returns>
    ///     A boolean true if the register was explicitly read by the instruction. A boolean false otherwise.
    /// </returns>
    /// <exception cref="System.NotSupportedException">
    ///     Thrown if Diet Mode is enabled, or if the hardware architecture the instruction was disassembled for
    ///     does not support the operation.
    /// </exception>
    public bool IsRegisterExplicitlyRead(TRegisterId registerId)
    {
        // ...
        //
        // Throws an exception if the operation fails.
        bool isRegisterExplicitlyRead = ExplicitlyReadRegisters.Any(r => r.Id.Equals(registerId));
        return isRegisterExplicitlyRead;
    }

    /// <summary>
    ///     Determine if a Register Was Explicitly Written.
    /// </summary>
    /// <param name="registerName">
    ///     A register's name.
    /// </param>
    /// <returns>
    ///     A boolean true if the register was explicitly written by the instruction. A boolean false otherwise.
    /// </returns>
    /// <exception cref="System.NotSupportedException">
    ///     Thrown if Diet Mode is enabled, or if the hardware architecture the instruction was disassembled for
    ///     does not support the operation.
    /// </exception>
    public bool IsRegisterExplicitlyWritten(string registerName)
    {
        // ...
        //
        // Throws an exception if the operation fails.
        bool isRegisterExplicitlyWritten = ExplicitlyWrittenRegisters.Any(r => r.Name == registerName);
        return isRegisterExplicitlyWritten;
    }

    /// <summary>
    ///     Determine if a Register Was Explicitly Written.
    /// </summary>
    /// <param name="registerId">
    ///     A register's unique identifier.
    /// </param>
    /// <returns>
    ///     A boolean true if the register was explicitly written by the instruction. A boolean false otherwise.
    /// </returns>
    /// <exception cref="System.NotSupportedException">
    ///     Thrown if Diet Mode is enabled, or if the hardware architecture the instruction was disassembled for
    ///     does not support the operation.
    /// </exception>
    public bool IsRegisterExplicitlyWritten(TRegisterId registerId)
    {
        // ...
        //
        // Throws an exception if the operation fails.
        bool isRegisterExplicitlyWritten = ExplicitlyWrittenRegisters.Any(r => r.Id.Equals(registerId));
        return isRegisterExplicitlyWritten;
    }

    /// <summary>
    ///     Determine if a Register Was Implicitly Read.
    /// </summary>
    /// <param name="registerName">
    ///     A register's name.
    /// </param>
    /// <returns>
    ///     A boolean true if the register was implicitly read by the instruction. A boolean false otherwise.
    /// </returns>
    /// <exception cref="System.NotSupportedException">
    ///     Thrown if Diet Mode is enabled.
    /// </exception>
    public bool IsRegisterImplicitlyRead(string registerName)
    {
        // ...
        //
        // Throws an exception if the operation fails.
        bool isRegisterImplicitlyRead = ImplicitlyReadRegisters.Any(r => r.Name == registerName);
        return isRegisterImplicitlyRead;
    }

    /// <summary>
    ///     Determine if a Register Was Implicitly Read.
    /// </summary>
    /// <param name="registerId">
    ///     A register's unique identifier.
    /// </param>
    /// <returns>
    ///     A boolean true if the register was implicitly read by the instruction. A boolean false otherwise.
    /// </returns>
    /// <exception cref="System.NotSupportedException">
    ///     Thrown if Diet Mode is enabled.
    /// </exception>
    public bool IsRegisterImplicitlyRead(TRegisterId registerId)
    {
        // ...
        //
        // Throws an exception if the operation fails.
        bool isRegisterImplicitlyRead = ImplicitlyReadRegisters.Any(r => r.Id.Equals(registerId));
        return isRegisterImplicitlyRead;
    }

    /// <summary>
    ///     Determine if a Register Was Implicitly Written.
    /// </summary>
    /// <param name="registerName">
    ///     A register's name.
    /// </param>
    /// <returns>
    ///     A boolean true if the register was implicitly written by the instruction. A boolean false otherwise.
    /// </returns>
    /// <exception cref="System.NotSupportedException">
    ///     Thrown if Diet Mode is enabled.
    /// </exception>
    public bool IsRegisterImplicitlyWritten(string registerName)
    {
        // ...
        //
        // Throws an exception if the operation fails.
        bool isRegisterImplicitlyWritten = ImplicitlyWrittenRegisters.Any(r => r.Name == registerName);
        return isRegisterImplicitlyWritten;
    }

    /// <summary>
    ///     Determine if a Register Was Implicitly Written.
    /// </summary>
    /// <param name="registerId">
    ///     A register's unique identifier.
    /// </param>
    /// <returns>
    ///     A boolean true if the register was implicitly modified by the instruction. A boolean false otherwise.
    /// </returns>
    /// <exception cref="System.NotSupportedException">
    ///     Thrown if Diet Mode is enabled.
    /// </exception>
    public bool IsRegisterImplicitlyWritten(TRegisterId registerId)
    {
        // ...
        //
        // Throws an exception if the operation fails.
        bool isRegisterImplicitlyWritten = ImplicitlyWrittenRegisters.Any(r => r.Id.Equals(registerId));
        return isRegisterImplicitlyWritten;
    }

    /// <summary>
    ///     Determine if a Register Was Explicitly or Implicitly Read.
    /// </summary>
    /// <remarks>
    ///     Indicates if a register was read by the instruction, both explicitly and implicitly, if Diet Mode is
    ///     disabled. If the hardware architecture the instruction was disassembled for does not support explicitly
    ///     read registers, only the implicitly read registers are considered. To determine if Diet Mode is
    ///     disabled, call <see cref="IsDietModeEnabled" />.
    /// </remarks>
    /// <param name="registerName">
    ///     A register's name.
    /// </param>
    /// <returns>
    ///     A boolean true if the register was explicitly or implicitly read by the instruction. A boolean false
    ///     otherwise.
    /// </returns>
    /// <exception cref="System.NotSupportedException">
    ///     Thrown if Diet Mode is enabled.
    /// </exception>
    public bool IsRegisterRead(string registerName)
    {
        // ...
        //
        // Throws an exception if the operation fails.
        bool isRegisterRead = IsDisassembleArchitectureUnsupported()
            ? ImplicitlyReadRegisters.Any(r => r.Name == registerName)
            : AllReadRegisters.Any(r => r.Name == registerName);

        return isRegisterRead;
    }

    /// <summary>
    ///     Determine if a Register Was Explicitly or Implicitly Read.
    /// </summary>
    /// <remarks>
    ///     Indicates if a register was read by the instruction, both explicitly and implicitly, if Diet Mode is
    ///     disabled. If the hardware architecture the instruction was disassembled for does not support explicitly
    ///     read registers, only the implicitly read registers are considered. To determine if Diet Mode is
    ///     disabled, call <see cref="IsDietModeEnabled" />.
    /// </remarks>
    /// <param name="registerId">
    ///     A register's unique identifier.
    /// </param>
    /// <returns>
    ///     A boolean true if the register was explicitly or implicitly read by the instruction. A boolean false
    ///     otherwise.
    /// </returns>
    /// <exception cref="System.NotSupportedException">
    ///     Thrown if Diet Mode is enabled.
    /// </exception>
    public bool IsRegisterRead(TRegisterId registerId)
    {
        // ...
        //
        // Throws an exception if the operation fails.
        bool isRegisterRead = IsDisassembleArchitectureUnsupported()
            ? ImplicitlyReadRegisters.Any(r => r.Id.Equals(registerId))
            : AllReadRegisters.Any(r => r.Id.Equals(registerId));

        return isRegisterRead;
    }

    /// <summary>
    ///     Determine if a Register Was Explicitly or Implicitly Written.
    /// </summary>
    /// <remarks>
    ///     Indicates if a register was written by the instruction, both explicitly and implicitly, if Diet Mode
    ///     is disabled. If the hardware architecture the instruction was disassembled for does not support
    ///     explicitly written registers, only the implicitly written registers are considered. To determine if
    ///     Diet Mode is disabled, call <see cref="IsDietModeEnabled" />.
    /// </remarks>
    /// <param name="registerName">
    ///     A register's name.
    /// </param>
    /// <returns>
    ///     A boolean true if the register was explicitly or implicitly written by the instruction. A boolean
    ///     false otherwise.
    /// </returns>
    /// <exception cref="System.NotSupportedException">
    ///     Thrown if Diet Mode is enabled.
    /// </exception>
    public bool IsRegisterWritten(string registerName)
    {
        // ...
        //
        // Throws an exception if the operation fails.
        bool isRegisterWritten = IsDisassembleArchitectureUnsupported()
            ? ImplicitlyWrittenRegisters.Any(r => r.Name == registerName)
            : AllWrittenRegisters.Any(r => r.Name == registerName);

        return isRegisterWritten;
    }

    /// <summary>
    ///     Determine if a Register Was Explicitly or Implicitly Written.
    /// </summary>
    /// <remarks>
    ///     Indicates if a register was written by the instruction, both explicitly and implicitly, if Diet Mode
    ///     is disabled. If the hardware architecture the instruction was disassembled for does not support
    ///     explicitly written registers, only the implicitly written registers are considered. To determine if
    ///     Diet Mode is disabled, call <see cref="IsDietModeEnabled" />.
    /// </remarks>
    /// <param name="registerId">
    ///     A register's unique identifier.
    /// </param>
    /// <returns>
    ///     A boolean true if the register was explicitly or implicitly modified by the instruction. A boolean
    ///     false otherwise.
    /// </returns>
    /// <exception cref="System.NotSupportedException">
    ///     Thrown if Diet Mode is enabled.
    /// </exception>
    public bool IsRegisterWritten(TRegisterId registerId)
    {
        // ...
        //
        // Throws an exception if the operation fails.
        bool isRegisterWritten = IsDisassembleArchitectureUnsupported()
            ? ImplicitlyWrittenRegisters.Any(r => r.Id.Equals(registerId))
            : AllWrittenRegisters.Any(r => r.Id.Equals(registerId));
        return isRegisterWritten;
    }

    /// <summary>
    ///     On Explicitly Read Registers Lazy Initialization.
    /// </summary>
    /// <returns>
    ///     The instruction's explicitly read registers.
    /// </returns>
    private TRegister[] OnExplicitlyReadRegistersLazyInitialization()
    {
        TRegister[] value = _allReadRegisters.Except(_implicitlyReadRegisters).ToArray();
        return value;
    }

    /// <summary>
    ///     On Explicitly Written Registers Lazy Initialization.
    /// </summary>
    /// <returns>
    ///     The instruction's explicitly written registers.
    /// </returns>
    private TRegister[] OnExplicitlyWrittenRegistersLazyInitialization()
    {
        TRegister[] value = _allWrittenRegisters.Except(_implicitlyWrittenRegisters).ToArray();
        return value;
    }
}