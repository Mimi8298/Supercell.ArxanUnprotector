namespace Supercell.ArxanUnprotector.Ranges;

public readonly struct RangeTableChecksumLocation
{
    public int Key1 { get; }
    public int Key2 { get; }
    public int Key3 { get; }
    
    public RangeTableChecksumLocation(int key1, int key2, int key3)
    {
        Key1 = key1;
        Key2 = key2;
        Key3 = key3;
    }
}