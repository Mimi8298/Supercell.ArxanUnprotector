namespace Supercell.ArxanUnprotector.Actions;

using Supercell.ArxanUnprotector;
using Supercell.ArxanUnprotector.Ranges;
using Supercell.ArxanUnprotector.Strings;

public class EncryptStringsAction : IAction
{
    public string Execute(Library original, Library modified, string output)
    {
        if (original == null && modified == null)
            return "No input library provided.";
        if (original != null && modified != null)
            return "Cannot encrypt strings in both original and modified libraries";
        
        Library input = original ?? modified;

        RangeTable encryptedStringRangeTable = input.EncryptedStringRangeTable;
        EncryptedStringKey encryptedStringKey = input.EncryptedStringKey;
        
        if (encryptedStringRangeTable == null)
            return "No encrypted string ranges found";
        if (encryptedStringKey.Address == 0)
            return "No encrypted string key found";
        if (input.IsStringsEncrypted)
            return "Strings already encrypted";

        input.EncryptedStringKey.Randomize();
        input.EncryptStrings();
        input.Save(output);

        return null;
    }
}