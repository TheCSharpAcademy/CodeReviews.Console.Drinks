﻿using Drinks.Eddyfadeev.Enums;
using Drinks.Eddyfadeev.Extensions;
using Drinks.Eddyfadeev.Interfaces.HttpManager;
using Drinks.Eddyfadeev.Interfaces.View;

namespace Drinks.Eddyfadeev.View.Commands.FilterMenuCommands;

internal class FilterByCategoryCommand : BaseFilterCommand
{
    public FilterByCategoryCommand(IHttpManger httpManager, ITableConstructor tableConstructor) : base(httpManager, tableConstructor)
    {
    }
    
    private protected override Eddyfadeev.Models.Drinks FetchQuery(string input) =>
        HttpManager.GetResponse(ApiEndpoints.Filter.ByCategory, input);

    private protected override string[] FetchPropertyArray(Eddyfadeev.Models.Drinks drinks) =>
        drinks.GetPropertyArray(cat => cat.DrinkCategory);

    private protected override Eddyfadeev.Models.Drinks GetListOfFilters() =>
        HttpManager.GetResponse(ApiEndpoints.Lists.Categories);
}