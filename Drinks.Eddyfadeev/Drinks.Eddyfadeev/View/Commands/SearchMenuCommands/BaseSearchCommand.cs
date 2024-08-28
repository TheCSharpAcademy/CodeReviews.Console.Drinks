using Drinks.Eddyfadeev.Extensions;
using Drinks.Eddyfadeev.Handlers;
using Drinks.Eddyfadeev.Interfaces.HttpManager;
using Drinks.Eddyfadeev.Interfaces.View;
using Spectre.Console;

namespace Drinks.Eddyfadeev.View.Commands.SearchMenuCommands;

internal abstract class BaseSearchCommand : BaseCommand<string>
{
    protected BaseSearchCommand(IHttpManger httpManager, ITableConstructor tableConstructor) : base(httpManager, tableConstructor)
    {
    }
    
    public override void Execute()
    {
        while (true)
        {
            var userInput = GetUserInput();
            var drinks = FetchQuery(userInput);

            var propertyArray = FetchPropertyArray(drinks);

            if (propertyArray.Length == 0)
            {
                AnsiConsole.MarkupLine(Messages.NoDrinksFound);
                continue;
            }

            var userChoice = DynamicEntriesHandler.HandleDynamicEntries(propertyArray);

            if (IsBackOption(userChoice))
            {
                continue;
            }
            
            var drink = FetchDrink(userChoice);

            DisplayDrinkDetail(drink);
            break;
        }
    }
    
    private protected abstract string GetUserInput(); 
    
    private protected override string[] FetchPropertyArray(Eddyfadeev.Models.Drinks drinks) =>
        drinks.GetPropertyArray(d => d.DrinkName);
}