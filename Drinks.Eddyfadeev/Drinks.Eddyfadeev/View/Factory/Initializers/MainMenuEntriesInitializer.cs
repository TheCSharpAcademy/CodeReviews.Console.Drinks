using Drinks.Eddyfadeev.Enums;
using Drinks.Eddyfadeev.Exceptions;
using Drinks.Eddyfadeev.Interfaces.Handlers;
using Drinks.Eddyfadeev.Interfaces.HttpManager;
using Drinks.Eddyfadeev.Interfaces.View;
using Drinks.Eddyfadeev.Interfaces.View.Factory;
using Drinks.Eddyfadeev.View.Commands.MainMenuCommands;

namespace Drinks.Eddyfadeev.View.Factory.Initializers;

internal class MainMenuEntriesInitializer : IMenuEntriesInitializer<MainMenuEntries> 
{
    private readonly IMenuEntriesHandler<SearchMenuEntries> _searchMenuEntriesHandler;
    private readonly IMenuEntriesHandler<FilterMenuEntries> _filterMenuEntriesHandler;
    private readonly IHttpManger _httpManger;
    private readonly ITableConstructor _tableConstructor;
    
    public MainMenuEntriesInitializer(
        IMenuEntriesHandler<SearchMenuEntries> searchMenuEntriesHandler, 
        IMenuEntriesHandler<FilterMenuEntries> filterMenuEntriesHandler,
        IHttpManger httpManger,
        ITableConstructor tableConstructor
        )
    {
        _searchMenuEntriesHandler = searchMenuEntriesHandler;
        _filterMenuEntriesHandler = filterMenuEntriesHandler;
        _httpManger = httpManger;
        _tableConstructor = tableConstructor;
    }
    
    public Dictionary<MainMenuEntries, Func<ICommand>> InitializeMenuEntries() =>
        new()
        {
            { MainMenuEntries.GetRandom, () => new GetRandomDrinkCommand(_httpManger, _tableConstructor) },
            { MainMenuEntries.SearchMenu, () => new OpenSearchCommand(_searchMenuEntriesHandler) }, 
            { MainMenuEntries.FiltersMenu, () => new OpenFilterByCommand(_filterMenuEntriesHandler) },
            { MainMenuEntries.Exit, () => throw new ExitApplicationException()}
        };
}

