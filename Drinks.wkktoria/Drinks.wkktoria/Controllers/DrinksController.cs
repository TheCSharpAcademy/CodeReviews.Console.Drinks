using Drinks.wkktoria.Models;
using Drinks.wkktoria.Services;
using Drinks.wkktoria.UserInterface;

namespace Drinks.wkktoria.Controllers;

internal static class DrinksController
{
    internal static string GetCategories()
    {
        Console.Clear();

        var categories = DrinksService.GetCategories();

        if (categories == null) return string.Empty;

        var category =
            Helpers.SelectionPrompt(categories.Select(category => category.StrCategory).ToList(), "Choose category:");

        return category;
    }

    internal static Drink? GetDrinks(string category)
    {
        Console.Clear();

        var drinks = DrinksService.GetDrinksByCategory(category);

        if (drinks == null) return null;

        var drinkName = Helpers.SelectionPrompt(drinks.Select(drink => drink.StrDrink).ToList(), "Choose drink:");

        var selectedDrink =
            drinks.Find(drink => drink.StrDrink.Equals(drinkName, StringComparison.InvariantCultureIgnoreCase));

        return selectedDrink;
    }

    internal static void GetDrinkInfo()
    {
        Console.Clear();

        var category = GetCategories();
        var drink = GetDrinks(category);

        DrinksService.GetDrink(drink!.IdDrink!);

        Helpers.PressAnyKeyToContinue();
    }
}