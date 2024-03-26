using Drinks.Models;
using Spectre.Console;

namespace Drinks;

public class UserInterface
{
    public static async Task MainMenu()
    {
        AnsiConsole.Clear();

        DataAccess dataAccess = new();
        IEnumerable<Category> categories = await dataAccess.GetDrinkCategories();
        string selectedCategory = ShowCategories(categories);

        IEnumerable<Drink> drinks = await dataAccess.GetDrinksByCategory(selectedCategory);
        string selectedDrink = ShowDrinksByCategory(drinks);

        IEnumerable<DrinkInfo> drinksInfo = await dataAccess.GetDrinksInfo(selectedDrink);
        ShowDrinksInfo(drinksInfo);

        AnsiConsole.MarkupLine("");
        if (!AnsiConsole.Confirm("Find another drink?"))
        {
            Environment.Exit(0);
            return;
        }

        await MainMenu();
    }

    public static string ShowCategories(IEnumerable<Category> categories)
    {
        var categoryNamesArray = categories.Select(category => category.Name);

        var selectedCategory = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Select your [green]category[/]")
                .PageSize(10)
                .MoreChoicesText("[grey](Move up and down to reveal more categories)[/]")
                .AddChoices(categoryNamesArray));

        return selectedCategory;
    }

    public static string ShowDrinksByCategory(IEnumerable<Drink> drinks)
    {
        AnsiConsole.Clear();

        var drinkNamesArray = drinks.Select(drink => drink.Name);

        var selectedDrink = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Select your [green]drink[/]")
                .PageSize(10)
                .MoreChoicesText("[grey](Move up and down to reveal more categories)[/]")
                .AddChoices(drinkNamesArray));

        return selectedDrink;
    }

    public static void ShowDrinksInfo(IEnumerable<DrinkInfo> drinksInfo)
    {
        if (drinksInfo == null)
        {
            AnsiConsole.Markup("[red]No drink to display[/]");
            return;
        }

        DrinkInfo drink = drinksInfo.First();
        if (drink == null)
        {
            AnsiConsole.Markup("[red]No drink to display[/]");
            return;
        }
        ShowDrinkInfo(drink);
    }

    public static void ShowDrinkInfo(DrinkInfo drink)
    {
        AnsiConsole.MarkupLine($"[blue]Name: [/]{drink.Name}");

        AnsiConsole.MarkupLine("[blue]Ingredients:[/]");
        string[] ingredients = GetIngredients(drink, "Ingredient");
        string[] measures = GetIngredients(drink, "Measure");
        int numberOfMeasures = measures.Length;
        for (int i = 0; i < ingredients.Length; i++)
        {
            string measure = "";
            if (i < numberOfMeasures)
            {
                measure = measures[i].Trim();
            }

            AnsiConsole.MarkupLine($" - {ingredients[i]} ({measure})");
        }

        AnsiConsole.MarkupLine($"[blue]Instructions:[/]");
        AnsiConsole.MarkupLine($" - Use a {drink.Glass}.");
        AnsiConsole.MarkupLine($" - {drink.Instructions}");
    }

    public static string[] GetIngredients(DrinkInfo drink, string property)
    {
        return drink.GetType()
            .GetProperties()
            .Where(prop => prop.Name.StartsWith(property) && prop.GetValue(drink) != null)
            .Select(prop => prop.GetValue(drink)?.ToString())
            .ToArray()!;
    }
}