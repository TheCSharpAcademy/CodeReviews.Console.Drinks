using Drinks.Models;
using Spectre.Console;

namespace Drinks;

internal class Menu
{
    public string CancelOperation { get; private set; } = $"[maroon]Go Back[/]";

    public string[] MainMenu = ["Drink Menu", "View Favorite Drinks", "View Top 10 Searched Drinks", "Exit"];
    public string[] DrinkMenu = ["Add to Favorite", $"[maroon]Go Back[/]"];

    internal string GetMainMenu()
    {
        return AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Please Select An Action From The Options Below")
                    .PageSize(10)
                    .AddChoices(MainMenu)
        );
    }

    internal string GetMenu(List<DrinkCategory> drinkCategories, string title)
    {
        drinkCategories.Insert(0, new DrinkCategory { strCategory = CancelOperation });
        drinkCategories.Add(new DrinkCategory { strCategory = CancelOperation });
        return AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title(title)
                    .PageSize(10)
                    .AddChoices(Helpers.ConvertToArray(drinkCategories, category => category.strCategory))
            );
    }

    internal string GetDrinksList(List<Drink> drinkCategories, string title)
    {
        return AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title(title)
                    .PageSize(10)
                    .AddChoices(Helpers.ConvertToArray(drinkCategories, category => category.strDrink))
            );
    }

    internal string GetDrinkMenu()
    {
        return AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Please Select An Action From The Options Below")
                    .PageSize(10)
                    .AddChoices(DrinkMenu)
        );
    }

}