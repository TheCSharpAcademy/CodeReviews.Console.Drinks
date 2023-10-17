using Drinks.wkktoria.Services;
using Spectre.Console;

namespace Drinks.wkktoria;

internal class UserInput
{
    internal void GetCategoriesInput()
    {
        Console.Clear();

        var categories = DrinksService.GetCategories();

        if (categories == null) return;

        var category =
            SelectionPrompt("Choose category:", categories.Select(category => category.StrCategory).ToList());

        GetDrinksInput(category);
    }

    private void GetDrinksInput(string category)
    {
        Console.Clear();

        var drinks = DrinksService.GetDrinksByCategory(category);

        if (drinks == null) return;

        var drinkName = SelectionPrompt("Choose drink:", drinks.Select(drink => drink.StrDrink).ToList());

        var selectedDrink =
            drinks.Find(drink => drink.StrDrink.Equals(drinkName, StringComparison.InvariantCultureIgnoreCase));

        DrinksService.GetDrink(selectedDrink!.IdDrink!);

        Console.WriteLine("Press any key to return to categories menu...");
        Console.ReadKey();
        if (!Console.KeyAvailable) GetCategoriesInput();
    }

    private static T SelectionPrompt<T>(string title, List<T> choices) where T : class
    {
        return AnsiConsole.Prompt(
            new SelectionPrompt<T>()
                .Title(title)
                .AddChoices(choices));
    }
}