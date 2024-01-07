namespace Gee.External.Capstone;

using Microsoft.Win32.SafeHandles;

/// <summary>
///     Native Disassembler Handle.
/// </summary>
internal sealed class NativeDisassemblerHandle : SafeHandleZeroOrMinusOneIsInvalid
{
    /// <summary>
    ///     Create a Native Disassembler Handle.
    /// </summary>
    /// <param name="pDisassembler">
    ///     A pointer to a disassembler.
    /// </param>
    internal NativeDisassemblerHandle(IntPtr pDisassembler) : base(true)
    {
        handle = pDisassembler;
    }

    /// <summary>
    ///     Release Handle.
    /// </summary>
    /// <returns>
    ///     A boolean true if the handle was released. A boolean false otherwise.
    /// </returns>
    protected override bool ReleaseHandle()
    {
        NativeCapstoneResultCode resultCode = NativeCapstoneImport.CloseDisassembler(ref handle);
        bool isHandleReleased = resultCode == NativeCapstoneResultCode.Ok;

        return isHandleReleased;
    }
}