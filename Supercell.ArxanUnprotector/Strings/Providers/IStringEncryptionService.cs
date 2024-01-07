namespace Supercell.ArxanUnprotector.Strings.Providers;

using Supercell.ArxanUnprotector.Ranges;

public interface IStringEncryptionService
{
    Library Library { set; }
    
    RangeTable FindStringTable();
    EncryptedStringKey FindKey();
    
    void Compute(Span<byte> bytes);
}