#define CHECK_ARRAY_STRUCT_INDEX

namespace Gee.External.Capstone;

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

public interface IArray<T>
{
    public int Length { get; }
    public T this[int index] { get; set; }
}

public struct Array1<T> : IArray<T>
{
    internal T Reference;

    public int Length => 1;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 1u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 1u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array2<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array1<T> _others;
#pragma warning restore 169

    public int Length => 2;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 2u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 2u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array3<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array2<T> _others;
#pragma warning restore 169

    public int Length => 3;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 3u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 3u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array4<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array3<T> _others;
#pragma warning restore 169

    public int Length => 4;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 4u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 4u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array5<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array4<T> _others;
#pragma warning restore 169

    public int Length => 5;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 5u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 5u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array6<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array5<T> _others;
#pragma warning restore 169

    public int Length => 6;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 6u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 6u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array7<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array6<T> _others;
#pragma warning restore 169

    public int Length => 7;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 7u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 7u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array8<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array7<T> _others;
#pragma warning restore 169

    public int Length => 8;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 8u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 8u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array9<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array8<T> _others;
#pragma warning restore 169

    public int Length => 9;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 9u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 9u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array10<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array9<T> _others;
#pragma warning restore 169

    public int Length => 10;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 10u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 10u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array11<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array10<T> _others;
#pragma warning restore 169

    public int Length => 11;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 11u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 11u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array12<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array11<T> _others;
#pragma warning restore 169

    public int Length => 12;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 12u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 12u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array13<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array12<T> _others;
#pragma warning restore 169

    public int Length => 13;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 13u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 13u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array14<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array13<T> _others;
#pragma warning restore 169

    public int Length => 14;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 14u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 14u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array15<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array14<T> _others;
#pragma warning restore 169

    public int Length => 15;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 15u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 15u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array16<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array15<T> _others;
#pragma warning restore 169

    public int Length => 16;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 16u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 16u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array17<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array16<T> _others;
#pragma warning restore 169

    public int Length => 17;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 17u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 17u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array18<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array17<T> _others;
#pragma warning restore 169

    public int Length => 18;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 18u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 18u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array19<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array18<T> _others;
#pragma warning restore 169

    public int Length => 19;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 19u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 19u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array20<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array19<T> _others;
#pragma warning restore 169

    public int Length => 20;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 20u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 20u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array21<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array20<T> _others;
#pragma warning restore 169

    public int Length => 21;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 21u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 21u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array22<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array21<T> _others;
#pragma warning restore 169

    public int Length => 22;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 22u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 22u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array23<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array22<T> _others;
#pragma warning restore 169

    public int Length => 23;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 23u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 23u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array24<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array23<T> _others;
#pragma warning restore 169

    public int Length => 24;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 24u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 24u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array25<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array24<T> _others;
#pragma warning restore 169

    public int Length => 25;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 25u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 25u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array26<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array25<T> _others;
#pragma warning restore 169

    public int Length => 26;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 26u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 26u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array27<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array26<T> _others;
#pragma warning restore 169

    public int Length => 27;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 27u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 27u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array28<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array27<T> _others;
#pragma warning restore 169

    public int Length => 28;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 28u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 28u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array29<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array28<T> _others;
#pragma warning restore 169

    public int Length => 29;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 29u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 29u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array30<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array29<T> _others;
#pragma warning restore 169

    public int Length => 30;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 30u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 30u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array31<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array30<T> _others;
#pragma warning restore 169

    public int Length => 31;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 31u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 31u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array32<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array31<T> _others;
#pragma warning restore 169

    public int Length => 32;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 32u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 32u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array33<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array32<T> _others;
#pragma warning restore 169

    public int Length => 33;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 33u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 33u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array34<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array33<T> _others;
#pragma warning restore 169

    public int Length => 34;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 34u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 34u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array35<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array34<T> _others;
#pragma warning restore 169

    public int Length => 35;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 35u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 35u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array36<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array35<T> _others;
#pragma warning restore 169

    public int Length => 36;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 36u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 36u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array37<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array36<T> _others;
#pragma warning restore 169

    public int Length => 37;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 37u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 37u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array38<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array37<T> _others;
#pragma warning restore 169

    public int Length => 38;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 38u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 38u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array39<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array38<T> _others;
#pragma warning restore 169

    public int Length => 39;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 39u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 39u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array40<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array39<T> _others;
#pragma warning restore 169

    public int Length => 40;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 40u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 40u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array41<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array40<T> _others;
#pragma warning restore 169

    public int Length => 41;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 41u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 41u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array42<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array41<T> _others;
#pragma warning restore 169

    public int Length => 42;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 42u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 42u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array43<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array42<T> _others;
#pragma warning restore 169

    public int Length => 43;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 43u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 43u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array44<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array43<T> _others;
#pragma warning restore 169

    public int Length => 44;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 44u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 44u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array45<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array44<T> _others;
#pragma warning restore 169

    public int Length => 45;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 45u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 45u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array46<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array45<T> _others;
#pragma warning restore 169

    public int Length => 46;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 46u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 46u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array47<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array46<T> _others;
#pragma warning restore 169

    public int Length => 47;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 47u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 47u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array48<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array47<T> _others;
#pragma warning restore 169

    public int Length => 48;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 48u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 48u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array49<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array48<T> _others;
#pragma warning restore 169

    public int Length => 49;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 49u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 49u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array50<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array49<T> _others;
#pragma warning restore 169

    public int Length => 50;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 50u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 50u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array51<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array50<T> _others;
#pragma warning restore 169

    public int Length => 51;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 51u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 51u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array52<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array51<T> _others;
#pragma warning restore 169

    public int Length => 52;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 52u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 52u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array53<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array52<T> _others;
#pragma warning restore 169

    public int Length => 53;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 53u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 53u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array54<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array53<T> _others;
#pragma warning restore 169

    public int Length => 54;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 54u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 54u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array55<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array54<T> _others;
#pragma warning restore 169

    public int Length => 55;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 55u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 55u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array56<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array55<T> _others;
#pragma warning restore 169

    public int Length => 56;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 56u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 56u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array57<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array56<T> _others;
#pragma warning restore 169

    public int Length => 57;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 57u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 57u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array58<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array57<T> _others;
#pragma warning restore 169

    public int Length => 58;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 58u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 58u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array59<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array58<T> _others;
#pragma warning restore 169

    public int Length => 59;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 59u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 59u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array60<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array59<T> _others;
#pragma warning restore 169

    public int Length => 60;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 60u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 60u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array61<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array60<T> _others;
#pragma warning restore 169

    public int Length => 61;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 61u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 61u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array62<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array61<T> _others;
#pragma warning restore 169

    public int Length => 62;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 62u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 62u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array63<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array62<T> _others;
#pragma warning restore 169

    public int Length => 63;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 63u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 63u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array64<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array63<T> _others;
#pragma warning restore 169

    public int Length => 64;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 64u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 64u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array65<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array64<T> _others;
#pragma warning restore 169

    public int Length => 65;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 65u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 65u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array66<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array65<T> _others;
#pragma warning restore 169

    public int Length => 66;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 66u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 66u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array67<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array66<T> _others;
#pragma warning restore 169

    public int Length => 67;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 67u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 67u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array68<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array67<T> _others;
#pragma warning restore 169

    public int Length => 68;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 68u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 68u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array69<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array68<T> _others;
#pragma warning restore 169

    public int Length => 69;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 69u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 69u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array70<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array69<T> _others;
#pragma warning restore 169

    public int Length => 70;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 70u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 70u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array71<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array70<T> _others;
#pragma warning restore 169

    public int Length => 71;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 71u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 71u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array72<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array71<T> _others;
#pragma warning restore 169

    public int Length => 72;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 72u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 72u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array73<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array72<T> _others;
#pragma warning restore 169

    public int Length => 73;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 73u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 73u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array74<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array73<T> _others;
#pragma warning restore 169

    public int Length => 74;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 74u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 74u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array75<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array74<T> _others;
#pragma warning restore 169

    public int Length => 75;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 75u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 75u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array76<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array75<T> _others;
#pragma warning restore 169

    public int Length => 76;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 76u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 76u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array77<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array76<T> _others;
#pragma warning restore 169

    public int Length => 77;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 77u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 77u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array78<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array77<T> _others;
#pragma warning restore 169

    public int Length => 78;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 78u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 78u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array79<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array78<T> _others;
#pragma warning restore 169

    public int Length => 79;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 79u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 79u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array80<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array79<T> _others;
#pragma warning restore 169

    public int Length => 80;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 80u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 80u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array81<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array80<T> _others;
#pragma warning restore 169

    public int Length => 81;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 81u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 81u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array82<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array81<T> _others;
#pragma warning restore 169

    public int Length => 82;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 82u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 82u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array83<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array82<T> _others;
#pragma warning restore 169

    public int Length => 83;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 83u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 83u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array84<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array83<T> _others;
#pragma warning restore 169

    public int Length => 84;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 84u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 84u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array85<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array84<T> _others;
#pragma warning restore 169

    public int Length => 85;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 85u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 85u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array86<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array85<T> _others;
#pragma warning restore 169

    public int Length => 86;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 86u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 86u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array87<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array86<T> _others;
#pragma warning restore 169

    public int Length => 87;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 87u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 87u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array88<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array87<T> _others;
#pragma warning restore 169

    public int Length => 88;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 88u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 88u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array89<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array88<T> _others;
#pragma warning restore 169

    public int Length => 89;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 89u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 89u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array90<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array89<T> _others;
#pragma warning restore 169

    public int Length => 90;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 90u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 90u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array91<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array90<T> _others;
#pragma warning restore 169

    public int Length => 91;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 91u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 91u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array92<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array91<T> _others;
#pragma warning restore 169

    public int Length => 92;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 92u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 92u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array93<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array92<T> _others;
#pragma warning restore 169

    public int Length => 93;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 93u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 93u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array94<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array93<T> _others;
#pragma warning restore 169

    public int Length => 94;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 94u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 94u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array95<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array94<T> _others;
#pragma warning restore 169

    public int Length => 95;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 95u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 95u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array96<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array95<T> _others;
#pragma warning restore 169

    public int Length => 96;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 96u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 96u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array97<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array96<T> _others;
#pragma warning restore 169

    public int Length => 97;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 97u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 97u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array98<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array97<T> _others;
#pragma warning restore 169

    public int Length => 98;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 98u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 98u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array99<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array98<T> _others;
#pragma warning restore 169

    public int Length => 99;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 99u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 99u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array100<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array99<T> _others;
#pragma warning restore 169

    public int Length => 100;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 100u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 100u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array101<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array100<T> _others;
#pragma warning restore 169

    public int Length => 101;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 101u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 101u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array102<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array101<T> _others;
#pragma warning restore 169

    public int Length => 102;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 102u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 102u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array103<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array102<T> _others;
#pragma warning restore 169

    public int Length => 103;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 103u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 103u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array104<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array103<T> _others;
#pragma warning restore 169

    public int Length => 104;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 104u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 104u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array105<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array104<T> _others;
#pragma warning restore 169

    public int Length => 105;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 105u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 105u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array106<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array105<T> _others;
#pragma warning restore 169

    public int Length => 106;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 106u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 106u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array107<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array106<T> _others;
#pragma warning restore 169

    public int Length => 107;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 107u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 107u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array108<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array107<T> _others;
#pragma warning restore 169

    public int Length => 108;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 108u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 108u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array109<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array108<T> _others;
#pragma warning restore 169

    public int Length => 109;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 109u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 109u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array110<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array109<T> _others;
#pragma warning restore 169

    public int Length => 110;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 110u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 110u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array111<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array110<T> _others;
#pragma warning restore 169

    public int Length => 111;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 111u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 111u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array112<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array111<T> _others;
#pragma warning restore 169

    public int Length => 112;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 112u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 112u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array113<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array112<T> _others;
#pragma warning restore 169

    public int Length => 113;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 113u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 113u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array114<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array113<T> _others;
#pragma warning restore 169

    public int Length => 114;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 114u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 114u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array115<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array114<T> _others;
#pragma warning restore 169

    public int Length => 115;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 115u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 115u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array116<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array115<T> _others;
#pragma warning restore 169

    public int Length => 116;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 116u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 116u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array117<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array116<T> _others;
#pragma warning restore 169

    public int Length => 117;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 117u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 117u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array118<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array117<T> _others;
#pragma warning restore 169

    public int Length => 118;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 118u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 118u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array119<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array118<T> _others;
#pragma warning restore 169

    public int Length => 119;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 119u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 119u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array120<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array119<T> _others;
#pragma warning restore 169

    public int Length => 120;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 120u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 120u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array121<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array120<T> _others;
#pragma warning restore 169

    public int Length => 121;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 121u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 121u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array122<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array121<T> _others;
#pragma warning restore 169

    public int Length => 122;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 122u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 122u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array123<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array122<T> _others;
#pragma warning restore 169

    public int Length => 123;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 123u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 123u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array124<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array123<T> _others;
#pragma warning restore 169

    public int Length => 124;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 124u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 124u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array125<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array124<T> _others;
#pragma warning restore 169

    public int Length => 125;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 125u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 125u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array126<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array125<T> _others;
#pragma warning restore 169

    public int Length => 126;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 126u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 126u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array127<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array126<T> _others;
#pragma warning restore 169

    public int Length => 127;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 127u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 127u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array128<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array127<T> _others;
#pragma warning restore 169

    public int Length => 128;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 128u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 128u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array129<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array128<T> _others;
#pragma warning restore 169

    public int Length => 129;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 129u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 129u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array130<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array129<T> _others;
#pragma warning restore 169

    public int Length => 130;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 130u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 130u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array131<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array130<T> _others;
#pragma warning restore 169

    public int Length => 131;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 131u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 131u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array132<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array131<T> _others;
#pragma warning restore 169

    public int Length => 132;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 132u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 132u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array133<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array132<T> _others;
#pragma warning restore 169

    public int Length => 133;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 133u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 133u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array134<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array133<T> _others;
#pragma warning restore 169

    public int Length => 134;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 134u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 134u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array135<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array134<T> _others;
#pragma warning restore 169

    public int Length => 135;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 135u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 135u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array136<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array135<T> _others;
#pragma warning restore 169

    public int Length => 136;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 136u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 136u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array137<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array136<T> _others;
#pragma warning restore 169

    public int Length => 137;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 137u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 137u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array138<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array137<T> _others;
#pragma warning restore 169

    public int Length => 138;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 138u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 138u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array139<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array138<T> _others;
#pragma warning restore 169

    public int Length => 139;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 139u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 139u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array140<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array139<T> _others;
#pragma warning restore 169

    public int Length => 140;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 140u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 140u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array141<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array140<T> _others;
#pragma warning restore 169

    public int Length => 141;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 141u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 141u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array142<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array141<T> _others;
#pragma warning restore 169

    public int Length => 142;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 142u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 142u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array143<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array142<T> _others;
#pragma warning restore 169

    public int Length => 143;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 143u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 143u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array144<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array143<T> _others;
#pragma warning restore 169

    public int Length => 144;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 144u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 144u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array145<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array144<T> _others;
#pragma warning restore 169

    public int Length => 145;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 145u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 145u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array146<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array145<T> _others;
#pragma warning restore 169

    public int Length => 146;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 146u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 146u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array147<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array146<T> _others;
#pragma warning restore 169

    public int Length => 147;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 147u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 147u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array148<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array147<T> _others;
#pragma warning restore 169

    public int Length => 148;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 148u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 148u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array149<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array148<T> _others;
#pragma warning restore 169

    public int Length => 149;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 149u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 149u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array150<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array149<T> _others;
#pragma warning restore 169

    public int Length => 150;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 150u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 150u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array151<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array150<T> _others;
#pragma warning restore 169

    public int Length => 151;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 151u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 151u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array152<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array151<T> _others;
#pragma warning restore 169

    public int Length => 152;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 152u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 152u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array153<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array152<T> _others;
#pragma warning restore 169

    public int Length => 153;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 153u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 153u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array154<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array153<T> _others;
#pragma warning restore 169

    public int Length => 154;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 154u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 154u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array155<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array154<T> _others;
#pragma warning restore 169

    public int Length => 155;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 155u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 155u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array156<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array155<T> _others;
#pragma warning restore 169

    public int Length => 156;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 156u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 156u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array157<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array156<T> _others;
#pragma warning restore 169

    public int Length => 157;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 157u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 157u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array158<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array157<T> _others;
#pragma warning restore 169

    public int Length => 158;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 158u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 158u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array159<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array158<T> _others;
#pragma warning restore 169

    public int Length => 159;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 159u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 159u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array160<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array159<T> _others;
#pragma warning restore 169

    public int Length => 160;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 160u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 160u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array161<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array160<T> _others;
#pragma warning restore 169

    public int Length => 161;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 161u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 161u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array162<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array161<T> _others;
#pragma warning restore 169

    public int Length => 162;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 162u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 162u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array163<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array162<T> _others;
#pragma warning restore 169

    public int Length => 163;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 163u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 163u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array164<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array163<T> _others;
#pragma warning restore 169

    public int Length => 164;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 164u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 164u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array165<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array164<T> _others;
#pragma warning restore 169

    public int Length => 165;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 165u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 165u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array166<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array165<T> _others;
#pragma warning restore 169

    public int Length => 166;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 166u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 166u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array167<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array166<T> _others;
#pragma warning restore 169

    public int Length => 167;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 167u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 167u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array168<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array167<T> _others;
#pragma warning restore 169

    public int Length => 168;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 168u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 168u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array169<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array168<T> _others;
#pragma warning restore 169

    public int Length => 169;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 169u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 169u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array170<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array169<T> _others;
#pragma warning restore 169

    public int Length => 170;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 170u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 170u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array171<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array170<T> _others;
#pragma warning restore 169

    public int Length => 171;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 171u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 171u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array172<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array171<T> _others;
#pragma warning restore 169

    public int Length => 172;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 172u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 172u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array173<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array172<T> _others;
#pragma warning restore 169

    public int Length => 173;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 173u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 173u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array174<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array173<T> _others;
#pragma warning restore 169

    public int Length => 174;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 174u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 174u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array175<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array174<T> _others;
#pragma warning restore 169

    public int Length => 175;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 175u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 175u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array176<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array175<T> _others;
#pragma warning restore 169

    public int Length => 176;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 176u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 176u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array177<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array176<T> _others;
#pragma warning restore 169

    public int Length => 177;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 177u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 177u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array178<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array177<T> _others;
#pragma warning restore 169

    public int Length => 178;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 178u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 178u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array179<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array178<T> _others;
#pragma warning restore 169

    public int Length => 179;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 179u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 179u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array180<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array179<T> _others;
#pragma warning restore 169

    public int Length => 180;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 180u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 180u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array181<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array180<T> _others;
#pragma warning restore 169

    public int Length => 181;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 181u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 181u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array182<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array181<T> _others;
#pragma warning restore 169

    public int Length => 182;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 182u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 182u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array183<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array182<T> _others;
#pragma warning restore 169

    public int Length => 183;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 183u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 183u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array184<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array183<T> _others;
#pragma warning restore 169

    public int Length => 184;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 184u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 184u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array185<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array184<T> _others;
#pragma warning restore 169

    public int Length => 185;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 185u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 185u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array186<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array185<T> _others;
#pragma warning restore 169

    public int Length => 186;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 186u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 186u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array187<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array186<T> _others;
#pragma warning restore 169

    public int Length => 187;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 187u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 187u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array188<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array187<T> _others;
#pragma warning restore 169

    public int Length => 188;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 188u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 188u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array189<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array188<T> _others;
#pragma warning restore 169

    public int Length => 189;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 189u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 189u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array190<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array189<T> _others;
#pragma warning restore 169

    public int Length => 190;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 190u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 190u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array191<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array190<T> _others;
#pragma warning restore 169

    public int Length => 191;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 191u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 191u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array192<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array191<T> _others;
#pragma warning restore 169

    public int Length => 192;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 192u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 192u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array193<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array192<T> _others;
#pragma warning restore 169

    public int Length => 193;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 193u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 193u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array194<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array193<T> _others;
#pragma warning restore 169

    public int Length => 194;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 194u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 194u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array195<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array194<T> _others;
#pragma warning restore 169

    public int Length => 195;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 195u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 195u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array196<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array195<T> _others;
#pragma warning restore 169

    public int Length => 196;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 196u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 196u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array197<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array196<T> _others;
#pragma warning restore 169

    public int Length => 197;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 197u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 197u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array198<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array197<T> _others;
#pragma warning restore 169

    public int Length => 198;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 198u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 198u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array199<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array198<T> _others;
#pragma warning restore 169

    public int Length => 199;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 199u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 199u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public struct Array200<T> : IArray<T>
{
    internal T Reference;
#pragma warning disable 169
    private Array199<T> _others;
#pragma warning restore 169

    public int Length => 200;
#if DEBUG || CHECK_ARRAY_STRUCT_INDEX
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            if ((uint) index >= 200u)
                throw new System.IndexOutOfRangeException();
            return Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if ((uint) index >= 200u)
                throw new System.IndexOutOfRangeException();
            Unsafe.Add(ref Reference, index) = value;
        }
    }
#else
        public T this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => Unsafe.Add(ref Unsafe.AsRef(this).Reference, index);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Unsafe.Add(ref Reference, index) = value;
        }
#endif
}

public static class ArrayHelper
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array1<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array2<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array3<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array4<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array5<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array6<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array7<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array8<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array9<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array10<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array11<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array12<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array13<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array14<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array15<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array16<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array17<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array18<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array19<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array20<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array21<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array22<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array23<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array24<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array25<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array26<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array27<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array28<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array29<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array30<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array31<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array32<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array33<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array34<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array35<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array36<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array37<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array38<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array39<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array40<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array41<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array42<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array43<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array44<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array45<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array46<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array47<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array48<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array49<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array50<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array51<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array52<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array53<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array54<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array55<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array56<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array57<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array58<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array59<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array60<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array61<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array62<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array63<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array64<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array65<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array66<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array67<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array68<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array69<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array70<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array71<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array72<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array73<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array74<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array75<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array76<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array77<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array78<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array79<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array80<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array81<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array82<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array83<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array84<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array85<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array86<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array87<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array88<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array89<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array90<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array91<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array92<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array93<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array94<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array95<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array96<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array97<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array98<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array99<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array100<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array101<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array102<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array103<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array104<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array105<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array106<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array107<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array108<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array109<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array110<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array111<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array112<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array113<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array114<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array115<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array116<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array117<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array118<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array119<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array120<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array121<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array122<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array123<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array124<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array125<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array126<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array127<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array128<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array129<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array130<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array131<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array132<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array133<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array134<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array135<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array136<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array137<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array138<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array139<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array140<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array141<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array142<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array143<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array144<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array145<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array146<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array147<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array148<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array149<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array150<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array151<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array152<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array153<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array154<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array155<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array156<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array157<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array158<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array159<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array160<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array161<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array162<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array163<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array164<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array165<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array166<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array167<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array168<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array169<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array170<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array171<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array172<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array173<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array174<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array175<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array176<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array177<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array178<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array179<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array180<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array181<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array182<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array183<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array184<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array185<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array186<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array187<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array188<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array189<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array190<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array191<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array192<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array193<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array194<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array195<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array196<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array197<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array198<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array199<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetReference<T>(this ref Array200<T> array, int index) => ref Unsafe.Add(ref array.Reference, index);
}