using Drinks.Eddyfadeev.Enums;
using Drinks.Eddyfadeev.Interfaces.Handlers;
using Drinks.Eddyfadeev.Interfaces.View;

namespace Drinks.Eddyfadeev.View.Commands.MainMenuCommands;

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