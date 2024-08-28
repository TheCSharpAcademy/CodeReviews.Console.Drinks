using Drinks.Enums;
using Drinks.Interfaces.HttpManager;
using Drinks.Interfaces.View;
using Drinks.Extensions;

namespace Drinks.View.Commands.FilterMenuCommands;

internal class FilterByAlcoNonAlcoCommand : BaseFilterCommand
{
    public FilterByAlcoNonAlcoCommand(IHttpManger httpManager, ITableConstructor tableConstructor) : base(httpManager, tableConstructor)
    {
    }

    private protected override Models.Drinks FetchQuery(string input) => 
        HttpManager.GetResponse(ApiEndpoints.Filter.ByAlcoholic, input);

    private protected override string[] FetchPropertyArray(Models.Drinks drinks) =>
        drinks.GetPropertyArray(cat => cat.IsAlcoholic);

    private protected override Models.Drinks GetListOfFilters() =>
        HttpManager.GetResponse(ApiEndpoints.Lists.AlcoholicOptions);
}