using Drinks.Enums;
using Drinks.Interfaces.Handlers;
using Drinks.Interfaces.View;

namespace Drinks.View.Commands.MainMenuCommands;

internal class OpenSearchCommand : ICommand
{
    private readonly IMenuEntriesHandler<SearchMenuEntries> _searchMenuEntriesHandler;
    
    public OpenSearchCommand(IMenuEntriesHandler<SearchMenuEntries> searchMenuEntriesHandler)
    {
        _searchMenuEntriesHandler = searchMenuEntriesHandler;
    }
    
    public void Execute()
    {
        _searchMenuEntriesHandler.HandleMenu();
    }
}