using Drinks.wkktoria.Models.Dtos;
using Drinks.wkktoria.Services;
using Drinks.wkktoria.UserInterface;

namespace Drinks.wkktoria.Controllers;

internal class FavoritesController
{
    private readonly FavoritesService _favoritesService;

    internal FavoritesController(FavoritesService favoritesService)
    {
        _favoritesService = favoritesService;
    }

    internal void ShowAll()
    {
        Console.Clear();

        var favorites = _favoritesService.GetAll();

        if (favorites.Any())
            TableVisualisationEngine.ShowTable(favorites, "Favorites");
        else
            Console.WriteLine("No favorite drinks.");

        Helpers.PressAnyKeyToContinue();
    }

    internal void AddTo()
    {
        Console.Clear();

        var category = DrinksController.GetCategories();
        var drink = DrinksController.GetDrinks(category);
        var drinkToAdd = new FavoriteDto
        {
            Name = drink!.StrDrink,
            Category = category
        };

        if (!_favoritesService.GetAll().Any(favorite =>
                favorite.Name.Equals(drinkToAdd.Name, StringComparison.InvariantCultureIgnoreCase) &&
                favorite.Category.Equals(drinkToAdd.Category, StringComparison.InvariantCultureIgnoreCase)))
        {
            var added = _favoritesService.Add(drinkToAdd);

            if (added) Console.WriteLine("Added to favorites.");
        }
        else
        {
            Console.WriteLine("Drink is already in favorites.");
        }


        Helpers.PressAnyKeyToContinue();
    }

    internal void DeleteFrom()
    {
        Console.Clear();

        var favorites = _favoritesService.GetAll();

        if (favorites.Any())
        {
            var name =
                Helpers.SelectionPrompt(favorites.Select(drink => drink.Name).ToList(), "Choose drink to delete:");
            var drinkToDelete = favorites.Find(favorite =>
                favorite.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase));

            var deleted = _favoritesService.Delete(drinkToDelete!);

            if (deleted) Console.WriteLine("Deleted from favorites.");
        }
        else
        {
            Console.WriteLine("No favorite drinks.");
        }

        Helpers.PressAnyKeyToContinue();
    }
}