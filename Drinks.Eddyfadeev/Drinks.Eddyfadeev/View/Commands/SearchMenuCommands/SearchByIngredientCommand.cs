using Drinks.Eddyfadeev.Enums;
using Drinks.Eddyfadeev.Interfaces.HttpManager;
using Drinks.Eddyfadeev.Interfaces.View;

namespace Drinks.Eddyfadeev.View.Commands.SearchMenuCommands;

internal class SearchByIngredientCommand : BaseSearchCommand
{
    public SearchByIngredientCommand(IHttpManger httpManager, ITableConstructor tableConstructor) : base(httpManager, tableConstructor)
    {
    }

    private protected override string UserPrompt => "Enter the letter(s) or the name of the ingredient : ";

    private protected override Models.Drinks FetchQuery(string input) =>
        HttpManager.GetResponse(ApiEndpoints.Search.ByIngredientName, input);
}