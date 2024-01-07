namespace Supercell.ArxanUnprotector.Actions;

using Supercell.ArxanUnprotector;

public interface IAction
{
    string Execute(Library original, Library modified, string output);
}