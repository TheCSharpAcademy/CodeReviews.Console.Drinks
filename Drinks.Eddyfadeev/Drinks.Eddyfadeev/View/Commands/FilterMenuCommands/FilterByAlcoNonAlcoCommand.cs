using Drinks.Eddyfadeev.Enums;
using Drinks.Eddyfadeev.Extensions;
using Drinks.Eddyfadeev.Interfaces.HttpManager;
using Drinks.Eddyfadeev.Interfaces.View;

namespace Drinks.Eddyfadeev.View.Commands.FilterMenuCommands;

internal class FilterByAlcoNonAlcoCommand : BaseFilterCommand
{
    public FilterByAlcoNonAlcoCommand(IHttpManger httpManager, ITableConstructor tableConstructor) : base(httpManager, tableConstructor)
    {
    }

    private protected override Models.Drinks FetchQuery(string input) => 
        HttpManager.GetResponse(ApiEndpoints.Filter.ByAlcoholic, input);

    private protected override string[] FetchPropertyArray(Eddyfadeev.Models.Drinks drinks) =>
        drinks.GetPropertyArray(cat => cat.IsAlcoholic);

    private protected override Eddyfadeev.Models.Drinks GetListOfFilters() =>
        HttpManager.GetResponse(ApiEndpoints.Lists.AlcoholicOptions);
}