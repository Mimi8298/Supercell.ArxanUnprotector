namespace Gee.External.Capstone;

using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

/// <summary>
///     Native Disassembled Instruction Details.
/// </summary>
[StructLayout(LayoutKind.Explicit)]
[SuppressMessage("ReSharper", "FieldCanBeMadeReadOnly.Global")]
[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
internal unsafe struct NativeInstructionDetail
{
    /// <summary>
    ///     Implicitly Read Registers.
    /// </summary>
    [FieldOffset(0)] public fixed short ImplicitlyReadRegisters[12];

    /// <summary>
    ///     Implicitly Read Registers' Count.
    /// </summary>
    [FieldOffset(24)] public byte ImplicitlyReadRegisterCount;

    /// <summary>
    ///     Implicitly Written Registers.
    /// </summary>
    [FieldOffset(26)] public fixed short ImplicitlyWrittenRegisters[20];

    /// <summary>
    ///     Implicitly Written Registers' Count.
    /// </summary>
    [FieldOffset(66)] public byte ImplicitlyWrittenRegisterCount;

    /// <summary>
    ///     Instruction's Groups.
    /// </summary>
    [FieldOffset(67)] public fixed byte Groups[8];

    /// <summary>
    ///     Instruction's Groups' Count.
    /// </summary>
    [FieldOffset(75)] public byte GroupCount;
}