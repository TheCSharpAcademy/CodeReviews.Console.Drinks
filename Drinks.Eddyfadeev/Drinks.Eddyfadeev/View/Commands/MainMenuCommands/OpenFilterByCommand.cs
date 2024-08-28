using Drinks.Enums;
using Drinks.Interfaces.Handlers;
using Drinks.Interfaces.View;

namespace Drinks.View.Commands.MainMenuCommands;

internal class OpenFilterByCommand : ICommand
{
    private readonly IMenuEntriesHandler<FilterMenuEntries> _filterMenuEntriesHandler;
    
    public OpenFilterByCommand(IMenuEntriesHandler<FilterMenuEntries> filterMenuEntriesHandler)
    {
        _filterMenuEntriesHandler = filterMenuEntriesHandler;
    }
    
    public void Execute()
    {
        _filterMenuEntriesHandler.HandleMenu();
    }
}