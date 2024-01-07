namespace Gee.External.Capstone;

using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

/// <summary>
///     Native Capstone.
/// </summary>
internal static class NativeCapstone
{
    private const int MagicInstructionArchitectureDetailsFieldOffset = 80;

    /// <summary>
    ///     Create a Native Capstone.
    /// </summary>
    static NativeCapstone()
    {
        LoadLibrary();
    }

    /// <summary>
    ///     Create a Disassembler.
    /// </summary>
    /// <param name="disassembleArchitecture">
    ///     The hardware architecture for the disassembler to use.
    /// </param>
    /// <param name="disassembleMode">
    ///     The hardware mode for the disassembler to use.
    /// </param>
    /// <returns>
    ///     A disassembler handle.
    /// </returns>
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
    internal static NativeDisassemblerHandle CreateDisassembler(DisassembleArchitecture disassembleArchitecture,
        NativeDisassembleMode disassembleMode)
    {
        IntPtr pDisassembler = IntPtr.Zero;
        NativeCapstoneResultCode resultCode =
            NativeCapstoneImport.CreateDisassembler(disassembleArchitecture, disassembleMode, ref pDisassembler);
        if (resultCode != NativeCapstoneResultCode.Ok)
        {
            if (resultCode == NativeCapstoneResultCode.UninitializedMemoryManagement)
            {
                const string detailMessage = "Memory Management is uninitialized.";
                throw new CapstoneException(detailMessage);
            }

            if (resultCode == NativeCapstoneResultCode.UnsupportedDisassembleArchitecture)
            {
                string detailMessage = $"A disassemble architecture ({disassembleArchitecture}) is invalid.";
                throw new ArgumentException(detailMessage, nameof(disassembleArchitecture));
            }

            if (resultCode == NativeCapstoneResultCode.UnsupportedDisassembleMode)
            {
                string detailMessage = $"A disassemble mode ({disassembleMode}) is invalid.";
                throw new ArgumentException(detailMessage, nameof(disassembleMode));
            }

            if (resultCode == NativeCapstoneResultCode.OutOfMemory)
            {
                const string detailMessage = "Sufficient memory could not be allocated.";
                throw new OutOfMemoryException(detailMessage);
            }
            else
            {
                const string detailMessage = "A disassembler could not be created.";
                throw new CapstoneException(detailMessage);
            }
        }

        NativeDisassemblerHandle hDisassembler = new NativeDisassemblerHandle(pDisassembler);
        return hDisassembler;
    }

    /// <summary>
    ///     Create an Instruction..
    /// </summary>
    /// <param name="hDisassembler">
    ///     A disassembler handle.
    /// </param>
    /// <returns>
    ///     An instruction handle.
    /// </returns>
    /// <exception cref="System.ObjectDisposedException">
    ///     Thrown if the disassembler handle is disposed.
    /// </exception>
    internal static NativeInstructionHandle CreateInstruction(NativeDisassemblerHandle hDisassembler)
    {
        // ...
        //
        // Throws an exception if the operation fails.
        IntPtr pInstruction = NativeCapstoneImport.CreateInstruction(hDisassembler);

        NativeInstructionHandle hInstruction = new NativeInstructionHandle(pInstruction);
        return hInstruction;
    }

    /// <summary>
    ///     Get an Instruction's Accessed Registers.
    /// </summary>
    /// <param name="hDisassembler">
    ///     A disassembler handle.
    /// </param>
    /// <param name="hInstruction">
    ///     An instruction handle.
    /// </param>
    /// <returns>
    ///     A 2-tuple, where the first item is an array of the instruction's read registers and the second item is
    ///     an array of the instruction's written registers.
    /// </returns>
    /// <exception cref="Gee.External.Capstone.CapstoneException">
    ///     Thrown if the instruction's accessed registers could not be retrieved.
    /// </exception>
    /// <exception cref="System.ArgumentException">
    ///     Thrown if the disassembler handle is invalid.
    /// </exception>
    /// <exception cref="System.InvalidOperationException">
    ///     Thrown if the instruction was disassembled when Instruction Details Mode was disabled, or if the
    ///     instruction was disassembled when Skip Data Mode was enabled.
    /// </exception>
    /// <exception cref="System.NotSupportedException">
    ///     Thrown if Diet Mode is enabled, or if the disassembler's hardware architecture does not support the
    ///     operation.
    /// </exception>
    /// <exception cref="System.ObjectDisposedException">
    ///     Thrown if the disassembler handle is disposed, or if the instruction handle is disposed.
    /// </exception>
    internal static unsafe void GetAccessedRegisters(NativeDisassemblerHandle hDisassembler,
        NativeInstructionHandle hInstruction, out short[] readRegisters, out short[] writtenRegisters)
    {
        // ...
        //
        // Throws an exception if the operation fails.
        short* pReadRegisters = stackalloc short[64];
        short* pWrittenRegisters = stackalloc short[64];
        
        byte readRegistersCount = 0;
        byte writtenRegistersCount = 0;
        NativeCapstoneResultCode resultCode = NativeCapstoneImport.GetAccessedRegisters(hDisassembler, hInstruction,
            (IntPtr) pReadRegisters, ref readRegistersCount, (IntPtr) pWrittenRegisters, ref writtenRegistersCount);
        if (resultCode != NativeCapstoneResultCode.Ok)
        {
            if ((int) resultCode == -1)
            {
                // ...
                //
                // For some reason, the Capstone API will return a <c>-1</c>, instead of a defined error code, if
                // the disassembler handle is invalid.
                string detailMessage = $"A disassembler handle ({nameof(hDisassembler)}) is invalid.";
                throw new ArgumentException(detailMessage, nameof(hDisassembler));
            }

            if (resultCode == NativeCapstoneResultCode.UnsupportedDisassembleArchitecture)
            {
                const string detailMessage = "A disassembler's hardware architecture is not supported.";
                throw new NotSupportedException(detailMessage);
            }

            if (resultCode == NativeCapstoneResultCode.UnSupportedDietModeOperation)
            {
                const string detailMessage = "An operation is not supported when diet mode is enabled.";
                throw new NotSupportedException(detailMessage);
            }

            if (resultCode == NativeCapstoneResultCode.UnsupportedInstructionDetail)
            {
                const string detailMessage = "An operation is not supported when instruction details are disabled.";
                throw new InvalidOperationException(detailMessage);
            }

            if (resultCode == NativeCapstoneResultCode.UnsupportedSkipDataModeOperation)
            {
                const string detailMessage = "An operation is not supported when skip-data mode is enabled.";
                throw new InvalidOperationException(detailMessage);
            }
            else
            {
                const string detailMessage = "An instruction's accessed registers could not be retrieved.";
                throw new CapstoneException(detailMessage);
            }
        }

        readRegisters = readRegistersCount == 0 ? Array.Empty<short>() : new short[readRegistersCount];
        writtenRegisters = writtenRegistersCount == 0 ? Array.Empty<short>() : new short[writtenRegistersCount];
        
        for (int i = 0; i < readRegistersCount; i++)
        {
            readRegisters[i] = pReadRegisters[i];
        }
        
        for (int i = 0; i < writtenRegistersCount; i++)
        {
            writtenRegisters[i] = pWrittenRegisters[i];
        }
    }

    /// <summary>
    ///     Get an Instruction.
    /// </summary>
    /// <param name="hInstruction">
    ///     An instruction handle.
    /// </param>
    /// <returns>
    ///     An instruction.
    /// </returns>
    internal static unsafe NativeInstruction GetInstruction(NativeInstructionHandle hInstruction)
    {
        IntPtr pInstruction = hInstruction.DangerousAddRefAndGetHandle();
        try
        {
            // ...
            //
            // Throws an exception if the operation fails.
            return Unsafe.ReadUnaligned<NativeInstruction>(pInstruction.ToPointer());
        }
        finally
        {
            hInstruction.DangerousRelease();
        }
    }

    /// <summary>
    ///     Get an Instruction's Details.
    /// </summary>
    /// <param name="hInstruction">
    ///     An instruction handle.
    /// </param>
    /// <returns>
    ///     The instruction's details. A null reference indicates the instruction was disassembled without
    ///     details.
    /// </returns>
    internal static unsafe NativeInstructionDetail? GetInstructionDetail(NativeInstructionHandle hInstruction)
    {
        IntPtr pInstruction = hInstruction.DangerousAddRefAndGetHandle();
        try
        {
            // ...
            //
            // First, we calculate the memory address of the <c>NativeInstruction.Details</c> field, which is
            // always relative to the memory address of its defining <c>NativeInstruction</c> structure. This is
            // NOT the actual memory address of the instruction's details.
            IntPtr pInstructionDetail = (IntPtr) ((long) pInstruction + NativeInstruction.DetailsFieldOffset);

            // ...
            //
            // Second, we read the value of the <c>NativeInstruction.Details</c> field, which IS the actual memory
            // address of the instruction's details. If the value is not equal to <c>IntPtr.Zero</c>, that indicates
            // the instruction was disassembled with details.
            IntPtr ppInstructionDetail = Marshal.ReadIntPtr(pInstructionDetail);
            NativeInstructionDetail? instructionDetail = null;
            if (ppInstructionDetail != IntPtr.Zero)
                instructionDetail = Unsafe.ReadUnaligned<NativeInstructionDetail>(ppInstructionDetail.ToPointer());

            return instructionDetail;
        }
        finally
        {
            hInstruction.DangerousRelease();
        }
    }

    /// <summary>
    ///     Get an Instruction's Details.
    /// </summary>
    /// <typeparam name="TInstructionDetail">
    ///     The type of the instruction's details.
    /// </typeparam>
    /// <param name="hInstruction">
    ///     An instruction handle.
    /// </param>
    /// <returns>
    ///     The instruction's details. A null reference indicates the instruction was disassembled without
    ///     details.
    /// </returns>
    internal static unsafe TInstructionDetail? GetInstructionDetail<TInstructionDetail>(NativeInstructionHandle hInstruction)
        where TInstructionDetail : struct
    {
        IntPtr pInstruction = hInstruction.DangerousAddRefAndGetHandle();
        try
        {
            // ...
            //
            // First, we calculate the memory address of the <c>NativeInstruction.Details</c> field, which is
            // always relative to the memory address of its defining <c>NativeInstruction</c> structure. This is
            // NOT the actual memory address of the instruction's details.
            IntPtr pInstructionDetail = (IntPtr) ((long) pInstruction + NativeInstruction.DetailsFieldOffset);

            // ...
            //
            // Second, we read the value of the <c>NativeInstruction.Details</c> field, which IS the actual memory
            // address of the instruction's details. If the value is not equal to <c>IntPtr.Zero</c>, that indicates
            // the instruction was disassembled with details.
            IntPtr ppInstructionDetail = Marshal.ReadIntPtr(pInstructionDetail);
            TInstructionDetail? instructionDetail = null;
            if (ppInstructionDetail != IntPtr.Zero)
            {
                // ...
                //
                // Fourth, we calculate the memory address of the instruction's architecture specific details,
                // which is always relative to the memory address of the instruction's details.
                IntPtr pArchInstructionDetail = ppInstructionDetail + MagicInstructionArchitectureDetailsFieldOffset;
                instructionDetail = Unsafe.ReadUnaligned<TInstructionDetail>(pArchInstructionDetail.ToPointer());
            }

            return instructionDetail;
        }
        finally
        {
            hInstruction.DangerousRelease();
        }
    }

    /// <summary>
    ///     Get an Instruction's Details.
    /// </summary>
    /// <param name="instruction">
    ///     An instruction.
    /// </param>
    /// <returns>
    ///     The instruction's details. A null reference indicates the instruction was disassembled without
    ///     details.
    /// </returns>
    internal static unsafe NativeInstructionDetail? GetInstructionDetail(ref NativeInstruction instruction)
    {
        NativeInstructionDetail? instructionDetails = null;
        if (instruction.Details != IntPtr.Zero)
        {
            // ...
            //
            // Throws an exception if the operation fails.
            IntPtr pInstructionDetails = instruction.Details;
            instructionDetails = Unsafe.ReadUnaligned<NativeInstructionDetail>(pInstructionDetails.ToPointer());
        }

        return instructionDetails;
    }

    /// <summary>
    ///     Get an Instruction's Architecture Specific Details.
    /// </summary>
    /// <typeparam name="TInstructionDetails">
    ///     The type of the instruction's architecture specific details.
    /// </typeparam>
    /// <param name="instruction">
    ///     An instruction.
    /// </param>
    /// <returns>
    ///     The instruction's architecture specific details. A null reference indicates the instruction was
    ///     disassembled without its details.
    /// </returns>
    internal static unsafe TInstructionDetails? GetInstructionDetail<TInstructionDetails>(ref NativeInstruction instruction)
        where TInstructionDetails : struct
    {
        TInstructionDetails? instructionDetails = null;
        if (instruction.Details != IntPtr.Zero)
        {
            // ...
            //
            // Throws an exception if the operation fails.
            IntPtr pInstructionDetails = instruction.Details + MagicInstructionArchitectureDetailsFieldOffset;
            instructionDetails = Unsafe.ReadUnaligned<TInstructionDetails>(pInstructionDetails.ToPointer());
        }

        return instructionDetails;
    }

    /// <summary>
    ///     Get an Instruction Group's Name.
    /// </summary>
    /// <param name="hDisassembler">
    ///     A disassembler handle.
    /// </param>
    /// <param name="instructionGroupId">
    ///     An instruction group's unique identifier.
    /// </param>
    /// <returns>
    ///     The instruction group's name. A null reference if the disassembler handle is invalid, or if the
    ///     instruction group's unique identifier is invalid.
    /// </returns>
    /// <exception cref="System.ObjectDisposedException">
    ///     Thrown if the disassembler handle is disposed.
    /// </exception>
    internal static unsafe string GetInstructionGroupName(NativeDisassemblerHandle hDisassembler,
        int instructionGroupId)
    {
        // ...
        //
        // Throws an exception if the operation fails.
        string instructionGroupName = null;
        IntPtr pInstructionGroupName = NativeCapstoneImport.GetInstructionGroupName(hDisassembler, instructionGroupId);
        if (pInstructionGroupName != IntPtr.Zero) instructionGroupName = new string((sbyte*) pInstructionGroupName);

        return instructionGroupName;
    }

    /// <summary>
    ///     Get a Register's Name.
    /// </summary>
    /// <param name="hDisassembler">
    ///     A disassembler handle.
    /// </param>
    /// <param name="registerId">
    ///     A register unique identifier.
    /// </param>
    /// <returns>
    ///     The register's name. A null reference if the disassembler handle is invalid, or if the register unique
    ///     identifier is invalid.
    /// </returns>
    /// <exception cref="System.ObjectDisposedException">
    ///     Thrown if the disassembler handle is disposed.
    /// </exception>
    internal static unsafe string GetRegisterName(NativeDisassemblerHandle hDisassembler, int registerId)
    {
        // ...
        //
        // Throws an exception if the operation fails.
        string registerName = null;
        IntPtr pRegisterName = NativeCapstoneImport.GetRegisterName(hDisassembler, registerId);
        if (pRegisterName != IntPtr.Zero) registerName = new string((sbyte*) pRegisterName);

        return registerName;
    }

    /// <summary>
    ///     Get Capstone Library's Version.
    /// </summary>
    /// <returns>
    ///     The Capstone library's version.
    /// </returns>
    internal static Version GetVersion()
    {
        int majorVersion = 0;
        int minorVersion = 0;
        NativeCapstoneImport.GetVersion(ref majorVersion, ref minorVersion);

        Version version = new Version(majorVersion, minorVersion);
        return version;
    }

    /// <summary>
    ///     Disassemble Binary Code Iteratively.
    /// </summary>
    /// <param name="hDisassembler">
    ///     A disassembler handle.
    /// </param>
    /// <param name="binaryCode">
    ///     A buffer indicating the binary code to disassemble.
    /// </param>
    /// <param name="binaryCodeOffset">
    ///     The index of the instruction to disassemble in the binary code buffer . If the instruction is
    ///     disassembled successfully, this value will be updated to reflect the index of the next instruction to
    ///     disassemble in the binary code buffer. If the updated value is less than the length of the binary code
    ///     buffer, you can safely invoke this method with the updated value to disassemble the next instruction.
    /// </param>
    /// <param name="address">
    ///     The address of the instruction. If the instruction is disassembled successfully, this value will be
    ///     updated to reflect the address of the next instruction to disassemble in the binary code buffer.
    /// </param>
    /// <param name="hInstruction">
    ///     An instruction handle.
    /// </param>
    /// <returns>
    ///     A boolean true if an instruction was disassembled successfully. A boolean false otherwise.
    /// </returns>
    /// <exception cref="System.ObjectDisposedException">
    ///     Thrown if the disassembler handle is disposed, or if the instruction handle is disposed.
    /// </exception>
    internal static bool Iterate(NativeDisassemblerHandle hDisassembler, byte[] binaryCode, ref int binaryCodeOffset,
        ref long address, NativeInstructionHandle hInstruction)
    {
        GCHandle hBinaryCode = GCHandle.Alloc(binaryCode, GCHandleType.Pinned);
        try
        {
            // ...
            //
            // First, we increment the pointer to the binary code buffer to the point to the address of the
            // instruction we want to disassemble.
            IntPtr pBinaryCode = hBinaryCode.AddrOfPinnedObject() + binaryCodeOffset;

            // ...
            //
            // Second, we calculate the size of the binary code buffer by decrementing the offset we incremented
            // by in the previous step.
            IntPtr binaryCodeSize = (IntPtr) binaryCode.Length - binaryCodeOffset;

            // ...
            //
            // Third, we save the address of the binary code buffer we will disassemble, so that we can later
            // compute a new offset, and disassemble the binary code. If an instruction was disassembled
            // successfully, the pointer to the binary code, the binary code size, and the starting address will
            // be updated by the Capstone API to reflect the address of the next instruction to disassemble in the
            // binary code buffer.
            //
            // Throws an exception if the operation fails.
            IntPtr initialPBinaryCode = pBinaryCode;
            bool isDisassembled = NativeCapstoneImport.Iterate(hDisassembler, ref Unsafe.As<IntPtr, byte>(ref pBinaryCode), ref binaryCodeSize,
                ref address, hInstruction);
            if (isDisassembled) // ...
                //
                // Fourth, we compute a new offset to indicate to the caller the next instruction to disassemble
                // in the binary code buffer.
                binaryCodeOffset += (int) ((long) pBinaryCode - (long) initialPBinaryCode);

            return isDisassembled;
        }
        finally
        {
            if (hBinaryCode.IsAllocated) hBinaryCode.Free();
        }
    }

    /// <summary>
    ///     Load Library.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         Loads the Capstone library in the address space of the calling process if, and only if, the target
    ///         .NET runtime this assembly is compiled for is .NET Framework 4.x. The .NET Framework runtime has
    ///         support for .NET assemblies compiled for an "Any CPU" platform, as opposed to an explicit x64 or
    ///         an x86 platform. When a process is executed, the .NET Framework runtime executes it as either an
    ///         x64 or an x86 process, depending on the host's platform. This introduces an interesting challenge
    ///         in that this assembly must either load either the x64 or x86 version of the Capstone library
    ///         depending on the calling process' platform.
    ///     </para>
    ///     <para>
    ///         Since the .NET Framework runtime supports only Windows, a Windows only API can be used to
    ///         conditionally load either the x64 or x86 version of the Capstone library depending on the calling
    ///         process' platform without sacrificing compatibility with other operating systems. To have any
    ///         impact, this method must be called before any function exported by the Capstone library is called,
    ///         ideally immediately when the calling process is first executed.
    ///     </para>
    ///     <para>
    ///         The .NET Core runtime does not have support for .NET assemblies compiled for an "Any CPU"
    ///         platform. When an assembly is deployed, it must explicitly specify either an x64 or x86 platform.
    ///         As such, there is no need to conditionally load either the x64 or x86 version of the Capstone
    ///         library since only the one that is compatible with the deployment platform will be supported.
    ///     </para>
    /// </remarks>
    [Conditional("NET40")]
    [Conditional("NET45")]
    internal static void LoadLibrary()
    {
        // ...
        //
        // Some error checking should probably be added here, to make sure the library was loaded correctly.
        // However, technically, if the library was not loaded correctly for whatever reason, there is very little
        // that can be done anyway and the process will crash either way.
        string platformDirectoryName = Environment.Is64BitProcess ? "x64" : "x86";
        string thisAssemblyDirectoryPath = AppDomain.CurrentDomain.BaseDirectory;
        string libraryFilePath = Path.Combine(thisAssemblyDirectoryPath, platformDirectoryName, "capstone.dll");
        NativeCapstoneImport.LoadLibrary(libraryFilePath);
    }

    /// <summary>
    ///     Query an Option.
    /// </summary>
    /// <param name="queryOption">
    ///     An option to query.
    /// </param>
    /// <returns>
    ///     A boolean true if the option is supported. A boolean false otherwise.
    /// </returns>
    internal static bool Query(NativeQueryOption queryOption)
    {
        bool isSupported = NativeCapstoneImport.Query(queryOption);
        return isSupported;
    }

    /// <summary>
    ///     Set Disassemble Mode Option.
    /// </summary>
    /// <param name="hDisassembler">
    ///     A disassembler handle.
    /// </param>
    /// <param name="disassembleMode">
    ///     A hardware mode for the disassembler to use.
    /// </param>
    /// <exception cref="Gee.External.Capstone.CapstoneException">
    ///     Thrown if the disassemble mode option could not be set.
    /// </exception>
    /// <exception cref="System.ArgumentException">
    ///     Thrown if the disassemble mode is invalid.
    /// </exception>
    /// <exception cref="System.ObjectDisposedException">
    ///     Thrown if the disassembler handle is disposed.
    /// </exception>
    internal static void SetDisassembleModeOption(NativeDisassemblerHandle hDisassembler,
        NativeDisassembleMode disassembleMode)
    {
        // ...
        //
        // Throws an exception if the operation fails.
        const NativeDisassemblerOptionType optionType = NativeDisassemblerOptionType.SetDisassembleMode;
        NativeCapstoneResultCode resultCode =
            NativeCapstoneImport.SetDisassemblerOption(hDisassembler, optionType, (IntPtr) disassembleMode);
        if (resultCode != NativeCapstoneResultCode.Ok)
        {
            if (resultCode == NativeCapstoneResultCode.InvalidOption)
            {
                string detailMessage = $"An option ({nameof(optionType)}) is invalid.";
                throw new ArgumentException(detailMessage, nameof(optionType));
            }
            else
            {
                string detailMessage = $"A disassembler option ({optionType}) could not be set.";
                throw new CapstoneException(detailMessage);
            }
        }
    }

    /// <summary>
    ///     Set a Disassembler Option.
    /// </summary>
    /// <param name="hDisassembler">
    ///     A disassembler handle.
    /// </param>
    /// <param name="optionType">
    ///     A type of option to set.
    /// </param>
    /// <param name="optionValue">
    ///     A value to set the option to.
    /// </param>
    /// <exception cref="Gee.External.Capstone.CapstoneException">
    ///     Thrown if the option could not be set.
    /// </exception>
    /// <exception cref="System.ArgumentException">
    ///     Thrown if the disassembler handle is invalid, or if the option is invalid.
    /// </exception>
    /// <exception cref="System.NotSupportedException">
    ///     Thrown if the option is equal to <see cref="NativeDisassemblerOptionType.SetSkipDataConfig" />.
    /// </exception>
    /// <exception cref="System.ObjectDisposedException">
    ///     Thrown if the disassembler handle is disposed.
    /// </exception>
    internal static void SetDisassemblerOption(NativeDisassemblerHandle hDisassembler,
        NativeDisassemblerOptionType optionType, NativeDisassemblerOptionValue optionValue)
    {
        if (optionType == NativeDisassemblerOptionType.SetSkipDataConfig)
        {
            string detailMessage = $"A disassembler option ({optionType}) is unsupported.";
            throw new NotSupportedException(detailMessage);
        }

        // ...
        //
        // Throws an exception if the operation fails.
        NativeCapstoneResultCode resultCode =
            NativeCapstoneImport.SetDisassemblerOption(hDisassembler, optionType, (IntPtr) optionValue);
        if (resultCode != NativeCapstoneResultCode.Ok)
        {
            if (resultCode == NativeCapstoneResultCode.InvalidHandle2)
            {
                string detailMessage = $"A disassembler handle ({nameof(hDisassembler)}) is invalid.";
                throw new ArgumentException(detailMessage, nameof(hDisassembler));
            }

            if (resultCode == NativeCapstoneResultCode.InvalidOption)
            {
                string detailMessage = $"An option ({nameof(optionType)}) is invalid.";
                throw new ArgumentException(detailMessage, nameof(optionType));
            }
            else
            {
                string detailMessage = $"A disassembler option ({optionType}) could not be set.";
                throw new CapstoneException(detailMessage);
            }
        }
    }

    /// <summary>
    ///     Set Disassembler Instruction Mnemonic Option.
    /// </summary>
    /// <param name="hDisassembler">
    ///     A disassembler handle.
    /// </param>
    /// <param name="optionValue">
    ///     A value to set the instruction mnemonic option to.
    /// </param>
    /// <exception cref="Gee.External.Capstone.CapstoneException">
    ///     Thrown if the instruction mnemonic option could not be set.
    /// </exception>
    /// <exception cref="System.ArgumentException">
    ///     Thrown if the disassembler handle is invalid.
    /// </exception>
    /// <exception cref="System.ObjectDisposedException">
    ///     Thrown if the disassembler handle is disposed.
    /// </exception>
    internal static void SetInstructionMnemonicOption(NativeDisassemblerHandle hDisassembler,
        ref NativeInstructionMnemonicOptionValue optionValue)
    {
        IntPtr pOptionValue = IntPtr.Zero;
        try
        {
            pOptionValue = MarshalExtension.AllocHGlobal<NativeInstructionMnemonicOptionValue>();
            Marshal.StructureToPtr(optionValue, pOptionValue, false);

            // ...
            //
            // Throws an exception if the operation fails.
            const NativeDisassemblerOptionType optionType = NativeDisassemblerOptionType.SetMnemonic;
            NativeCapstoneResultCode resultCode =
                NativeCapstoneImport.SetDisassemblerOption(hDisassembler, optionType, pOptionValue);
            if (resultCode != NativeCapstoneResultCode.Ok)
            {
                if (resultCode == NativeCapstoneResultCode.InvalidHandle2)
                {
                    string detailMessage = $"A disassembler handle ({nameof(hDisassembler)}) is invalid.";
                    throw new ArgumentException(detailMessage, nameof(hDisassembler));
                }
                else
                {
                    string detailMessage = $"A disassembler option ({optionType}) could not be set.";
                    throw new CapstoneException(detailMessage);
                }
            }
        }
        finally
        {
            if (pOptionValue != IntPtr.Zero) Marshal.FreeHGlobal(pOptionValue);
        }
    }

    internal static void SetSkipDataOption(NativeDisassemblerHandle hDisassembler,
        ref NativeSkipDataOptionValue optionValue)
    {
        IntPtr pOptionValue = IntPtr.Zero;
        try
        {
            pOptionValue = MarshalExtension.AllocHGlobal<NativeSkipDataOptionValue>();
            Marshal.StructureToPtr(optionValue, pOptionValue, false);

            // ...
            //
            // Throws an exception if the operation fails.
            const NativeDisassemblerOptionType optionType = NativeDisassemblerOptionType.SetSkipDataConfig;
            NativeCapstoneResultCode resultCode =
                NativeCapstoneImport.SetDisassemblerOption(hDisassembler, optionType, pOptionValue);
        }
        finally
        {
            if (pOptionValue != IntPtr.Zero) Marshal.FreeHGlobal(pOptionValue);
        }
    }

    /// <summary>
    ///     Skip Data Callback Delegate.
    /// </summary>
    /// <param name="pBinaryCode">
    ///     A pointer to a buffer indicating the binary code that is being disassembled.
    /// </param>
    /// <param name="binaryCodeSize">
    ///     A platform dependent integer indicating the size, in bytes, of the binary code buffer.
    /// </param>
    /// <param name="dataOffset">
    ///     A platform dependent integer indicating the 0-based offset of the encountered data in the binary code
    ///     buffer.
    /// </param>
    /// <param name="pState">
    ///     A pointer to an opaque data structure indicating custom state.
    /// </param>
    /// <returns>
    ///     A platform dependent integer indicating the number of bytes to skip, starting at the data offset, in
    ///     the binary code buffer. A <c>0</c> indicates the disassemble operation should terminate immediately.
    /// </returns>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate IntPtr SkipDataCallback(IntPtr pBinaryCode, IntPtr binaryCodeSize, IntPtr dataOffset, IntPtr pState);
}