using Drinks.Models;
using Spectre.Console;

namespace Drinks;

internal class Menu
{
    public string CancelOperation { get; private set; } = $"[maroon]Cancel the Operation[/]";
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

}