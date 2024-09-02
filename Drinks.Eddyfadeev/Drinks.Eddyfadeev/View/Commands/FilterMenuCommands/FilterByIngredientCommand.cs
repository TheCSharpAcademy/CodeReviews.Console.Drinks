using Drinks.Eddyfadeev.Enums;
using Drinks.Eddyfadeev.Interfaces.HttpManager;
using Drinks.Eddyfadeev.Interfaces.View;

namespace Drinks.Eddyfadeev.View.Commands.FilterMenuCommands;

internal class FilterByIngredientCommand : BaseFilterCommand
{
    public FilterByIngredientCommand(IHttpManger httpManager, ITableConstructor tableConstructor) : base(httpManager, tableConstructor)
    {
    }

    private protected override Eddyfadeev.Models.Drinks FetchQuery(string input) =>
        HttpManager.GetResponse(ApiEndpoints.Filter.ByIngredient, input);

    private protected override string[] FetchPropertyArray(Eddyfadeev.Models.Drinks drinks) =>
        drinks.DrinksList
            .SelectMany(drink => drink.Ingredients ?? Array.Empty<string>())
            .ToArray();

    private protected override Eddyfadeev.Models.Drinks GetListOfFilters() =>
        HttpManager.GetResponse(ApiEndpoints.Lists.Ingredients);
}