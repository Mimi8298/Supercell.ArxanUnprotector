namespace Gee.External.Capstone;

using System.Diagnostics;
using System.Runtime.CompilerServices;
using Gee.External.Capstone.Arm;
using Gee.External.Capstone.Arm64;

/// <summary>
///     Capstone Disassembler.
/// </summary>
public abstract class CapstoneDisassembler : IDisposable
{
    /// <summary>
    ///     Determine if the ARM64 Architecture is Supported.
    /// </summary>
    /// <remarks>
    ///     Indicates if the ARM64 architecture is supported. A boolean true indicates it is supported. A boolean
    ///     false otherwise.
    /// </remarks>
    public static bool IsArm64Supported
    {
        get
        {
            bool value = NativeCapstone.Query(NativeQueryOption.QueryArm64Architecture);
            return value;
        }
    }

    /// <summary>
    ///     Determine if the ARM Architecture is Supported.
    /// </summary>
    /// <remarks>
    ///     Indicates if the ARM architecture is supported. A boolean true indicates it is supported. A boolean
    ///     false otherwise.
    /// </remarks>
    public static bool IsArmSupported
    {
        get
        {
            bool value = NativeCapstone.Query(NativeQueryOption.QueryArmArchitecture);
            return value;
        }
    }

    /// <summary>
    ///     Determine if Diet Mode is Enabled.
    /// </summary>
    /// <remarks>
    ///     Indicates if Diet Mode is enabled. A boolean true indicates it is enabled. A boolean false otherwise.
    /// </remarks>
    public static bool IsDietModeEnabled
    {
        get
        {
            bool value = NativeCapstone.Query(NativeQueryOption.QueryDietMode);
            return value;
        }
    }

    /// <summary>
    ///     Determine if the Ethereum EVM Architecture is Supported.
    /// </summary>
    /// <remarks>
    ///     Indicates if the Ethereum EVM architecture is supported. A boolean true indicates it is supported. A
    ///     boolean false otherwise.
    /// </remarks>
    internal static bool IsEvmSupported
    {
        get
        {
            bool value = NativeCapstone.Query(NativeQueryOption.QueryEvmArchitecture);
            return value;
        }
    }

    /// <summary>
    ///     Determine if the M680X Architecture is Supported.
    /// </summary>
    /// <remarks>
    ///     Indicates if the M680X architecture is supported. A boolean true indicates it is supported. A boolean
    ///     false otherwise.
    /// </remarks>
    internal static bool IsM680XSupported
    {
        get
        {
            bool value = NativeCapstone.Query(NativeQueryOption.QueryM680XArchitecture);
            return value;
        }
    }

    /// <summary>
    ///     Determine if the M68K Architecture is Supported.
    /// </summary>
    /// <remarks>
    ///     Indicates if the M68K architecture is supported. A boolean true indicates it is supported. A boolean
    ///     false otherwise.
    /// </remarks>
    public static bool IsM68KSupported
    {
        get
        {
            bool value = NativeCapstone.Query(NativeQueryOption.QueryM68KArchitecture);
            return value;
        }
    }

    /// <summary>
    ///     Determine if the MIPS Architecture is Supported.
    /// </summary>
    /// <remarks>
    ///     Indicates if the MIPS architecture is supported. A boolean true indicates it is supported. A boolean
    ///     false otherwise.
    /// </remarks>
    public static bool IsMipsSupported
    {
        get
        {
            bool value = NativeCapstone.Query(NativeQueryOption.QueryMipsArchitecture);
            return value;
        }
    }

    /// <summary>
    ///     Determine if the PowerPC Architecture is Supported.
    /// </summary>
    /// <remarks>
    ///     Indicates if the PowerPC architecture is supported. A boolean true indicates it is supported. A
    ///     boolean false otherwise.
    /// </remarks>
    public static bool IsPowerPcSupported
    {
        get
        {
            bool value = NativeCapstone.Query(NativeQueryOption.QueryPowerPcArchitecture);
            return value;
        }
    }

    /// <summary>
    ///     Determine if the SPARC Architecture is Supported.
    /// </summary>
    /// <remarks>
    ///     Indicates if the SPARC architecture is supported. A boolean true indicates it is supported. A boolean
    ///     false otherwise.
    /// </remarks>
    internal static bool IsSparcSupported
    {
        get
        {
            bool value = NativeCapstone.Query(NativeQueryOption.QuerySparcArchitecture);
            return value;
        }
    }

    /// <summary>
    ///     Determine if the SystemZ Architecture is Supported.
    /// </summary>
    /// <remarks>
    ///     Indicates if the SystemZ architecture is supported. A boolean true indicates it is supported. A
    ///     boolean false otherwise.
    /// </remarks>
    internal static bool IsSystemZSupported
    {
        get
        {
            bool value = NativeCapstone.Query(NativeQueryOption.QuerySystemZArchitecture);
            return value;
        }
    }

    /// <summary>
    ///     Determine if the TMS320C64X Architecture is Supported.
    /// </summary>
    /// <remarks>
    ///     Indicates if the TMS320C64X architecture is supported. A boolean true indicates it is supported. A
    ///     boolean false otherwise.
    /// </remarks>
    internal static bool IsTms320C64XSupported
    {
        get
        {
            bool value = NativeCapstone.Query(NativeQueryOption.QueryTms320C64XArchitecture);
            return value;
        }
    }

    /// <summary>
    ///     Determine if X86 Reduce Mode is Enabled.
    /// </summary>
    /// <remarks>
    ///     Indicates if X86 Reduce Mode is enabled. A boolean true indicates it is enabled. A boolean false
    ///     otherwise.
    /// </remarks>
    public static bool IsX86ReduceModeEnabled
    {
        get
        {
            bool value = NativeCapstone.Query(NativeQueryOption.QueryX86ReduceMode);
            return value;
        }
    }

    /// <summary>
    ///     Determine if the X86 Architecture is Supported.
    /// </summary>
    /// <remarks>
    ///     Indicates if the X86 architecture is supported. A boolean true indicates it is supported. A boolean
    ///     false otherwise.
    /// </remarks>
    public static bool IsX86Supported
    {
        get
        {
            bool value = NativeCapstone.Query(NativeQueryOption.QueryX86Architecture);
            return value;
        }
    }

    /// <summary>
    ///     Determine if the XCore Architecture is Supported.
    /// </summary>
    /// <remarks>
    ///     Indicates if the XCore architecture is supported. A boolean true indicates it is supported. A boolean
    ///     false otherwise.
    /// </remarks>
    public static bool IsXCoreSupported
    {
        get
        {
            bool value = NativeCapstone.Query(NativeQueryOption.QueryXCoreArchitecture);
            return value;
        }
    }

    /// <summary>
    ///     Get Capstone Library's Version.
    /// </summary>
    /// <value>
    ///     The Capstone library's version.
    /// </value>
    public static Version Version
    {
        get
        {
            Version value = NativeCapstone.GetVersion();
            return value;
        }
    }

    /// <summary>
    ///     Get Disassemble Architecture.
    /// </summary>
    /// <remarks>
    ///     Represents the disassembler's hardware architecture.
    /// </remarks>
    public abstract DisassembleArchitecture DisassembleArchitecture { get; }

    /// <summary>
    ///     Enable or Disable Instruction Details.
    /// </summary>
    /// <exception cref="Gee.External.Capstone.CapstoneException">
    ///     Thrown if the instruction details option could not be set.
    /// </exception>
    /// <exception cref="System.ObjectDisposedException">
    ///     Thrown if the disassembler is disposed.
    /// </exception>
    public abstract bool EnableInstructionDetails { get; set; }
    
    /// <summary>
    ///     Enable or Disable Skip Data Mode.
    /// </summary>
    /// <exception cref="Gee.External.Capstone.CapstoneException">
    ///     Thrown if the Skip Data Mode option could not be set.
    /// </exception>
    /// <exception cref="System.ObjectDisposedException">
    ///     Thrown if the disassembler is disposed.
    /// </exception>
    public abstract bool EnableSkipDataMode { get; set; }
    
    /// <summary>
    ///     Enable or Disable instruction mnemonic.
    /// </summary>
    public bool EnableInstructionMnemonics { get; set; } = true;
    
    /// <summary>
    ///     Enable or Disable instruction operands.
    /// </summary>
    public bool EnableInstructionOperands { get; set; } = true;
    
    /// <summary>
    ///     Get Disassembler's Handle.
    /// </summary>
    /// <remarks>
    ///     Represents the disassembler's native handle.
    /// </remarks>
    internal abstract NativeDisassemblerHandle Handle { get; }

    /// <summary>
    ///     Get Native Disassemble Mode.
    /// </summary>
    /// <remarks>
    ///     Represents the disassembler's native hardware mode.
    /// </remarks>
    internal abstract NativeDisassembleMode NativeDisassembleMode { get; }

    /// <summary>
    ///     Get and Set Skip Data Instruction Mnemonic.
    /// </summary>
    /// <exception cref="System.ArgumentNullException">
    ///     Thrown if the value is a null reference.
    /// </exception>
    /// <exception cref="System.ObjectDisposedException">
    ///     Thrown if the disassembler is disposed.
    /// </exception>
    public abstract string SkipDataInstructionMnemonic { get; set; }

    /// <summary>
    ///     Dispose Object.
    /// </summary>
    public abstract void Dispose();

    /// <summary>
    ///     Create an ARM64 Disassembler.
    /// </summary>
    /// <param name="disassembleMode">
    ///     The hardware mode for the disassembler to use.
    /// </param>
    /// <returns>
    ///     An ARM64 disassembler.
    /// </returns>
    /// <exception cref="Gee.External.Capstone.CapstoneException">
    ///     Thrown if a disassembler could not be created.
    /// </exception>
    /// <exception cref="System.OutOfMemoryException">
    ///     Thrown if sufficient memory cannot be allocated to perform the operation as a rare indication that the
    ///     system is under heavy load.
    /// </exception>
    public static CapstoneArm64Disassembler CreateArm64Disassembler(Arm64DisassembleMode disassembleMode)
    {
        return new CapstoneArm64Disassembler(disassembleMode);
    }

    /// <summary>
    ///     Create an ARM Disassembler.
    /// </summary>
    /// <param name="disassembleMode">
    ///     The hardware mode for the disassembler to use.
    /// </param>
    /// <returns>
    ///     An ARM disassembler.
    /// </returns>
    /// <exception cref="Gee.External.Capstone.CapstoneException">
    ///     Thrown if a disassembler could not be created.
    /// </exception>
    /// <exception cref="System.OutOfMemoryException">
    ///     Thrown if sufficient memory cannot be allocated to perform the operation as a rare indication that the
    ///     system is under heavy load.
    /// </exception>
    public static CapstoneArmDisassembler CreateArmDisassembler(ArmDisassembleMode disassembleMode)
    {
        return new CapstoneArmDisassembler(disassembleMode);
    }

    /// <summary>
    ///     Throw an Exception if Diet Mode is Enabled.
    /// </summary>
    /// <exception cref="System.NotSupportedException">
    ///     Thrown if Diet Mode is enabled.
    /// </exception>
    internal static void ThrowIfDietModeIsEnabled()
    {
        if (IsDietModeEnabled)
        {
            const string detailMessage = "An operation is not supported when Diet Mode is enabled.";
            throw new NotSupportedException(detailMessage);
        }
    }

    /// <summary>
    ///     Throw an Exception if a Value is a Null Reference.
    /// </summary>
    /// <typeparam name="T">
    ///     The type of the value.
    /// </typeparam>
    /// <param name="name">
    ///     The name of the parameter the value was passed as an argument to.
    /// </param>
    /// <param name="value">
    ///     The value.
    /// </param>
    /// <exception cref="System.ArgumentNullException">
    ///     Thrown if the value is a null reference.
    /// </exception>
    internal static void ThrowIfValueIsNullReference<T>(string name, T value) where T : class
    {
        if (value == null)
        {
            const string detailMessage = "A value cannot be a null reference.";
            throw new ArgumentNullException(name, detailMessage);
        }
    }
}

/// <summary>
///     Capstone Disassembler.
/// </summary>
/// <typeparam name="TDisassembleMode">
///     The type of the hardware mode for the disassembler to use.
/// </typeparam>
/// <typeparam name="TInstruction">
///     The type of the disassembled instructions.
/// </typeparam>
/// <typeparam name="TInstructionDetail">
///     The type of the instructions' details.
/// </typeparam>
/// <typeparam name="TInstructionGroup">
///     The type of the instructions' architecture specific instruction groups.
/// </typeparam>
/// <typeparam name="TInstructionGroupId">
///     The type of the instructions' architecture specific instruction group unique identifiers.
/// </typeparam>
/// <typeparam name="TInstructionId">
///     The type of the instructions' unique identifiers.
/// </typeparam>
/// <typeparam name="TRegister">
///     The type of the instructions' architecture specific registers.
/// </typeparam>
/// <typeparam name="TRegisterId">
///     The type of the instructions' architecture specific register unique identifiers.
/// </typeparam>
public abstract class CapstoneDisassembler<TDisassembleMode, TInstruction, TInstructionDetail, TInstructionGroup,
    TInstructionGroupId, TInstructionId, TRegister, TRegisterId> : CapstoneDisassembler
    where TDisassembleMode : Enum
    where TInstruction : Instruction<TInstruction, TInstructionDetail, TDisassembleMode, TInstructionGroup,
        TInstructionGroupId, TInstructionId, TRegister, TRegisterId>
    where TInstructionDetail : InstructionDetail<TInstructionDetail, TDisassembleMode, TInstructionGroup,
        TInstructionGroupId, TInstruction, TInstructionId, TRegister, TRegisterId>
    where TInstructionGroup : InstructionGroup<TInstructionGroupId>
    where TInstructionGroupId : Enum
    where TInstructionId : Enum
    where TRegister : Register<TRegisterId>
    where TRegisterId : Enum
{
    /// <summary>
    ///     Disassemble Architecture.
    /// </summary>
    private readonly DisassembleArchitecture _disassembleArchitecture;

    /// <summary>
    ///     Disassembler's Handle.
    /// </summary>
    private readonly NativeDisassemblerHandle _handle;

    /// <summary>
    ///     Disassemble Mode.
    /// </summary>
    private TDisassembleMode _disassembleMode;

    /// <summary>
    ///     Disassemble Syntax.
    /// </summary>
    private DisassembleSyntax _disassembleSyntax;

    /// <summary>
    ///     Enable Instruction Details Flag.
    /// </summary>
    private bool _enableInstructionDetails;

    /// <summary>
    ///     Enable Skip Data Mode Flag.
    /// </summary>
    private bool _enableSkipDataMode;

    /// <summary>
    ///     Native Disassemble Mode.
    /// </summary>
    private NativeDisassembleMode _nativeDisassembleMode;

    /// <summary>
    ///     Skip Data Callback.
    /// </summary>
    private Func<long, long> _skipDataCallback;

    /// <summary>
    ///     Skip Data Instruction Mnemonic.
    /// </summary>
    private string _skipDataInstructionMnemonic;

    /// <summary>
    ///     Create a Disassembler.
    /// </summary>
    /// <param name="disassembleArchitecture">
    ///     The hardware architecture for the disassembler to use.
    /// </param>
    /// <param name="disassembleMode">
    ///     The hardware mode for the disassembler to use.
    /// </param>
    /// <exception cref="Gee.External.Capstone.CapstoneException">
    ///     Thrown if a disassembler could not be created.
    /// </exception>
    /// <exception cref="System.ArgumentException">
    ///     Thrown if the disassemble architecture is invalid, or if the disassemble mode is invalid or
    ///     unsupported by the disassemble architecture.
    /// </exception>
    /// <exception cref="System.OutOfMemoryException">
    ///     Thrown if sufficient memory cannot be allocated to perform the operation as a rare indication that the
    ///     system is under heavy load.
    /// </exception>
    private protected CapstoneDisassembler(DisassembleArchitecture disassembleArchitecture,
        TDisassembleMode disassembleMode)
    {
        _disassembleArchitecture = disassembleArchitecture;
        _disassembleMode = disassembleMode;
        _disassembleSyntax = DisassembleSyntax.Intel;
        _skipDataInstructionMnemonic = ".byte";
        // ...
        //
        // ...
        _nativeDisassembleMode = CreateNativeDisassembleMode(this);
        // ...
        //
        // ...
        _handle = NativeCapstone.CreateDisassembler(_disassembleArchitecture, _nativeDisassembleMode);

        // <summary>
        //      Create Native Disassemble Mode.
        // </summary>
        NativeDisassembleMode CreateNativeDisassembleMode(
            CapstoneDisassembler<TDisassembleMode, TInstruction, TInstructionDetail, TInstructionGroup,
                TInstructionGroupId, TInstructionId, TRegister, TRegisterId> @this)
        {
            // ...
            //
            // This is an ugly operation but it is the only way I am familiar with to convert a <c>System.Enum</c> to
            // a 32-bit integer to pass to the Capstone API. It should be relatively quick since <c>System.Enum</c>
            // implements <c>System.IConvertible</c>.
            int cIDisassembleMode = Convert.ToInt32(@this._disassembleMode);
            return (NativeDisassembleMode) cIDisassembleMode;
        }
    }

    /// <summary>
    ///     Get Disassemble Architecture.
    /// </summary>
    /// <remarks>
    ///     Represents the disassembler's hardware architecture.
    /// </remarks>
    public override DisassembleArchitecture DisassembleArchitecture => _disassembleArchitecture;

    /// <summary>
    ///     Get and Set Disassemble Mode.
    /// </summary>
    /// <remarks>
    ///     Represents the disassembler's hardware mode.
    /// </remarks>
    /// <exception cref="Gee.External.Capstone.CapstoneException">
    ///     Thrown if the disassemble mode option could not be set.
    /// </exception>
    /// <exception cref="System.ObjectDisposedException">
    ///     Thrown if the disassembler handle is disposed.
    /// </exception>
    public TDisassembleMode DisassembleMode
    {
        get => _disassembleMode;
        set
        {
            // ...
            //
            // This is an ugly operation but it is the only way I am familiar with to convert a <c>System.Enum</c>
            // to a 32-bit integer to pass to the Capstone API. It should be relatively quick since
            // <c>System.Enum</c> implements <c>System.IConvertible</c>.
            int iDisassembleMode = Convert.ToInt32(value);
            NativeDisassembleMode disassembleMode = (NativeDisassembleMode) iDisassembleMode;

            // ..
            //
            // Throws an exception if the operation fails.
            NativeCapstone.SetDisassembleModeOption(_handle, disassembleMode);

            _disassembleMode = value;
            _nativeDisassembleMode = disassembleMode;
        }
    }

    /// <summary>
    ///     Get and Set Disassemble Syntax.
    /// </summary>
    /// <exception cref="Gee.External.Capstone.CapstoneException">
    ///     Thrown if the disassemble syntax option could not be set.
    /// </exception>
    /// <exception cref="System.ObjectDisposedException">
    ///     Thrown if the disassembler is disposed.
    /// </exception>
    public DisassembleSyntax DisassembleSyntax
    {
        get => _disassembleSyntax;
        set
        {
            // ..
            //
            // Throws an exception if the operation fails.
            const NativeDisassemblerOptionType optionType = NativeDisassemblerOptionType.SetSyntax;
            NativeDisassemblerOptionValue optionValue = (NativeDisassemblerOptionValue) value;
            NativeCapstone.SetDisassemblerOption(_handle, optionType, optionValue);

            _disassembleSyntax = value;
        }
    }

    /// <summary>
    ///     Enable or Disable Instruction Details.
    /// </summary>
    /// <exception cref="Gee.External.Capstone.CapstoneException">
    ///     Thrown if the instruction details option could not be set.
    /// </exception>
    /// <exception cref="System.ObjectDisposedException">
    ///     Thrown if the disassembler is disposed.
    /// </exception>
    public override bool EnableInstructionDetails
    {
        get => _enableInstructionDetails;
        set
        {
            // ..
            //
            // Throws an exception if the operation fails.
            const NativeDisassemblerOptionType optionType = NativeDisassemblerOptionType.SetInstructionDetails;
            NativeDisassemblerOptionValue optionValue =
                value ? NativeDisassemblerOptionValue.Enable : NativeDisassemblerOptionValue.Disable;
            NativeCapstone.SetDisassemblerOption(_handle, optionType, optionValue);

            _enableInstructionDetails = value;
        }
    }

    /// <summary>
    ///     Enable or Disable Skip Data Mode.
    /// </summary>
    /// <exception cref="Gee.External.Capstone.CapstoneException">
    ///     Thrown if the Skip Data Mode option could not be set.
    /// </exception>
    /// <exception cref="System.ObjectDisposedException">
    ///     Thrown if the disassembler is disposed.
    /// </exception>
    public override bool EnableSkipDataMode
    {
        get => _enableSkipDataMode;
        set
        {
            // ..
            //
            // Throws an exception if the operation fails.
            const NativeDisassemblerOptionType optionType = NativeDisassemblerOptionType.SetSkipData;
            NativeDisassemblerOptionValue optionValue =
                value ? NativeDisassemblerOptionValue.Enable : NativeDisassemblerOptionValue.Disable;
            NativeCapstone.SetDisassemblerOption(_handle, optionType, optionValue);

            _enableSkipDataMode = value;
        }
    }

    /// <summary>
    ///     Get Disassembler's Handle.
    /// </summary>
    /// <remarks>
    ///     Represents the disassembler's native handle.
    /// </remarks>
    internal override NativeDisassemblerHandle Handle => _handle;

    /// <summary>
    ///     Get Native Disassemble Mode.
    /// </summary>
    /// <remarks>
    ///     Represents the disassembler's native hardware mode.
    /// </remarks>
    internal override NativeDisassembleMode NativeDisassembleMode => _nativeDisassembleMode;

    /// <summary>
    ///     Get and Set Skip Data Callback.
    /// </summary>
    /// <exception cref="System.ObjectDisposedException">
    ///     Thrown if the disassembler is disposed.
    /// </exception>
    public Func<long, long> SkipDataCallback
    {
        get => _skipDataCallback;
        set
        {
            ThrowIfDisassemblerIsDisposed();
            _skipDataCallback = value;
        }
    }

    /// <summary>
    ///     Get and Set Skip Data Instruction Mnemonic.
    /// </summary>
    /// <exception cref="System.ArgumentNullException">
    ///     Thrown if the value is a null reference.
    /// </exception>
    /// <exception cref="System.ObjectDisposedException">
    ///     Thrown if the disassembler is disposed.
    /// </exception>
    public override string SkipDataInstructionMnemonic
    {
        get => _skipDataInstructionMnemonic;
        set
        {
            ThrowIfDisassemblerIsDisposed();
            ThrowIfValueIsNullReference(nameof(SkipDataInstructionMnemonic), value);

            _skipDataInstructionMnemonic = value;
        }
    }

    /// <summary>
    ///     Create an Instruction.
    /// </summary>
    /// <param name="hInstruction">
    ///     An instruction handle.
    /// </param>
    /// <returns>
    ///     An instruction.
    /// </returns>
    private protected abstract TInstruction CreateInstruction(NativeInstructionHandle hInstruction);

    /// <summary>
    ///     Disassemble Binary Code.
    /// </summary>
    /// <param name="binaryCode">
    ///     An array of bytes representing the binary code to disassemble.
    /// </param>
    /// <returns>
    ///     An array of disassembled instructions.
    /// </returns>
    /// <exception cref="System.ArgumentNullException">
    ///     Thrown if the binary code array is a null reference.
    /// </exception>
    /// <exception cref="System.ObjectDisposedException">
    ///     Thrown if the disassembler is disposed.
    /// </exception>
    public TInstruction[] Disassemble(byte[] binaryCode)
    {
        // ...
        //
        // Throws an exception if the operation fails.
        TInstruction[] instructions = Disassemble(binaryCode, 0X1000);
        return instructions;
    }

    /// <summary>
    ///     Disassemble Binary Code.
    /// </summary>
    /// <param name="binaryCode">
    ///     An array of bytes representing the binary code to disassemble.
    /// </param>
    /// <param name="startingAddress">
    ///     The address of the first instruction in the binary code array.
    /// </param>
    /// <param name="count">
    ///     The number of max instructions to disassemble.
    /// </param>
    /// <returns>
    ///     An array of disassembled instructions.
    /// </returns>
    /// <exception cref="System.ArgumentNullException">
    ///     Thrown if the binary code array is a null reference.
    /// </exception>
    /// <exception cref="System.ObjectDisposedException">
    ///     Thrown if the disassembler is disposed.
    /// </exception>
    public unsafe TInstruction[] Disassemble(ReadOnlySpan<byte> binaryCode, long startingAddress, int count = 0)
    {
        int binaryCodeLength = binaryCode.Length;
        
        // ...
        //
        // The Capstone API's iterative disassemble function has an interesting challenge when it is invoked with
        // Skip Data Mode enabled. Because it disassembles one instruction at a time, the binary code buffer that
        // it passes to the Skip Data Mode Callback is not the entire binary code buffer passed by the caller, but
        // rather only the slice that contains the identified invalid instruction. This makes it difficult for the
        // caller to perform any analysis in the Skip Data Mode Callback that might depend on inspecting the
        // entire binary code buffer. This isn't necessarily a deal breaker since a caller can work around this in
        // multiple ways.
        //
        // However, we'll do the hard work for the caller here and define the Skip Data Mode Callback as a proxy
        // closure that encloses over the entire binary code buffer and pass it to the actual callback defined
        // by the caller.
        NativeCapstone.SkipDataCallback callback = null;
        if (EnableSkipDataMode)
        {
            // ...
            //
            // Normally, delegates that are created for the purpose of being passed as function pointers to
            // unmanaged code, such as this Skip Data Mode Callback, need to be allocated using a method that
            // prevents them from being garbage collected. A delegate created as a local variable typically would
            // be a problem because it would go out of scope as soon as the function returns and thus be eligible
            // for garbage collection. A process crash is guaranteed if that happens while it is still referenced
            // by unmanaged code.
            //
            // However, because this method is an iterator method, when the compiler compiles it it will actually
            // create a new class for the iterator's state machine and every local variable defined will become a
            // private field defined by this new class, whose lifetime is actually tied to the lifetime of the
            // class. So the problem of garbage collection is actually avoided for the lifetime of the iterator.
            //
            // To make this work though, we MUST define a local variable for the delegate!
            if (_skipDataCallback != null) callback = OnNativeSkipDataCallback;

            // ...
            //
            // Throws an exception if the operation fails.
            NativeSkipDataOptionValue optionValue = new NativeSkipDataOptionValue();
            optionValue.Callback = callback;
            optionValue.InstructionMnemonic = _skipDataInstructionMnemonic;
            optionValue.State = IntPtr.Zero;
            NativeCapstone.SetSkipDataOption(_handle, ref optionValue);
        }

        LinkedList<TInstruction> instructions = new LinkedList<TInstruction>();

        try
        {
            // ...
            //
            // We allocate memory for one instruction and reuse it for every instruction in the binary code
            // buffer. Throws an exception if the operation fails.
            using (NativeInstructionHandle hInstruction = NativeCapstone.CreateInstruction(_handle))
            {
                fixed (byte* p = binaryCode)
                {
                    long address = startingAddress;

                    IntPtr current = (IntPtr) p;
                    IntPtr end = current + binaryCodeLength;
                    
                    nint remainingSize = binaryCode.Length;

                    while (current != end)
                    {
                        bool isDisassembled = NativeCapstoneImport.Iterate(_handle, ref Unsafe.As<IntPtr, byte>(ref current), ref remainingSize, ref address, hInstruction);
                        
                        if (!isDisassembled)
                            break;

                        TInstruction instruction = CreateInstruction(hInstruction);
                        
                        if (!instruction.IsSkippedData)
                            instructions.AddLast(instruction);
                        
                        if (count != 0 && instructions.Count >= count)
                            break;
                    }
                }
            }
        }
        finally
        {
            if (callback != null)
            {
                // ...
                //
                // Throws an exception if the operation fails. If the operation fails here, it could only be
                // because the disassembler is disposed, which will have no side effects if it happens here.
                NativeSkipDataOptionValue optionValue = new NativeSkipDataOptionValue();
                optionValue.Callback = null;
                optionValue.InstructionMnemonic = _skipDataInstructionMnemonic;
                optionValue.State = IntPtr.Zero;
                NativeCapstone.SetSkipDataOption(_handle, ref optionValue);
            }
        }
        
        return instructions.ToArray();

        // <summary>
        //      Native Skip Data Mode Callback.
        // </summary>
        IntPtr OnNativeSkipDataCallback(IntPtr cPBinaryCode, IntPtr cBinaryCodeSize, IntPtr cDataOffset, IntPtr pState)
        {
            // ...
            //
            // Normally, a closure enclosing over a variable modified from a loop, such as this method, is a
            // problem because the value of the variable is resolved at the time the closure is invoked and not
            // when the variable is captured. This can lead to unexpected behavior if the closure is invoked
            // outside the loop since the value of the captured variable will always be resolved to the last value
            // it was set to inside the loop.
            //
            // However, because this closure will always be invoked from inside a disassemble loop, and never from
            // outside of one, the variable value resolution behavior is exactly what we are looking for. We want
            // the Capstone API to invoke this callback with an updated value for the captured variable every
            // time!
            long cBytesToSkip = SkipDataCallback(binaryCodeLength - cBinaryCodeSize.ToInt64());
            return new IntPtr(cBytesToSkip);
        }
    }

    /// <summary>
    ///     Dispose Object.
    /// </summary>
    public override void Dispose()
    {
        // ...
        //
        // This operation is safe, even if it is invoked multiple times and the handle is already disposed.
        _handle.Dispose();
    }

    /// <summary>
    ///     Get an Instruction Group's Name.
    /// </summary>
    /// <param name="instructionGroupId">
    ///     An instruction group's unique identifier.
    /// </param>
    /// <returns>
    ///     The instruction group's name.
    /// </returns>
    /// <exception cref="System.ArgumentException">
    ///     Thrown if the instruction group's unique identifier is invalid.
    /// </exception>
    /// <exception cref="System.ObjectDisposedException">
    ///     Thrown if the disassembler is disposed.
    /// </exception>
    /// <exception cref="System.NotSupportedException">
    ///     Thrown if Diet Mode is enabled.
    /// </exception>
    public string GetInstructionGroupName(TInstructionGroupId instructionGroupId)
    {
        ThrowIfDisassemblerIsDisposed();
        ThrowIfDietModeIsEnabled();

        // ...
        //
        // This is an ugly operation but it is the only way I am familiar with to convert a <c>System.Enum</c> to
        // a 32-bit integer to pass to the Capstone API. It should be relatively quick since <c>System.Enum</c>
        // implements <c>System.IConvertible</c>.
        int iInstructionGroupId = Convert.ToInt32(instructionGroupId);

        // ...
        //
        // This operation will return a null reference if 1) the handle is disposed, 2) if diet mode is enabled,
        // or 3) if the register unique identifier is invalid. Unfortunately it does not differentiate between the
        // 3 conditions. However, because we already guarded against conditions 1 and 2, if it does return a null
        // reference, it must be because of condition 3.
        string instructionGroupName = NativeCapstone.GetInstructionGroupName(_handle, iInstructionGroupId);
        if (instructionGroupName == null)
        {
            const string detailMessage = "An instruction group unique identifier is invalid.";
            throw new ArgumentException(detailMessage, nameof(instructionGroupId));
        }

        return instructionGroupName;
    }

    /// <summary>
    ///     Get a Register's Name.
    /// </summary>
    /// <param name="registerId">
    ///     A register's unique identifier.
    /// </param>
    /// <returns>
    ///     The register's name.
    /// </returns>
    /// <exception cref="System.ArgumentException">
    ///     Thrown if the register's unique identifier is invalid.
    /// </exception>
    /// <exception cref="System.ObjectDisposedException">
    ///     Thrown if the disassembler is disposed.
    /// </exception>
    /// <exception cref="System.NotSupportedException">
    ///     Thrown if diet mode is enabled.
    /// </exception>
    public string GetRegisterName(TRegisterId registerId)
    {
        ThrowIfDisassemblerIsDisposed();
        ThrowIfDietModeIsEnabled();

        // ...
        //
        // This is an ugly operation but it is the only way I am familiar with to convert a <c>System.Enum</c> to
        // a 32-bit integer to pass to the Capstone API. It should be relatively quick since <c>System.Enum</c>
        // implements <c>System.IConvertible</c>.
        int iRegisterId = Convert.ToInt32(registerId);

        // ...
        //
        // This operation will return a null reference if 1) the handle is disposed, 2) if diet mode is enabled,
        // or 3) if the register unique identifier is invalid. Unfortunately it does not differentiate between the
        // 3 conditions. However, because we already guarded against conditions 1 and 2, if it does return a null
        // reference, it must be because of condition 3.
        string registerName = NativeCapstone.GetRegisterName(_handle, iRegisterId);
        if (registerName == null)
        {
            const string detailMessage = "A register unique identifier is invalid.";
            throw new ArgumentException(detailMessage, nameof(registerId));
        }

        return registerName;
    }

    /// <summary>
    ///     Disassemble Binary Code Iteratively.
    /// </summary>
    /// <param name="binaryCode">
    ///     An array of bytes representing the binary code to disassemble.
    /// </param>
    /// <returns>
    ///     A deferred collection of disassembled instructions.
    /// </returns>
    /// <exception cref="System.ArgumentNullException">
    ///     Thrown if the binary code array is a null reference.
    /// </exception>
    /// <exception cref="System.ObjectDisposedException">
    ///     Thrown if the disassembler is disposed.
    /// </exception>
    public IEnumerable<TInstruction> Iterate(byte[] binaryCode)
    {
        // ...
        //
        // Throws an exception if the operation fails.
        return Iterate(binaryCode, 0x1000);
    }

    /// <summary>
    ///     Disassemble Binary Code Iteratively.
    /// </summary>
    /// <param name="binaryCode">
    ///     An array of bytes representing the binary code to disassemble.
    /// </param>
    /// <param name="startingAddress">
    ///     The address of the first instruction in the binary code array.
    /// </param>
    /// <returns>
    ///     A deferred collection of disassembled instructions.
    /// </returns>
    /// <exception cref="System.ArgumentNullException">
    ///     Thrown if the binary code array is a null reference.
    /// </exception>
    /// <exception cref="System.ObjectDisposedException">
    ///     Thrown if the disassembler is disposed.
    /// </exception>
    public IEnumerable<TInstruction> Iterate(byte[] binaryCode, long startingAddress)
    {
        ThrowIfValueIsNullReference(nameof(binaryCode), binaryCode);

        int binaryCodeOffset = 0;

        // ...
        //
        // The Capstone API's iterative disassemble function has an interesting challenge when it is invoked with
        // Skip Data Mode enabled. Because it disassembles one instruction at a time, the binary code buffer that
        // it passes to the Skip Data Mode Callback is not the entire binary code buffer passed by the caller, but
        // rather only the slice that contains the identified invalid instruction. This makes it difficult for the
        // caller to perform any analysis in the Skip Data Mode Callback that might depend on inspecting the
        // entire binary code buffer. This isn't necessarily a deal breaker since a caller can work around this in
        // multiple ways.
        //
        // However, we'll do the hard work for the caller here and define the Skip Data Mode Callback as a proxy
        // closure that encloses over the entire binary code buffer and pass it to the actual callback defined
        // by the caller.
        NativeCapstone.SkipDataCallback callback = null;
        if (EnableSkipDataMode)
        {
            // ...
            //
            // Normally, delegates that are created for the purpose of being passed as function pointers to
            // unmanaged code, such as this Skip Data Mode Callback, need to be allocated using a method that
            // prevents them from being garbage collected. A delegate created as a local variable typically would
            // be a problem because it would go out of scope as soon as the function returns and thus be eligible
            // for garbage collection. A process crash is guaranteed if that happens while it is still referenced
            // by unmanaged code.
            //
            // However, because this method is an iterator method, when the compiler compiles it it will actually
            // create a new class for the iterator's state machine and every local variable defined will become a
            // private field defined by this new class, whose lifetime is actually tied to the lifetime of the
            // class. So the problem of garbage collection is actually avoided for the lifetime of the iterator.
            //
            // To make this work though, we MUST define a local variable for the delegate!
            if (_skipDataCallback != null) callback = OnNativeSkipDataCallback;

            // ...
            //
            // Throws an exception if the operation fails.
            NativeSkipDataOptionValue optionValue = new NativeSkipDataOptionValue();
            optionValue.Callback = callback;
            optionValue.InstructionMnemonic = _skipDataInstructionMnemonic;
            optionValue.State = IntPtr.Zero;
            NativeCapstone.SetSkipDataOption(_handle, ref optionValue);
        }

        try
        {
            // ...
            //
            // We allocate memory for one instruction and reuse it for every instruction in the binary code
            // buffer. Throws an exception if the operation fails.
            using (NativeInstructionHandle hInstruction = NativeCapstone.CreateInstruction(_handle))
            {
                while (!(binaryCodeOffset >= binaryCode.Length))
                {
                    // ...
                    //
                    // Throws an exception if the operation fails.
                    bool isDisassembled = NativeCapstone.Iterate(_handle, binaryCode, ref binaryCodeOffset,
                        ref startingAddress, hInstruction);
                    if (!isDisassembled) yield break;

                    TInstruction instruction = CreateInstruction(hInstruction);
                    yield return instruction;
                }
            }
        }
        finally
        {
            if (callback != null)
            {
                // ...
                //
                // Throws an exception if the operation fails. If the operation fails here, it could only be
                // because the disassembler is disposed, which will have no side effects if it happens here.
                NativeSkipDataOptionValue optionValue = new NativeSkipDataOptionValue();
                optionValue.Callback = null;
                optionValue.InstructionMnemonic = _skipDataInstructionMnemonic;
                optionValue.State = IntPtr.Zero;
                NativeCapstone.SetSkipDataOption(_handle, ref optionValue);
            }
        }

        // <summary>
        //      Native Skip Data Mode Callback.
        // </summary>
        IntPtr OnNativeSkipDataCallback(IntPtr cPBinaryCode, IntPtr cBinaryCodeSize, IntPtr cDataOffset, IntPtr pState)
        {
            // ...
            //
            // Normally, a closure enclosing over a variable modified from a loop, such as this method, is a
            // problem because the value of the variable is resolved at the time the closure is invoked and not
            // when the variable is captured. This can lead to unexpected behavior if the closure is invoked
            // outside the loop since the value of the captured variable will always be resolved to the last value
            // it was set to inside the loop.
            //
            // However, because this closure will always be invoked from inside a disassemble loop, and never from
            // outside of one, the variable value resolution behavior is exactly what we are looking for. We want
            // the Capstone API to invoke this callback with an updated value for the captured variable every
            // time!
            long cBytesToSkip = SkipDataCallback(binaryCodeOffset);
            return new IntPtr(cBytesToSkip);
        }
    }

    /// <summary>
    ///     Reset an Instruction's Mnemonic.
    /// </summary>
    /// <param name="instructionId">
    ///     An instruction unique identifier.
    /// </param>
    /// <exception cref="Gee.External.Capstone.CapstoneException">
    ///     Thrown if the instruction mnemonic could not be reset.
    /// </exception>
    /// <exception cref="System.ObjectDisposedException">
    ///     Thrown if the disassembler is disposed.
    /// </exception>
    public void ResetInstructionMnemonic(TInstructionId instructionId)
    {
        // ...
        //
        // This is an ugly operation but it is the only way I am familiar with to convert a <c>System.Enum</c> to
        // a 32-bit integer to pass to the Capstone API. It should be relatively quick since <c>System.Enum</c>
        // implements <c>System.IConvertible</c>.
        int iInstructionId = Convert.ToInt32(instructionId);

        NativeInstructionMnemonicOptionValue optionValue = new NativeInstructionMnemonicOptionValue
        {
            InstructionId = iInstructionId,
            InstructionMnemonic = null
        };

        // ...
        //
        // Throws an exception if the operation fails.
        NativeCapstone.SetInstructionMnemonicOption(_handle, ref optionValue);
    }

    /// <summary>
    ///     Set an Instruction's Mnemonic.
    /// </summary>
    /// <param name="instructionId">
    ///     An instruction's unique identifier.
    /// </param>
    /// <param name="instructionMnemonic">
    ///     A mnemonic to associate with the instruction.
    /// </param>
    /// <exception cref="Gee.External.Capstone.CapstoneException">
    ///     Thrown if the instruction mnemonic could not be set.
    /// </exception>
    /// <exception cref="System.ArgumentNullException">
    ///     Thrown if the instruction mnemonic is a null reference.
    /// </exception>
    /// <exception cref="System.ObjectDisposedException">
    ///     Thrown if the disassembler is disposed.
    /// </exception>
    public void SetInstructionMnemonic(TInstructionId instructionId, string instructionMnemonic)
    {
        ThrowIfValueIsNullReference(nameof(instructionMnemonic), instructionMnemonic);

        // ...
        //
        // This is an ugly operation but it is the only way I am familiar with to convert a <c>System.Enum</c> to
        // a 32-bit integer to pass to the Capstone API. It should be relatively quick since <c>System.Enum</c>
        // implements <c>System.IConvertible</c>.
        int iInstructionId = Convert.ToInt32(instructionId);

        NativeInstructionMnemonicOptionValue optionValue = new NativeInstructionMnemonicOptionValue
        {
            InstructionId = iInstructionId,
            InstructionMnemonic = instructionMnemonic
        };

        // ...
        //
        // Throws an exception if the operation fails.
        NativeCapstone.SetInstructionMnemonicOption(_handle, ref optionValue);
    }

    /// <summary>
    ///     Throw an Exception if Disassembler is Disposed.
    /// </summary>
    /// <exception cref="System.ObjectDisposedException">
    ///     Thrown if the disassembler is disposed.
    /// </exception>
    private void ThrowIfDisassemblerIsDisposed()
    {
        if (_handle.IsClosed)
        {
            const string detailMessage = "A disassembler is disposed.";
            throw new ObjectDisposedException(nameof(CapstoneDisassembler), detailMessage);
        }
    }
}