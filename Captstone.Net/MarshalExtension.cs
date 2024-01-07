namespace Gee.External.Capstone;

using System.Runtime.InteropServices;

/// <summary>
///     Marshal Extension.
/// </summary>
internal static class MarshalExtension
{
    /// <summary>
    ///     Allocate Memory For a Structure.
    /// </summary>
    /// <typeparam name="T">
    ///     The structure's type.
    /// </typeparam>
    /// <returns>
    ///     A pointer to the allocated memory.
    /// </returns>
    internal static IntPtr AllocHGlobal<T>()
    {
        int nType = SizeOf<T>();
        IntPtr pType = Marshal.AllocHGlobal(nType);

        return pType;
    }

    /// <summary>
    ///     Allocate Memory For a Structure.
    /// </summary>
    /// <param name="size">
    ///     The collection's size.
    /// </param>
    /// <typeparam name="T">
    ///     The structure's type.
    /// </typeparam>
    /// <returns>
    ///     A pointer to the allocated memory.
    /// </returns>
    internal static IntPtr AllocHGlobal<T>(int size)
    {
        int nType = SizeOf<T>() * size;
        IntPtr pType = Marshal.AllocHGlobal(nType);

        return pType;
    }

    /// <summary>
    ///     Marshal a Pointer to a Structure and Free Memory.
    /// </summary>
    /// <typeparam name="T">
    ///     The destination structure's type.
    /// </typeparam>
    /// <param name="p">
    ///     The pointer to marshal.
    /// </param>
    /// <returns>
    ///     The destination structure.
    /// </returns>
    internal static T FreePtrToStructure<T>(IntPtr p)
    {
        object @struct = Marshal.PtrToStructure(p, typeof(T));
        Marshal.FreeHGlobal(p);

        return (T) @struct;
    }

    /// <summary>
    ///     Marshal a Pointer to a Structure.
    /// </summary>
    /// <typeparam name="T">
    ///     The destination structure's type.
    /// </typeparam>
    /// <param name="p">
    ///     The pointer to marshal.
    /// </param>
    /// <returns>
    ///     The destination structure.
    /// </returns>
    internal static T PtrToStructure<T>(IntPtr p)
    {
        object @struct = Marshal.PtrToStructure(p, typeof(T));
        return (T) @struct;
    }

    /// <summary>
    ///     Marshal a Pointer to a Collection of Structures.
    /// </summary>
    /// <typeparam name="T">
    ///     The collection's type.
    /// </typeparam>
    /// <param name="p">
    ///     A pointer to a collection. The pointer should be initialized to the collection's starting address.
    /// </param>
    /// <param name="size">
    ///     The collection's size.
    /// </param>
    /// <returns>
    ///     The destination collection.
    /// </returns>
    internal static T[] PtrToStructure<T>(IntPtr p, int size)
    {
        T[] array = new T[size];
        IntPtr index = p;
        for (int i = 0; i < size; i++)
        {
            T element = PtrToStructure<T>(index);
            array[i] = element;

            index += Marshal.SizeOf(typeof(T));
        }

        return array;
    }

    /// <summary>
    ///     Get a Type's Size.
    /// </summary>
    /// <typeparam name="T">
    ///     The type.
    /// </typeparam>
    /// <returns>
    ///     The type's size, in bytes.
    /// </returns>
    internal static int SizeOf<T>()
    {
        int size = Marshal.SizeOf(typeof(T));
        return size;
    }
}