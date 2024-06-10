using Drinks.Models;
using Spectre.Console;

namespace Drinks;

internal class ActionManager
{
    DrinksService drinksService = new();
    UserInput userInput = new();

    Menu menu = new();

    internal async Task RunApp()
    {
        bool runApplication = true;
        while (runApplication)
        {
            AnsiConsole.Clear();
            var categories = await drinksService.GetDrinkCategories();
            var choice = menu.GetMenu(categories, "[blue]Please Select a Drink Category select [maroon]Cancel the Operation[/] to go back to main Menu[/]");
            if (choice == menu.CancelOperation)
            {
                runApplication = false;
            }
            else
            {
                bool runDrinkCategory = true;
                var drinks = await drinksService.GetDrinksByCategory(choice);
                drinks.Insert(0, new Drink {  strDrink = menu.CancelOperation});
                drinks.Add(new Drink {  strDrink = menu.CancelOperation});
                while (runDrinkCategory)
                {
                    AnsiConsole.Clear();
                    var drinkChoice = menu.GetDrinksList(drinks, $"[blue]Please Select a Drink or select [maroon]Cancel the Operation[/] to go back to main Menu[/]");
                    if (drinkChoice != menu.CancelOperation)
                    {
                        var drink = drinks.Where(d => d.strDrink == drinkChoice).FirstOrDefault();
                        var drinkDetail = await drinksService.GetDrinkDetailById(Convert.ToInt32(drink.idDrink));
                        await VisualizationEngine.DisplayDrinkDetailsAsync(drinkDetail[0], $"[blue]{drink.strDrink}[/] Details");
                        VisualizationEngine.DisplayContinueMessage();
                    }
                    else
                    {
                        runDrinkCategory = false;
                    }
                }

            }
        }
    }
}