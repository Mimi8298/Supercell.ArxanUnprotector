namespace Gee.External.Capstone;

using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

/// <summary>
///     Native Disassembled Instruction Mnemonic Option Value.
/// </summary>
[SuppressMessage("ReSharper", "FieldCanBeMadeReadOnly.Global")]
[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
[StructLayout(LayoutKind.Sequential)]
internal struct NativeInstructionMnemonicOptionValue
{
    /// <summary>
    ///     Instruction Unique Identifier.
    /// </summary>
    public int InstructionId;

    /// <summary>
    ///     Instruction Mnemonic.
    /// </summary>
    [MarshalAs(UnmanagedType.LPStr)] public string InstructionMnemonic;
}