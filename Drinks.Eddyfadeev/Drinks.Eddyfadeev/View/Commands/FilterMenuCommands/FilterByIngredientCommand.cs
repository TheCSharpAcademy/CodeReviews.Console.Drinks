using Drinks.Enums;
using Drinks.Interfaces.HttpManager;
using Drinks.Interfaces.View;

namespace Drinks.View.Commands.FilterMenuCommands;

internal class FilterByIngredientCommand : BaseFilterCommand
{
    public FilterByIngredientCommand(IHttpManger httpManager, ITableConstructor tableConstructor) : base(httpManager, tableConstructor)
    {
    }

    private protected override Models.Drinks FetchQuery(string input) =>
        HttpManager.GetResponse(ApiEndpoints.Filter.ByIngredient, input);

    private protected override string[] FetchPropertyArray(Models.Drinks drinks) =>
        drinks.DrinksList
            .SelectMany(drink => drink.Ingredients ?? Array.Empty<string>())
            .ToArray();

    private protected override Models.Drinks GetListOfFilters() =>
        HttpManager.GetResponse(ApiEndpoints.Lists.Ingredients);
}