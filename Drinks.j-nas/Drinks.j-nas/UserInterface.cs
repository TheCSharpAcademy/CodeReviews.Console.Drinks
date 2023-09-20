using Drinks.j_nas.Models;
using Spectre.Console;
using static Drinks.j_nas.Enums;

namespace Drinks.j_nas;

internal static class UserInterface
{
    internal static void MainMenu()
    {
        var isAppRunning = true;
        while (isAppRunning)
        {
            Console.Clear();
            AnsiConsole.Write(
                new FigletText("Drink Menu")
                    .Centered()
                    .Color(Color.Magenta1)
                );
            var option = AnsiConsole.Prompt(
                new SelectionPrompt<MainMenuOptions>()
                    .Title("[green]Select an option[/]")
                    .AddChoices(
                        MainMenuOptions.DrinksByCategory,
                        MainMenuOptions.SearchDrinks,
                        MainMenuOptions.Quit));
            switch (option)
            {
                case MainMenuOptions.DrinksByCategory:
                    CategoryMenu();
                    break;
                case MainMenuOptions.SearchDrinks:
                    SearchMenu();
                    break;
                default:
                    isAppRunning = false;
                    break;
            }
        }
    }
    
    private static void CategoryMenu()
    {
        Console.Clear();
        var isCategoryMenuRunning = true;
        var categories = DrinkService.GetCategories();
        var categoriesList = categories.Select(x => x.StrCategory).ToList();
        categoriesList.Add("Back");
        while (isCategoryMenuRunning)
        {
            var selection = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[green]Select from drink category [/]")
                    .PageSize(10)
                    .AddChoices(categoriesList)
                );
            if (selection != "Back")
            {
                var drinkList = DrinkService.GetDrinksByCategory(selection);
                DrinkMenu(drinkList);
            }
            isCategoryMenuRunning = false;
                    
        }
        
    }

    private static void DrinkMenu(IEnumerable<Drink> drinks)
    {
        Console.Clear();
        var isDrinkMenuRunning = true;
        
        var drinkList = drinks.Select(x => x.StrDrink).ToList();
        drinkList.Add("Back");
        while (isDrinkMenuRunning)
        {
            var selection = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[green]Select a drink[/]")
                    .PageSize(10)
                    .AddChoices(drinkList)
                );
            if (selection != "Back")
            {
                var drinkId = drinks.FirstOrDefault(x => x.StrDrink == selection).IdDrink;
                var drink = DrinkService.GetDrinkById(drinkId);
                
                TableVisualizationEngine.RenderTable(drink);
            }
            
            
            isDrinkMenuRunning = false;
        }
    }
    private static void SearchMenu()
    {
        Console.Clear();
        var isSearchMenuRunning = true;
        
        while (isSearchMenuRunning)
        {
            var search = AnsiConsole.Ask<string>("[green]Enter a search term[/]");
            var drinkList = DrinkService.SearchDrinks(search);
            if (drinkList == null)
            {
                AnsiConsole.Write(new Markup("[red]No drinks found[/] \nPress enter to return to the main menu"));
                Console.ReadLine();
                isSearchMenuRunning = false;
                return;
            }
            DrinkMenu(drinkList);
            isSearchMenuRunning = false;
        }
    }
}