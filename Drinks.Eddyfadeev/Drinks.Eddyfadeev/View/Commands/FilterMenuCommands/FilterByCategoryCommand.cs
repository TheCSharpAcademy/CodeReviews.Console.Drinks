using Drinks.Enums;
using Drinks.Interfaces.HttpManager;
using Drinks.Interfaces.View;
using Drinks.Extensions;

namespace Drinks.View.Commands.FilterMenuCommands;

internal class FilterByCategoryCommand : BaseFilterCommand
{
    public FilterByCategoryCommand(IHttpManger httpManager, ITableConstructor tableConstructor) : base(httpManager, tableConstructor)
    {
    }
    
    private protected override Models.Drinks FetchQuery(string input) =>
        HttpManager.GetResponse(ApiEndpoints.Filter.ByCategory, input);

    private protected override string[] FetchPropertyArray(Models.Drinks drinks) =>
        drinks.GetPropertyArray(cat => cat.DrinkCategory);

    private protected override Models.Drinks GetListOfFilters() =>
        HttpManager.GetResponse(ApiEndpoints.Lists.Categories);
}