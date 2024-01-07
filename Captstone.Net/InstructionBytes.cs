namespace Gee.External.Capstone;

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

public unsafe struct InstructionBytes
{
    private const int InstructionBytesCount = 8;
    
    private fixed byte _content[InstructionBytesCount];
    private readonly int _length;

    public InstructionBytes(ReadOnlySpan<byte> content)
    {
        if (content.Length > InstructionBytesCount)
        {
            throw new ArgumentOutOfRangeException(nameof(content));
        }

        _length = 0;

        foreach (byte b in content)
        {
            _content[_length++] = b;
        }
    }

    public InstructionBytes(byte* content, int length)
    {
        if (length > InstructionBytesCount)
        {
            throw new ArgumentOutOfRangeException(nameof(length));
        }

        _length = length;

        for (int i = 0; i < _length; i++)
        {
            _content[i] = content[i];
        }
    }

    public InstructionBytes(ref byte content, int length)
    {
        if (length > InstructionBytesCount)
        {
            throw new ArgumentOutOfRangeException(nameof(length));
        }

        _length = length;

        for (int i = 0; i < _length; i++)
        {
            _content[i] = content;
            content = ref Unsafe.Add(ref content, 1);
        }
    }

    public int Length => _length;
    public ReadOnlySpan<byte> Span => MemoryMarshal.CreateReadOnlySpan(ref _content[0], _length);
}