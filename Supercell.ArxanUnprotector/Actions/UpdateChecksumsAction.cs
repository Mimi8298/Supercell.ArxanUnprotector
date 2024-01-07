namespace Supercell.ArxanUnprotector.Actions;

using Supercell.ArxanUnprotector;
using Supercell.ArxanUnprotector.Ranges;

public class UpdateChecksumsAction : IAction
{
    public string Execute(Library original, Library modified, string output)
    {
        if (original == null)
            return "Original library required to update checksums.";
        if (modified == null)
            return "No library chosen to update checksums.";

        bool originalStringsEncrypted = modified.IsStringsEncrypted;

        if (original.IsStringsEncrypted)
            original.DecryptStrings();
        if (modified.IsStringsEncrypted)
            modified.DecryptStrings();

        string result;
        bool hasChanged;
        do
        {
            original.InvalidateCache();
            modified.InvalidateCache();
            
            result = UpdateChecksums(original, modified, out hasChanged);
        } while (result == null && hasChanged);

        if (originalStringsEncrypted)
        {
            if (!modified.IsStringsEncrypted)
                modified.EncryptStrings();
        }
        
        modified.Save(output);

        return result;
    }

    private string UpdateChecksums(Library original, Library modified, out bool hasChanged)
    {
        hasChanged = false;

        for (int i = 0; i < original.RangeTables.Count; i++)
        {
            RangeTable originalRangeTable = original.RangeTables[i];
            RangeTable modifiedRangeTable = modified.RangeTables.FirstOrDefault(t => t.StartAddress == originalRangeTable.StartAddress && t.EndAddress == originalRangeTable.EndAddress);

            if (modifiedRangeTable == null)
            {
                if (originalRangeTable.ChecksumLocations.Count == 0)
                    continue;
                
                return $"Range table not found in modified library. Start address: {originalRangeTable.StartAddress:x8}, end address: {originalRangeTable.EndAddress:x8}, size: {originalRangeTable.Entries.Count}, entries: {string.Join(", ", originalRangeTable.Entries.Select(e => e.ToString()))}";
            }
            
            RangeTableChecksum checksum = modifiedRangeTable.Checksum;

            foreach (RangeTableChecksumLocation checksumLocation in originalRangeTable.ChecksumLocations)
            {
                string result = UpdateChecksum(modified, modifiedRangeTable, checksumLocation.Key1, checksum.Key1, ref hasChanged) ??
                                UpdateChecksum(modified, modifiedRangeTable, checksumLocation.Key2, checksum.Key2, ref hasChanged) ??
                                UpdateChecksum(modified, modifiedRangeTable, checksumLocation.Key3, checksum.Key3, ref hasChanged);

                if (result != null)
                {
                    return result;
                }
            }
        }

        return null;
    }

    private string UpdateChecksum(Library library, RangeTable rangeTable, int address, uint value, ref bool hasChanged)
    {
        uint writtenChecksum = BitConverter.ToUInt32(library.Take(address, 4));
        uint calculatedChecksum = value;

        if (calculatedChecksum != writtenChecksum)
        {
            Console.WriteLine("Checksum mismatch for range table {0:x8}: {1:x8}/{2:x8}. Updating...", rangeTable.StartAddress, value, writtenChecksum);
            BitConverter.TryWriteBytes(library.Take(address, 4), value);
            
            hasChanged = true;
        }
        else
        {
            Console.WriteLine("Checksum match for range table {0:x8}. Checksum: {1:x8}", rangeTable.StartAddress, calculatedChecksum);
        }
        
        return null;
    }
}