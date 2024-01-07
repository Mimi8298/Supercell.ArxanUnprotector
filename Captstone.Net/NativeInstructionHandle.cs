namespace Gee.External.Capstone;

using Microsoft.Win32.SafeHandles;

/// <summary>
///     Native Instruction Handle.
/// </summary>
internal sealed class NativeInstructionHandle : SafeHandleZeroOrMinusOneIsInvalid
{
    /// <summary>
    ///     Create an Instruction Handle.
    /// </summary>
    /// <param name="pInstruction">
    ///     A pointer to an instruction.
    /// </param>
    internal NativeInstructionHandle(IntPtr pInstruction, bool ownsHandle = true) : base(ownsHandle)
    {
        handle = pInstruction;
    }

    /// <summary>
    ///     Release Handle.
    /// </summary>
    /// <returns>
    ///     A boolean true if the handle was released. A boolean false otherwise.
    /// </returns>
    protected override bool ReleaseHandle()
    {
        NativeCapstoneImport.FreeInstructions(handle, (IntPtr) 1);
        handle = IntPtr.Zero;

        return true;
    }
}