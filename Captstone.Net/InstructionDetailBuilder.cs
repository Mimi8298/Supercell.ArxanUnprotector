namespace Gee.External.Capstone;

/// <summary>
///     Disassembled Instruction Detail Builder.
/// </summary>
/// <typeparam name="TDetail">
///     The type of the instruction's details.
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
internal abstract class InstructionDetailBuilder<TDetail, TDisassembleMode, TGroup, TGroupId, TInstruction,
    TInstructionId, TRegister, TRegisterId>
    where TDetail : InstructionDetail<TDetail, TDisassembleMode, TGroup, TGroupId, TInstruction, TInstructionId,
        TRegister, TRegisterId>
    where TDisassembleMode : Enum
    where TGroup : InstructionGroup<TGroupId>
    where TGroupId : Enum
    where TInstruction : Instruction<TInstruction, TDetail, TDisassembleMode, TGroup, TGroupId, TInstructionId,
        TRegister, TRegisterId>
    where TInstructionId : Enum
    where TRegister : Register<TRegisterId>
    where TRegisterId : Enum
{
    /// <summary>
    ///     Get and Set All Read Registers.
    /// </summary>
    internal TRegister[] AllReadRegisters { get; private set; }

    /// <summary>
    ///     Get and Set All Written Registers.
    /// </summary>
    internal TRegister[] AllWrittenRegisters { get; private set; }

    /// <summary>
    ///     Get and Set Instruction's Disassemble Architecture.
    /// </summary>
    internal DisassembleArchitecture DisassembleArchitecture { get; private set; }

    /// <summary>
    ///     Get and Set Instruction's Disassemble Mode.
    /// </summary>
    internal TDisassembleMode DisassembleMode { get; private set; }

    /// <summary>
    ///     Get and Set Instruction's Groups.
    /// </summary>
    internal TGroup[] Groups { get; private set; }

    /// <summary>
    ///     Get and Set Implicitly Read Registers.
    /// </summary>
    internal TRegister[] ImplicitlyReadRegisters { get; private set; }

    /// <summary>
    ///     Get and Set Implicitly Written Registers.
    /// </summary>
    internal TRegister[] ImplicitlyWrittenRegisters { get; private set; }

    /// <summary>
    ///     Build an Instruction Detail.
    /// </summary>
    /// <param name="disassembler">
    ///     A disassembler.
    /// </param>
    /// <param name="hInstruction">
    ///     An instruction handle.
    /// </param>
    internal virtual void Build(CapstoneDisassembler disassembler, NativeInstructionHandle hInstruction)
    {
        // ...
        //
        // Throws an exception if the operation fails.
        NativeInstructionDetail nativeInstructionDetail =
            NativeCapstone.GetInstructionDetail(hInstruction).GetValueOrDefault();

        DisassembleArchitecture = disassembler.DisassembleArchitecture;
        DisassembleMode = CreateDisassembleMode(disassembler.NativeDisassembleMode);
        // ...
        //
        // ...
        SetAccessedRegisters(this, disassembler, hInstruction);
        SetGroups(this, disassembler, ref nativeInstructionDetail);
        SetImplicitlyReadRegisters(this, disassembler, ref nativeInstructionDetail);
        SetImplicitlyWrittenRegisters(this, disassembler, ref nativeInstructionDetail);

        // <summary>
        //      Set Accessed Registers.
        // </summary>
        void SetAccessedRegisters(
            InstructionDetailBuilder<TDetail, TDisassembleMode, TGroup, TGroupId, TInstruction, TInstructionId,
                TRegister, TRegisterId> @this, CapstoneDisassembler cDisassembler,
            NativeInstructionHandle cHInstruction)
        {
            @this.AllReadRegisters = Array.Empty<TRegister>();
            @this.AllWrittenRegisters = Array.Empty<TRegister>();
            
            if (!CapstoneDisassembler.IsDietModeEnabled)
            {
                bool isArchSupported = cDisassembler.DisassembleArchitecture != DisassembleArchitecture.M68K;
                isArchSupported = isArchSupported &&
                                  cDisassembler.DisassembleArchitecture != DisassembleArchitecture.Mips;
                isArchSupported = isArchSupported &&
                                  cDisassembler.DisassembleArchitecture != DisassembleArchitecture.PowerPc;
                isArchSupported = isArchSupported &&
                                  cDisassembler.DisassembleArchitecture != DisassembleArchitecture.XCore;
                if (isArchSupported)
                {
                    // ...
                    //
                    // Throws an exception if the operation fails.
                    NativeCapstone.GetAccessedRegisters(cDisassembler.Handle, cHInstruction, out short[] readRegisters, out short[] writtenRegisters);

                    @this.AllReadRegisters = new TRegister[readRegisters.Length];
                    for (int cI = 0; cI < @this.AllReadRegisters.Length; cI++)
                    {
                        short cExplicitlyReadRegister = readRegisters[cI];
                        @this.AllReadRegisters[cI] = @this.CreateRegister(cDisassembler, cExplicitlyReadRegister);
                    }

                    @this.AllWrittenRegisters = new TRegister[writtenRegisters.Length];
                    for (int cI = 0; cI < @this.AllWrittenRegisters.Length; cI++)
                    {
                        short cExplicitlyWrittenRegister = writtenRegisters[cI];
                        @this.AllWrittenRegisters[cI] = @this.CreateRegister(cDisassembler, cExplicitlyWrittenRegister);
                    }
                }
            }
        }

        // <summary>
        //      Set Instruction's Groups.
        // </summary>
        unsafe void SetGroups(
            InstructionDetailBuilder<TDetail, TDisassembleMode, TGroup, TGroupId, TInstruction, TInstructionId,
                TRegister, TRegisterId> @this, CapstoneDisassembler cDisassembler,
            ref NativeInstructionDetail cNativeInstructionDetail)
        {
            @this.Groups = new TGroup[cNativeInstructionDetail.GroupCount];
            if (!CapstoneDisassembler.IsDietModeEnabled)
                for (int cI = 0; cI < @this.Groups.Length; cI++)
                {
                    byte cGroup = cNativeInstructionDetail.Groups[cI];
                    @this.Groups[cI] = @this.CreateInstructionGroup(cDisassembler, cGroup);
                }
        }

        // <summary>
        //      Set Implicitly Read Registers.
        // </summary>
        unsafe void SetImplicitlyReadRegisters(
            InstructionDetailBuilder<TDetail, TDisassembleMode, TGroup, TGroupId, TInstruction, TInstructionId,
                TRegister, TRegisterId> @this, CapstoneDisassembler cDisassembler,
            ref NativeInstructionDetail cNativeInstructionDetail)
        {
            @this.ImplicitlyReadRegisters = new TRegister[cNativeInstructionDetail.ImplicitlyReadRegisterCount];
            if (!CapstoneDisassembler.IsDietModeEnabled)
                for (int cI = 0; cI < @this.ImplicitlyReadRegisters.Length; cI++)
                {
                    short cImplicitlyReadRegister = cNativeInstructionDetail.ImplicitlyReadRegisters[cI];
                    @this.ImplicitlyReadRegisters[cI] = @this.CreateRegister(cDisassembler, cImplicitlyReadRegister);
                }
        }

        // <summary>
        //      Set Implicitly Written Registers.
        // </summary>
        unsafe void SetImplicitlyWrittenRegisters(
            InstructionDetailBuilder<TDetail, TDisassembleMode, TGroup, TGroupId, TInstruction, TInstructionId,
                TRegister, TRegisterId> @this, CapstoneDisassembler cDisassembler,
            ref NativeInstructionDetail cNativeInstructionDetail)
        {
            @this.ImplicitlyWrittenRegisters = new TRegister[cNativeInstructionDetail.ImplicitlyWrittenRegisterCount];
            if (!CapstoneDisassembler.IsDietModeEnabled)
                for (int cI = 0; cI < @this.ImplicitlyWrittenRegisters.Length; cI++)
                {
                    short cImplicitlyWrittenRegister = cNativeInstructionDetail.ImplicitlyWrittenRegisters[cI];
                    @this.ImplicitlyWrittenRegisters[cI] =
                        @this.CreateRegister(cDisassembler, cImplicitlyWrittenRegister);
                }
        }
    }

    /// <summary>
    ///     Create Disassemble Mode.
    /// </summary>
    /// <param name="nativeDisassembleMode">
    ///     A native disassemble mode.
    /// </param>
    /// <returns>
    ///     A disassemble mode.
    /// </returns>
    private protected abstract TDisassembleMode CreateDisassembleMode(NativeDisassembleMode nativeDisassembleMode);

    /// <summary>
    ///     Create an Instruction Group.
    /// </summary>
    /// <param name="disassembler">
    ///     A disassembler.
    /// </param>
    /// <param name="instructionGroupId">
    ///     An instruction group's unique identifier.
    /// </param>
    /// <returns>
    ///     An instruction group.
    /// </returns>
    private protected abstract TGroup
        CreateInstructionGroup(CapstoneDisassembler disassembler, byte instructionGroupId);

    /// <summary>
    ///     Create a Register.
    /// </summary>
    /// <param name="disassembler">
    ///     A disassembler.
    /// </param>
    /// <param name="registerId">
    ///     A register's unique identifier.
    /// </param>
    /// <returns>
    ///     A register.
    /// </returns>
    private protected abstract TRegister CreateRegister(CapstoneDisassembler disassembler, short registerId);
}