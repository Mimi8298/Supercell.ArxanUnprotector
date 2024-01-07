namespace Supercell.ArxanUnprotector.Strings;

using System.Security.Cryptography;
using Supercell.ArxanUnprotector;

public readonly struct EncryptedStringKey
{
    public int Address { get; }
    public int Size { get; }
    
    private readonly Library _library;
    
    public EncryptedStringKey(int address, int size, Library library)
    {
        _library = library;
        Address = address;
        Size = size;
    }

    public Span<byte> Content => _library.Take(Address, Size);
    
    public void Randomize()
    {
        RandomNumberGenerator.Fill(Content);
    }
}