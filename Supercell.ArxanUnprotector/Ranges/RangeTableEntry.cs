namespace Supercell.ArxanUnprotector.Ranges;

using Supercell.ArxanUnprotector;

public class RangeTableEntry
{
    public int Address { get; }
    public int Length { get; }
    
    public Library Library { get; }
    
    public RangeTableEntry(int address, int length, Library library)
    {
        Address = address;
        Length = length;
        Library = library;
    }

    public void CalculateChecksum(ref RangeTableChecksum checksum)
    {
        checksum.Calculate(Library.Take(Address), Length);
    }

    public override string ToString()
    {
        return $"RangeTableEntry({Address:x8}, {Length:x8})";
    }
}