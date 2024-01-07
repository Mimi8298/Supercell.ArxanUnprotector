using Supercell.ArxanUnprotector;
using Supercell.ArxanUnprotector.Actions;

Dictionary<string, string> arguments = ParseArguments(args);

string original = arguments.GetValueOrDefault("-i");
string modified = arguments.GetValueOrDefault("-m");
string output = arguments.GetValueOrDefault("-o", modified);

IAction action = arguments.GetValueOrDefault("-a") switch
{
    "verify-crc" => new VerifyChecksumsAction(),
    "update-crc" => new UpdateChecksumsAction(),
    "decrypt" => new DecryptStringsAction(),
    "encrypt" => new EncryptStringsAction(),
    _ => null
};

if (action == null)
{
    Console.WriteLine("""
        Usage: Supercell.ArxanUnprotector -a <action> -i <original> -m <modified> [-o <output>]
        Actions:
            verify-crc - Verify checksums
            update-crc - Update checksums
            decrypt - Decrypt strings
            encrypt - Encrypt strings
    """);
    return -1;
}

Library originalLibrary = File.Exists(original) ? LibraryLoader.Load(original) : null;
Library modifiedLibrary = File.Exists(modified) ? LibraryLoader.Load(modified) : null;

if (output != null)
{
    string outputDirectory = Path.GetDirectoryName(output);

    if (!string.IsNullOrEmpty(outputDirectory) && !Directory.Exists(outputDirectory))
    {
        Directory.CreateDirectory(outputDirectory);
    }
}

string result = action.Execute(originalLibrary, modifiedLibrary, output);

if (result == null)
{
    Console.WriteLine("Success!");
    return 0;
}
else
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(result);
    Console.ResetColor();

    return -1;
}

static Dictionary<string, string> ParseArguments(string[] args)
{
    Dictionary<string, string> arguments = new Dictionary<string, string>();

    for (int i = 0; i < args.Length; i += 2)
    {
        string key = args[i];
        string value = args[i + 1];

        arguments.Add(key, value);
    }

    return arguments;
}