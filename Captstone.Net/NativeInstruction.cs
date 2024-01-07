namespace Gee.External.Capstone;

using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

/// <summary>
///     Native Disassembled Instruction.
/// </summary>
[StructLayout(LayoutKind.Explicit, Size = 240)]
[SuppressMessage("ReSharper", "FieldCanBeMadeReadOnly.Global")]
[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
internal unsafe struct NativeInstruction
{
    public const int DetailsFieldOffset = 232;
    
    /// <summary>
    ///     Instruction's Unique Identifier.
    /// </summary>
    [FieldOffset(0)] public int Id;

    /// <summary>
    ///     Instruction's Address (EIP).
    /// </summary>
    [FieldOffset(8)] public long Address;

    /// <summary>
    ///     Instruction's Size.
    /// </summary>
    [FieldOffset(16)] public short Size;

    /// <summary>
    ///     Instruction's Machine Bytes.
    /// </summary>
    [FieldOffset(18)] public fixed byte Bytes[16];

    /// <summary>
    ///     Instruction's Mnemonic.
    /// </summary>
    [FieldOffset(34)] public fixed byte Mnemonic[32];

    /// <summary>
    ///     Instruction's Operand Text.
    /// </summary>
    [FieldOffset(66)] public fixed byte Operand[160];

    /// <summary>
    ///     Instruction's Details.
    /// </summary>
    /// <remarks>
    ///     Represents a pointer to the instruction's details in unmanaged memory. A <c>IntPtr.Zero</c> indicates
    ///     the instruction was disassembled without details.
    /// </remarks>
    [FieldOffset(DetailsFieldOffset)] public IntPtr Details;
}