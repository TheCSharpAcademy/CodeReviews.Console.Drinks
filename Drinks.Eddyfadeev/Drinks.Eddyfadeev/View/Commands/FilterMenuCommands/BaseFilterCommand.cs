using Drinks.Handlers;
using Drinks.Interfaces.HttpManager;
using Drinks.Interfaces.View;
using Drinks.Extensions;

namespace Drinks.View.Commands.FilterMenuCommands;

internal abstract class BaseFilterCommand : BaseCommand<string>
{
    protected BaseFilterCommand(IHttpManger httpManager, ITableConstructor tableConstructor) : base(httpManager, tableConstructor)
    {
    }

    public override void Execute()
    {
        var userChoice = GetUserFilterChoice();
        if (userChoice == null)
        {
            return;
        }
        
        var drinksCategories = FetchQuery(userChoice);
        
        var drinkChoice = GetUserDrinkChoice(drinksCategories);
        if (drinkChoice == null)
        {
            return;
        }
        
        var drink = FetchDrink(drinkChoice);
        DisplayDrinkDetail(drink);
    }
    
    private protected abstract Models.Drinks GetListOfFilters();
    
    private static string? GetUserDrinkChoice(Models.Drinks drinks)
    {
        var drinkNames = drinks.GetPropertyArray(d => d.DrinkName);
        
        return GetUserChoice(drinkNames, Messages.NoDrinksFound);
    }
    
    private static string? GetUserChoice(string[] options, string emptyMessage)
    {
        if (options.Length == 0)
        {
            HandleNoResults(emptyMessage);
            return null;
        }

        var userChoice = DynamicEntriesHandler.HandleDynamicEntries(options);
        return IsBackOption(userChoice) ? null : userChoice;
    }
    
    private string? GetUserFilterChoice()
    {
        var listOfFilters = GetListOfFilters();
        var availableFilters = FetchPropertyArray(listOfFilters);
            
        if (availableFilters.Length == 0)
        {
            HandleNoResults("No categories found!");
            return null;
        }
            
        var userChoice = DynamicEntriesHandler.HandleDynamicEntries(availableFilters);
            
        return IsBackOption(userChoice) ? null : userChoice;
    }
}