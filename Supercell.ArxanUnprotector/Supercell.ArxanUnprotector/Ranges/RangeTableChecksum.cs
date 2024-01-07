namespace Supercell.ArxanUnprotector.Ranges;

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

public struct RangeTableChecksum
{
    public uint Key1 { get; set; }
    public uint Key2 { get; set; }
    public uint Key3 { get; set; }

    private uint _numBytes;
    private uint _previousKey3;
    private uint _debugValue;
    
    public void Calculate(ReadOnlySpan<byte> data, int length)
    {
        ref byte dataRef = ref MemoryMarshal.GetReference(data);

        for (int i = 0; i < length; i++)
        {
            int remaining = length - i;
            uint value;

            if (remaining > 4)
            {
                int index = i & 3;
                int baseIndex = i - index;

                value = Unsafe.As<byte, uint>(ref Unsafe.Add(ref dataRef, baseIndex));
                uint next = Unsafe.As<byte, uint>(ref Unsafe.Add(ref dataRef, baseIndex + 4));

                UpdateKey1(value, next, index);
            }
            else if (remaining == 4)
            {
                value = Unsafe.As<byte, uint>(ref Unsafe.Add(ref dataRef, i));

                UpdateKey1(value);
            }
            else
            {
                value = Unsafe.Add(ref dataRef, i);

                UpdateKey1(value);
            }

            if (i % 4 == 0 || remaining < 4)
                UpdateKey2(value);

            UpdateKey3(i);
            UpdateDebug();
        }
    }

    private void UpdateKey1(uint value, uint next, int index)
    {
        uint sum;

        if (index != 0)
        {
            int shift1 = index;
            int shift2 = (4 - index);

            shift1 <<= 3;
            shift2 <<= 3;

            uint value1 = (value >> shift1);
            uint value2 = (next << shift2);

            sum = value1 + value2;
        }
        else
        {
            sum = value;
        }

        UpdateKey1(sum);
    }

    private void UpdateKey1(uint value)
    {
        _numBytes++;
        Key1 += value;
    }

    public void UpdateKey2(uint value)
    {
        Key2 -= value;
    }

    private void UpdateKey3(int byteIndex)
    {
        uint tmp = (Key1 + Key2);

        tmp -= (uint) byteIndex + 1;
        tmp += Key3;

        _previousKey3 = Key3;
        Key3 = tmp;
    }

    private void UpdateDebug()
    {
        _debugValue = Key1 | _previousKey3;
    }
}