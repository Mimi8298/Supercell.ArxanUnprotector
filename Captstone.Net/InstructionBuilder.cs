namespace Gee.External.Capstone;

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

/// <summary>
///     Disassembled Instruction Builder.
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
/// <typeparam name="TId">
///     The type of the instruction's unique identifier.
/// </typeparam>
/// <typeparam name="TRegister">
///     The type of the instruction's architecture specific registers.
/// </typeparam>
/// <typeparam name="TRegisterId">
///     The type of the instruction's architecture specific register unique identifiers.
/// </typeparam>
internal abstract class InstructionBuilder<TDetail, TDisassembleMode, TGroup, TGroupId, TInstruction, TId, TRegister,
    TRegisterId>
    where TDetail : InstructionDetail<TDetail, TDisassembleMode, TGroup, TGroupId, TInstruction, TId, TRegister,
        TRegisterId>
    where TDisassembleMode : Enum
    where TGroup : InstructionGroup<TGroupId>
    where TGroupId : Enum
    where TInstruction : Instruction<TInstruction, TDetail, TDisassembleMode, TGroup, TGroupId, TId, TRegister,
        TRegisterId>
    where TId : Enum
    where TRegister : Register<TRegisterId>
    where TRegisterId : Enum
{
    /// <summary>
    ///     Create an Instruction Builder.
    /// </summary>
    internal InstructionBuilder()
    {
        Address = 0;
        Bytes = default;
        Details = null;
        Id = default;
        IsSkippedData = false;
        Mnemonic = null;
        Operand = null;
    }

    /// <summary>
    ///     Get and Set Instruction's Address (EIP).
    /// </summary>
    internal long Address { get; private set; }

    /// <summary>
    ///     Get and Set Instruction's Machine Bytes.
    /// </summary>
    internal InstructionBytes Bytes { get; private set; }

    /// <summary>
    ///     Get and Set Instruction's Details.
    /// </summary>
    internal TDetail Details { get; private set; }

    /// <summary>
    ///     Get and Set Instruction's Disassemble Architecture.
    /// </summary>
    internal DisassembleArchitecture DisassembleArchitecture { get; private set; }

    /// <summary>
    ///     Get and Set Instruction's Disassemble Mode.
    /// </summary>
    internal TDisassembleMode DisassembleMode { get; private set; }

    /// <summary>
    ///     Get and Set Instruction's Unique Identifier.
    /// </summary>
    internal TId Id { get; private set; }

    /// <summary>
    ///     Determine if Instruction is Skipped Data.
    /// </summary>
    internal bool IsSkippedData { get; private set; }

    /// <summary>
    ///     Get and Set Instruction's Mnemonic.
    /// </summary>
    internal string Mnemonic { get; private set; }

    /// <summary>
    ///     Get and Set Instruction's Operand Text.
    /// </summary>
    internal string Operand { get; private set; }

    /// <summary>
    ///     Build an Instruction.
    /// </summary>
    /// <param name="disassembler">
    ///     A disassembler.
    /// </param>
    /// <param name="hInstruction">
    ///     An instruction handle.
    /// </param>
    internal virtual unsafe void Build(CapstoneDisassembler disassembler, NativeInstructionHandle hInstruction)
    {
        // ...
        //
        // Throws an exception if the operation fails.
        NativeInstruction nativeInstruction = NativeCapstone.GetInstruction(hInstruction);

        Address = nativeInstruction.Address;
        DisassembleArchitecture = disassembler.DisassembleArchitecture;
        DisassembleMode = CreateDisassembleMode(disassembler.NativeDisassembleMode);
        Id = CreateId(nativeInstruction.Id);
        IsSkippedData = disassembler.EnableSkipDataMode && !(nativeInstruction.Id > 0);
        Mnemonic = !CapstoneDisassembler.IsDietModeEnabled && disassembler.EnableInstructionMnemonics ? new string((sbyte*) nativeInstruction.Mnemonic) : null;
        Operand = !CapstoneDisassembler.IsDietModeEnabled && disassembler.EnableInstructionOperands ? new string((sbyte*) nativeInstruction.Operand) : null;
        // ...
        //
        // ...
        SetBytes(this, ref nativeInstruction);
        SetDetails(this, disassembler, hInstruction, ref nativeInstruction);

        // <summary>
        //      Set Instruction's Machine Bytes.
        // </summary>
        static void SetBytes(
            InstructionBuilder<TDetail, TDisassembleMode, TGroup, TGroupId, TInstruction, TId, TRegister, TRegisterId>
                @this, ref NativeInstruction cNativeInstruction)
        {
            @this.Bytes = cNativeInstruction.Id >= 0 ? new InstructionBytes(ref cNativeInstruction.Bytes[0], cNativeInstruction.Size) : default;
        }

        // <summary>
        //      Set Instruction's Details.
        // </summary>
        static void SetDetails(
            InstructionBuilder<TDetail, TDisassembleMode, TGroup, TGroupId, TInstruction, TId, TRegister, TRegisterId>
                @this, CapstoneDisassembler cDisassembler, NativeInstructionHandle cHInstruction,
            ref NativeInstruction cNativeInstruction)
        {
            bool cHasDetails = cNativeInstruction.Details != IntPtr.Zero;
            bool cIsInstructionDetailsEnabled = cDisassembler.EnableInstructionDetails;
            @this.Details = null;
            if (cHasDetails && cIsInstructionDetailsEnabled && cNativeInstruction.Id > 0)
                @this.Details = @this.CreateDetails(cDisassembler, cHInstruction);
        }
    }

    /// <summary>
    ///     Create Instruction's Details.
    /// </summary>
    /// <param name="disassembler">
    ///     A disassembler.
    /// </param>
    /// <param name="hInstruction">
    ///     An instruction handle.
    /// </param>
    /// <returns>
    ///     The instruction's details.
    /// </returns>
    private protected abstract TDetail CreateDetails(CapstoneDisassembler disassembler,
        NativeInstructionHandle hInstruction);

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
    ///     Create Instruction's Unique Identifier.
    /// </summary>
    /// <param name="id">
    ///     An instruction's unique identifier.
    /// </param>
    /// <returns>
    ///     The instruction's unique identifier.
    /// </returns>
    private protected abstract TId CreateId(int id);
}