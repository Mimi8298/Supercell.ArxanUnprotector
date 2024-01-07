namespace Supercell.ArxanUnprotector.Disassembler.References;

public interface IReference
{
    int Address { get; }
    int DataAddress { get; }
    
    void RelocateTo(int newAddress);
}