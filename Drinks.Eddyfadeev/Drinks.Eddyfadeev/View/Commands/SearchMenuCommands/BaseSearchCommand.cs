using Drinks.Eddyfadeev.Interfaces.HttpManager;
using Drinks.Eddyfadeev.Interfaces.View;
using Drinks.Eddyfadeev.Services;

namespace Drinks.Eddyfadeev.View.Commands.SearchMenuCommands;

internal abstract class BaseSearchCommand : BaseCommand<string>
{
    private protected abstract string UserPrompt { get; }
    
    protected BaseSearchCommand(IHttpManger httpManager, ITableConstructor tableConstructor) : base(httpManager, tableConstructor)
    {
    }
    
    public override void Execute()
    {
        while (true)
        {
            var userInput = GetUserInput();
            var drinks = FetchQuery(userInput);
            
            var userChoice = GetUserDrinkChoice(drinks);
            if (userChoice == null)
            {
                continue;
            }
            
            var drink = FetchDrink(userChoice);

            DisplayDrinkDetail(drink);
            break;
        }
    }
    
    private string GetUserInput() => 
        UserChoiceService.GetUserInput<string>(UserPrompt);
}