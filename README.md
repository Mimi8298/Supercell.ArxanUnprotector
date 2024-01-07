# Supercell.ArxanUnprotector - A tool to remove and re-protect Arxan protection from Supercell's games
This is a tool to remove and re-protect Arxan protection from Supercell's games. It facilitates the reversal of Arxan Protection in Supercell Games on Android (arm and arm64) and iOS (arm64) platforms.

## Requirements
* .Net 7 (https://dotnet.microsoft.com/download/dotnet/7.0)
* Windows or Mac OS X (arm64) / any platform that supports .Net 7 but you need to compile Capstone yourself

## Usage
```
Usage: Supercell.ArxanUnprotector -a <action> -i <original> -m <modified> [-o <output>]
Actions:
    verify-crc - Verify checksums in modified file
    update-crc - Update checksums in modified file and save to output file
    decrypt - Decrypt strings in original file and save to output file
    encrypt - Encrypt strings in modified file and save to output file
```

## Examples
- ```Supercell.ArxanUnprotector -a verify-crc -i liboriginal.so -m libmodified.so```: Verify if the checksums in libmodified.so are correct
- ```Supercell.ArxanUnprotector -a update-crc -i liboriginal.so -m libmodified.so -o libmodified.so```: Update the checksums in libmodified.so
- ```Supercell.ArxanUnprotector -a decrypt -i liboriginal.so -o liboriginal.so.decrypted```: Decrypt strings in liboriginal.so and save to liboriginal.so.decrypted
- ```Supercell.ArxanUnprotector -a encrypt -i liboriginal.so -m liboriginal.so.decrypted -o liboriginal.so.encrypted```: Encrypt strings in liboriginal.so.decrypted and save to liboriginal.so.encrypted. Note that you need to update the checksums after encrypting the strings.

## Contact
You can contact me on Discord: ```mimi8297```.
I don't provide any support for this tool but I'm happy to answer any questions you may have.
