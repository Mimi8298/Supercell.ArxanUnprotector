namespace Supercell.ArxanUnprotector.Actions;

using Supercell.ArxanUnprotector;
using Supercell.ArxanUnprotector.Ranges;

public class VerifyChecksumsAction : IAction
{
    public string Execute(Library original, Library modified, string output)
    {
        if (original == null)
            return "Original library required to verify checksums.";
        if (modified == null)
            return "No library chosen to verify checksums.";

        if (original.IsStringsEncrypted)
            original.DecryptStrings();
        if (modified.IsStringsEncrypted)
            modified.DecryptStrings();

        original.InvalidateCache();
        modified.InvalidateCache();

        return CheckChecksums(original, modified);
    }

    private string CheckChecksums(Library original, Library modified)
    {
        for (int i = 0; i < original.RangeTables.Count; i++)
        {
            RangeTable originalRangeTable = original.RangeTables[i];
            RangeTable modifiedRangeTable = modified.RangeTables.FirstOrDefault(t => t.StartAddress == originalRangeTable.StartAddress && t.EndAddress == originalRangeTable.EndAddress);

            if (modifiedRangeTable == null)
            {
                if (originalRangeTable.ChecksumLocations.Count == 0)
                    continue;
                
                return $"Range table not found in modified library. Start address: {originalRangeTable.StartAddress:X8}, End address: {originalRangeTable.EndAddress:X8}";
            }

            RangeTableChecksum checksum = modifiedRangeTable.Checksum;
            
            foreach (RangeTableChecksumLocation checksumLocation in originalRangeTable.ChecksumLocations)
            {
                string result = CheckChecksum(modified, modifiedRangeTable, checksumLocation.Key1, checksum.Key1) ??
                                CheckChecksum(modified, modifiedRangeTable, checksumLocation.Key2, checksum.Key2) ??
                                CheckChecksum(modified, modifiedRangeTable, checksumLocation.Key3, checksum.Key3);

                if (result != null)
                {
                    return result;
                }
            }
        }

        return null;
    }

    private string CheckChecksum(Library library, RangeTable rangeTable, int address, uint value)
    {
        uint writtenChecksum = BitConverter.ToUInt32(library.Take(address, 4));
        uint calculatedChecksum = value;
                
        if (calculatedChecksum != writtenChecksum)
        {
            return $"Checksum mismatch for range table {rangeTable.StartAddress:x8}. Written: {writtenChecksum:x8}, calculated: {calculatedChecksum:x8}";
        }
        else
        {
            Console.WriteLine("Checksum match for range table {0:x8}. Checksum: {1:x8}", rangeTable.StartAddress, calculatedChecksum);
        }
        
        return null;
    }
}