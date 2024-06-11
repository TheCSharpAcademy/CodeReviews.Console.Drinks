using Drinks.DataAccess;
using Drinks.Database;
using Drinks.Models;
using Spectre.Console;

namespace Drinks;

internal class ActionManager
{
    DrinksService drinksService = new();
    RepositoryManager repositoryManager = new RepositoryManager(new DbManager());

    Menu menu = new();

    internal async Task RunApp()
    {
        bool runApplication = true;
        while (runApplication)
        {
            AnsiConsole.Clear();
            var choice = menu.GetMainMenu();
            switch (choice)
            {
                case "Drink Menu":
                    await DisplayDrinksMenu();
                    break;
                case "View Favorite Drinks":
                    await DisplayFavoriteDrinks();
                    break;
                case "View Top 10 Searched Drinks":
                    await DisplayTopTenSearchedDrinks();
                    break;
                case "Exit":
                    runApplication = false;
                    break;
                default:
                    break;
            }
        }
    }

    private async Task DisplayTopTenSearchedDrinks()
    {
        var topTenDrinks = repositoryManager.DrinkCountRepository.GetTopTenSearchedDrinks();
        await VisualizationEngine.DisplayTopSearchedDrinks(topTenDrinks, $"[blue]Top Searched Drinks[/] Table");
        VisualizationEngine.DisplayContinueMessage();
    }

    private async Task DisplayFavoriteDrinks()
    {
        var favoriteDrinks = repositoryManager.FavoriteDrinkRepository.All();
        await VisualizationEngine.DisplayFavoriteDrinks(favoriteDrinks, $"[blue]Favorite Drinks[/] Table");
        VisualizationEngine.DisplayContinueMessage();
    }

    internal async Task DisplayDrinksMenu()
    {
        while (true)
        {
            var categories = await drinksService.GetDrinkCategories();
            var choice = menu.GetMenu(categories, "[blue]Please Select a Drink Category select [maroon]Go Back[/] to go back to main Menu[/]");

            if (choice == menu.CancelOperation) return;

            bool runDrinkCategory = true;
            var drinks = await drinksService.GetDrinksByCategory(choice);
            drinks.Insert(0, new Drink { strDrink = menu.CancelOperation });
            drinks.Add(new Drink { strDrink = menu.CancelOperation });
            while (runDrinkCategory)
            {
                AnsiConsole.Clear();
                var drinkChoice = menu.GetDrinksList(drinks, $"[blue]Please Select a Drink or select [maroon]Go Back[/] to go back to main Menu[/]");
                if (drinkChoice != menu.CancelOperation)
                {
                    var drink = drinks.Where(d => d.strDrink == drinkChoice).FirstOrDefault();
                    var drinkDetail = await drinksService.GetDrinkDetailById(Convert.ToInt32(drink.idDrink));
                    repositoryManager.DrinkCountRepository.UpdateDrinkCount(drink);
                    await VisualizationEngine.DisplayDrinkDetailsAsync(drinkDetail[0], $"[blue]{drink.strDrink}[/] Details");
                    var drinkMenuChoice = menu.GetDrinkMenu();
                    if (drinkMenuChoice == "Add to Favorite")
                    {
                        if (repositoryManager.FavoriteDrinkRepository.Add(drink))
                        {
                            AnsiConsole.Markup($"[green]{drink.strDrink}[/] added to Favorite successfully\n");
                        }
                    }
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