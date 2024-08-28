using Drinks.Enums;
using Drinks.Interfaces.HttpManager;
using Drinks.Interfaces.View;
using Drinks.Extensions;

namespace Drinks.View.Commands.FilterMenuCommands;

internal class FilterByGlassCommand : BaseFilterCommand
{
    public FilterByGlassCommand(IHttpManger httpManager, ITableConstructor tableConstructor) : base(httpManager, tableConstructor)
    {
    }

    private protected override Models.Drinks FetchQuery(string input) =>
        HttpManager.GetResponse(ApiEndpoints.Filter.ByGlass, input);

    private protected override string[] FetchPropertyArray(Models.Drinks drinks) =>
        drinks.GetPropertyArray(cat => cat.DrinkGlassType);

    private protected override Models.Drinks GetListOfFilters() => 
        HttpManager.GetResponse(ApiEndpoints.Lists.Glasses);
}