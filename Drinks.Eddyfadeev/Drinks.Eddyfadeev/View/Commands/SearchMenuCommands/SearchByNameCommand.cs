using Drinks.Eddyfadeev.Enums;
using Drinks.Eddyfadeev.Interfaces.HttpManager;
using Drinks.Eddyfadeev.Interfaces.View;
using Drinks.Eddyfadeev.Services;

namespace Drinks.Eddyfadeev.View.Commands.SearchMenuCommands;

internal class SearchByNameCommand : BaseSearchCommand
{
    private const string UserPrompt = "Enter the letter(s) or the name of the cocktail : ";
    public SearchByNameCommand(IHttpManger httpManager, ITableConstructor tableConstructor) : base(httpManager, tableConstructor)
    {
    }
    
    private protected override string GetUserInput() => 
        UserChoiceService.GetUserInput<string>(UserPrompt);

    private protected override Eddyfadeev.Models.Drinks FetchQuery(string input) => 
        HttpManager.GetResponse(ApiEndpoints.Search.CocktailByName, input);
}