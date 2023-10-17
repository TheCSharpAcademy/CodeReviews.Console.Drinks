using Drinks.wkktoria.Controllers;
using Drinks.wkktoria.Services;

namespace Drinks.wkktoria.UserInterface;

internal class UserInput
{
    private readonly FavoritesController _favoritesController;

    internal UserInput(FavoritesService favoritesService)
    {
        _favoritesController = new FavoritesController(favoritesService);
    }

    internal void Run()
    {
        var quit = false;

        while (!quit)
        {
            Console.Clear();

            var selection =
                Helpers.SelectionPrompt(new List<string> { "Drinks Information", "Favorite Drinks", "Quit" });

            switch (selection)
            {
                case "Drinks Information":
                    DrinksController.GetDrinkInfo();
                    break;
                case "Favorite Drinks":
                    FavoriteDrinks();
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