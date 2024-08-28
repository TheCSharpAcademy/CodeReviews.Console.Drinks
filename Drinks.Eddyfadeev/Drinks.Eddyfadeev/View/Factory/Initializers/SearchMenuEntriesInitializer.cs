using Drinks.Eddyfadeev.Enums;
using Drinks.Eddyfadeev.Exceptions;
using Drinks.Eddyfadeev.Interfaces.HttpManager;
using Drinks.Eddyfadeev.Interfaces.View;
using Drinks.Eddyfadeev.Interfaces.View.Factory;
using Drinks.Eddyfadeev.View.Commands.SearchMenuCommands;

namespace Drinks.Eddyfadeev.View.Factory.Initializers;

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