using Drinks.Eddyfadeev.Enums;
using Drinks.Eddyfadeev.Exceptions;
using Drinks.Eddyfadeev.Interfaces.HttpManager;
using Drinks.Eddyfadeev.Interfaces.View;
using Drinks.Eddyfadeev.Interfaces.View.Factory;
using Drinks.Eddyfadeev.View.Commands.FilterMenuCommands;

namespace Drinks.Eddyfadeev.View.Factory.Initializers;

internal class FilterMenuEntriesInitializer : IMenuEntriesInitializer<FilterMenuEntries>
{
    private readonly IHttpManger _httpManager;
    private readonly ITableConstructor _tableConstructor;
    
    public FilterMenuEntriesInitializer(IHttpManger httpManager, ITableConstructor tableConstructor)
    {
        _httpManager = httpManager;
        _tableConstructor = tableConstructor;
    }
    
    public Dictionary<FilterMenuEntries, Func<ICommand>> InitializeMenuEntries() =>
        new()
        {
            { FilterMenuEntries.FilterByCategory, () => new FilterByCategoryCommand(_httpManager, _tableConstructor) },
            { FilterMenuEntries.FilterByAlcoNonAlco, () => new FilterByAlcoNonAlcoCommand(_httpManager, _tableConstructor) },
            { FilterMenuEntries.FilterByGlass, () => new FilterByGlassCommand(_httpManager, _tableConstructor) },
            { FilterMenuEntries.FilterByIngredient, () => new FilterByIngredientCommand(_httpManager, _tableConstructor) },
            { FilterMenuEntries.Back, () => throw new ReturnToPreviousMenuException() }
        };
}