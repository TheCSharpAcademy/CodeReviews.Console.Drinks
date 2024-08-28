using Drinks.Enums;
using Drinks.Interfaces.HttpManager;
using Drinks.Interfaces.View;
using Drinks.Services;

namespace Drinks.View.Commands.SearchMenuCommands;

internal class SearchByNameCommand : BaseSearchCommand
{
    private const string UserPrompt = "Enter the letter(s) or the name of the cocktail : ";
    public SearchByNameCommand(IHttpManger httpManager, ITableConstructor tableConstructor) : base(httpManager, tableConstructor)
    {
    }
    
    private protected override string GetUserInput() => 
        UserChoiceService.GetUserInput<string>(UserPrompt);

    private protected override Models.Drinks FetchQuery(string input) => 
        HttpManager.GetResponse(ApiEndpoints.Search.CocktailByName, input);
}