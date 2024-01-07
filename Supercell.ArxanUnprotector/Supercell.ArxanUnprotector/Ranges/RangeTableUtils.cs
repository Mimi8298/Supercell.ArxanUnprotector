namespace Supercell.ArxanUnprotector.Ranges;

using Supercell.ArxanUnprotector;

public static class RangeTableUtils
{
    public static bool TryReadRangeTable(Library library, int address, out RangeTable rangeTable)
    {
        if (address < 0 || address > library.MemorySize)
        {
            rangeTable = null;
            return false;
        }
        
        Span<byte> data = library.Take(address);
        int numEntries = 0;
        
        while (data.Length >= 20)
        {
            RangeTable.ParseRange(data, address, out int dataAddress, out int dataLength);

            if (dataLength == 0)
            {
                if (numEntries >= 5)
                {
                    rangeTable = new RangeTable(address, address + numEntries * RangeTable.EntrySize + 20, library);
                    return true;
                }
                
                rangeTable = null;
                return false;
            }

            if (dataAddress < 0 || dataAddress >= library.MemorySize)
            {
                rangeTable = null;
                return false;
            }

            if (dataLength < 0 || dataAddress + dataLength >= library.MemorySize)
            {
                rangeTable = null;
                return false;
            }

            data = data.Slice(RangeTable.EntrySize);
            numEntries++;
        }

        rangeTable = null;
        return false;
    }
}