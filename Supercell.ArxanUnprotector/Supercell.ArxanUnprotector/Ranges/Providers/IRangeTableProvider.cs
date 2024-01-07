namespace Supercell.ArxanUnprotector.Ranges.Providers;

public interface IRangeTableProvider
{
    Library Library { set; }
    List<RangeTable> FindTables();
}