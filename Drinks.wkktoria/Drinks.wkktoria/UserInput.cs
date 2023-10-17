using Drinks.wkktoria.Services;
using Spectre.Console;

namespace Drinks.wkktoria;

internal class UserInput
{
    internal void GetCategoriesInput()
    {
        var categories = DrinksService.GetCategories();

        if (categories == null) return;

        var category = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Choose category:")
                .AddChoices(categories.Select(category => category.StrCategory).ToList()));

        GetDrinksInput(category);
    }

    private void GetDrinksInput(string category)
    {
        var drinks = DrinksService.GetDrinksByCategory(category);

        if (drinks == null) return;

        var drinkName = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Choose drink:")
                .AddChoices(drinks.Select(drink => drink.StrDrink).ToList())
        );

        var selectedDrink =
            drinks.Find(drink => drink.StrDrink.Equals(drinkName, StringComparison.InvariantCultureIgnoreCase));

        DrinksService.GetDrink(selectedDrink!.IdDrink!);

        Console.WriteLine("Press any key to return to categories menu...");
        Console.ReadKey();
        if (!Console.KeyAvailable) GetCategoriesInput();
    }
}