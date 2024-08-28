using Drinks.Eddyfadeev.Enums;
using Drinks.Eddyfadeev.Interfaces.Handlers;
using Drinks.Eddyfadeev.Interfaces.View;

namespace Drinks.Eddyfadeev.View.Commands.MainMenuCommands;

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