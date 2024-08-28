using Drinks.Enums;
using Drinks.Exceptions;
using Drinks.Interfaces.HttpManager;
using Drinks.Interfaces.View;
using Drinks.Interfaces.View.Factory;
using Drinks.View.Commands.SearchMenuCommands;

namespace Drinks.View.Factory.Initializers;

internal class SearchMenuEntriesInitializer : IMenuEntriesInitializer<SearchMenuEntries>
{
    private readonly IHttpManger _httpManager;
    private readonly ITableConstructor _tableConstructor;
    
    public SearchMenuEntriesInitializer(IHttpManger httpManager, ITableConstructor tableConstructor)
    {
        _httpManager = httpManager;
        _tableConstructor = tableConstructor;
    }
    
    public Dictionary<SearchMenuEntries, Func<ICommand>> InitializeMenuEntries() =>
        new()
        {
            { SearchMenuEntries.SearchByName, () => new SearchByNameCommand(_httpManager, _tableConstructor) },
            { SearchMenuEntries.SearchByIngredient, () => new SearchByIngredientCommand(_httpManager, _tableConstructor) },
            { SearchMenuEntries.Back, () => throw new ReturnToPreviousMenuException() }
        };
}