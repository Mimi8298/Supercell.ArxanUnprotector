namespace Supercell.ArxanUnprotector.Ranges.Providers;

using System.Runtime.InteropServices;
using ELFSharp.ELF.Sections;
using SectionType = Supercell.ArxanUnprotector.SectionType;

public class GenericMemoryRangeTableProvider : IRangeTableProvider
{
    public Library Library { get; set; }

    public List<RangeTable> FindTables()
    {
        bool stringsEncrypted = Library.IsStringsEncrypted;

        if (!stringsEncrypted)
            Library.EncryptStrings();

        Span<byte> sectionData = Library.GetSection(SectionType.Data, out int sectionAddress);
        List<RangeTable> rangeTables = FindTablesImpl(sectionData, sectionAddress);

        if (!stringsEncrypted)
            Library.DecryptStrings();

        for (int i = rangeTables.Count - 1; i >= 0; i--)
        {
            RangeTable table = rangeTables[i];

            if (table.Entries.Count == 0 || table.Entries.Exists(e => e.Address < 0 || e.Length < 0 || e.Address + e.Length > Library.MemorySize))
            {
                Console.WriteLine($"Table {table.StartAddress:x8} has invalid entries");
                rangeTables.RemoveAt(i);
            }
        }
        
        return rangeTables;
    }

    private List<RangeTable> FindTablesImpl(ReadOnlySpan<byte> dataSection, int dataAddress)
    {
        if (dataSection.IsEmpty)
            return new List<RangeTable>();

        int dataEndAddress = Library.MemorySize;

        List<RangeTable> candidates = new List<RangeTable>();
        List<RangeTable> tables = new List<RangeTable>();

        while (dataSection.Length >= RangeTable.EntrySize + 8)
        {
            RangeTable.ParseRange(dataSection, dataAddress, out int rangeAddress2, out int rangeSize2);

            if (candidates.Count != 0)
            {
                for (int i = 0; i < candidates.Count; i++)
                {
                    RangeTable table = candidates[i];

                    if ((dataAddress - table.StartAddress) % 12 == 0)
                    {
                        RangeTable.ParseRange(dataSection, table.StartAddress, out int rangeAddress, out int rangeSize);

                        if (rangeSize == 0)
                        {
                            if (table.EndAddress - table.StartAddress >= RangeTable.EntrySize * 2)
                                tables.Add(table);

                            candidates.RemoveAt(i--);
                        }
                        else
                        {
                            bool addressOutOfRange = rangeAddress < 0 || rangeAddress >= dataEndAddress;
                            bool lengthOutOfRange = rangeSize < 0 || rangeAddress + rangeSize + 8 >= dataEndAddress;

                            if (addressOutOfRange || lengthOutOfRange)
                            {
                                candidates.RemoveAt(i--);
                                continue;
                            }

                            candidates[i] = new RangeTable(table.StartAddress, table.EndAddress + RangeTable.EntrySize, Library);
                        }
                    }
                }
            }
            else
            {
                if (rangeSize2 != 0)
                {
                    bool addressOutOfRange = rangeAddress2 < 0 || rangeAddress2 >= dataEndAddress;
                    bool lengthOutOfRange = rangeSize2 < 0 || rangeAddress2 + rangeSize2 + 8 >= dataEndAddress;

                    if (!addressOutOfRange && !lengthOutOfRange)
                    {
                        candidates.Add(new RangeTable(dataAddress, dataAddress + RangeTable.EntrySize + 20, Library));
                    }
                }
            }

            dataAddress += 4;
            dataSection = dataSection.Slice(4);
        }

        return tables;
    }
}