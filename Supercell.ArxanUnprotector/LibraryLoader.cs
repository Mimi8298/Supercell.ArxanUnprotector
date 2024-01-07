namespace Supercell.ArxanUnprotector;

using ELFSharp.ELF;

public static class LibraryLoader
{
    public static Library Load(string path)
    {
        if (path.EndsWith(".so"))
            return ELFReader.CheckELFType(path) == Class.Bit64 ? new Android64Library(path) : new AndroidLibrary(path);

        return new iOS64Library(path);
    }
}