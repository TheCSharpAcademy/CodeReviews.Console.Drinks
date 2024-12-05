using DrinksInfo.Models;
using Spectre.Console;

namespace DrinksInfo.Utilities;

public static class UserInput
{
    internal static string ChooseCategory(List<Category> categories)
    {
        Console.Clear();
        var selectedCategory = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("[yellow]Select a category:[/]")
                .AddChoices(categories.Select(c => c.StrCategory).ToList()));
        return selectedCategory;
    }

    internal static int ChooseDrink(List<Drink> drinks)
    {
      
        var selectedDrink = AnsiConsole.Prompt(
            new TextPrompt<int>("Select a drink:")
                .Validate(input =>
                    Validator.IsDrinkValid(drinks, input)
                        ? ValidationResult.Success()
                        : ValidationResult.Error("[bold red]Invalid ID! Please select drink ID from above.[/]")));
        return selectedDrink;
    }
}