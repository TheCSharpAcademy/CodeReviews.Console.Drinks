using Drinks.wkktoria.Models;
using Drinks.wkktoria.Models.Dtos;
using Drinks.wkktoria.Services;
using Drinks.wkktoria.UserInterface;

namespace Drinks.wkktoria.Controllers;

internal class DrinksController
{
    private readonly SearchedService _searchedService;

    internal DrinksController(SearchedService searchedService)
    {
        _searchedService = searchedService;
    }

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

    internal void GetDrinkInfo()
    {
        Console.Clear();

        var category = GetCategories();
        var drink = GetDrinks(category);

        DrinksService.GetDrink(drink!.IdDrink!);

        var allSearched = _searchedService.GetAll();
        if (!allSearched.Any(searched =>
                searched.Name.Equals(drink.StrDrink, StringComparison.InvariantCultureIgnoreCase) &&
                searched.Category.Equals(category, StringComparison.InvariantCultureIgnoreCase)))
        {
            _searchedService.Add(new SearchedDto
            {
                Name = drink.StrDrink,
                Category = category
            });
        }
        else
        {
            var toUpdate = allSearched.Find(searched =>
                searched.Name.Equals(drink.StrDrink, StringComparison.InvariantCultureIgnoreCase) &&
                searched.Category.Equals(category, StringComparison.InvariantCultureIgnoreCase));

            if (toUpdate != null)
                _searchedService.Update(new SearchedDto
                {
                    Name = toUpdate.Name,
                    Category = toUpdate.Category,
                    Count = ++toUpdate.Count
                });
        }

        Helpers.PressAnyKeyToContinue();
    }
}