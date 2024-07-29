using Drinks.Models;
using Spectre.Console;

namespace Drinks.UI;

public class UI {
    public static string SelectCategory(Categories drinkCategories)
    {
        return AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Choose a drink [green]category[/]")
                .PageSize(10)
                .MoreChoicesText("[grey](Move up and down to reveal more categories)[/]")
                .AddChoices(drinkCategories.Drinks.Select(d => d.StrCategory)));
    }

    public static string SelectDrink(string category, DrinksList drinks)
    {
        return AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title($"Select a [green]drink[/] from the category '{category}'.")
                .PageSize(10)
                .MoreChoicesText("[grey](Move up and down to reveal more drinks)[/]")
                .AddChoices(drinks.Drinks.Select(d => d.StrDrink))
        );
    }

    public static void ShowDrinkInfo(DrinkInfo drinkInfo)
    {
        var table = new Table();

        string[] columns = { "Drink name", "Drink category", "Alcoholic?", "Glass", "Instructions" };
        table.AddColumns(columns);

        table.AddRow(drinkInfo.StrDrink, drinkInfo.StrCategory, drinkInfo.StrAlcoholic, drinkInfo.StrGlass, drinkInfo.StrInstructions);

        AnsiConsole.Write(table);
    }

    public static void Clear() => AnsiConsole.Clear();
}