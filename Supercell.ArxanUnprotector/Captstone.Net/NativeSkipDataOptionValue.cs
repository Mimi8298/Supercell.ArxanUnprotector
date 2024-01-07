namespace Gee.External.Capstone;

using System.Runtime.InteropServices;

/// <summary>
///     Native Skip Data Option Value.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
internal struct NativeSkipDataOptionValue
{
    /// <summary>
    ///     Instruction Mnemonic.
    /// </summary>
    [MarshalAs(UnmanagedType.LPStr)] public string InstructionMnemonic;
    [MarshalAs(UnmanagedType.FunctionPtr)] public NativeCapstone.SkipDataCallback Callback;

    public IntPtr State;
}