using Drinks.wkktoria.Controllers;
using Drinks.wkktoria.Services;

namespace Drinks.wkktoria.UserInterface;

internal class UserInput
{
    private readonly DrinksController _drinksController;
    private readonly FavoritesController _favoritesController;
    private readonly SearchedController _searchedController;

    internal UserInput(FavoritesService favoritesService, SearchedService searchedService)
    {
        _favoritesController = new FavoritesController(favoritesService);
        _drinksController = new DrinksController(searchedService);
        _searchedController = new SearchedController(searchedService);
    }

    internal void Run()
    {
        var quit = false;

        while (!quit)
        {
            Console.Clear();

            var selection =
                Helpers.SelectionPrompt(new List<string>
                    { "Drinks Information", "Favorite Drinks", "Most Searched Drinks", "Quit" });

            switch (selection)
            {
                case "Drinks Information":
                    _drinksController.GetDrinkInfo();
                    break;
                case "Favorite Drinks":
                    FavoriteDrinks();
                    break;
                case "Most Searched Drinks":
                    _searchedController.ShowTop();
                    break;
                case "Quit":
                    quit = true;
                    break;
            }
        }
    }

    private void FavoriteDrinks()
    {
        Console.Clear();

        var selection = Helpers.SelectionPrompt(new List<string>
            { "Show Favorites", "Add to Favorites", "Delete from Favorites", "Return to Menu" });

        switch (selection)
        {
            case "Show Favorites":
                _favoritesController.ShowAll();
                break;
            case "Add to Favorites":
                _favoritesController.AddTo();
                break;
            case "Delete from Favorites":
                _favoritesController.DeleteFrom();
                break;
            case "Return to Menu":
                break;
        }
    }
}