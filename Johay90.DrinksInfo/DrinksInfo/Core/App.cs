using Spectre.Console;
using System.Collections.Generic;

public class App
{
    private readonly IDrinksService _drinksService;
    private readonly DrinksController _drinksController;
    private readonly UserInput _userInput;
    private readonly string? _baseUrl;

    public App(string? baseUrl)
    {
        _baseUrl = baseUrl;
        _drinksService = new DrinksService(_baseUrl);
        _drinksController = new DrinksController(_drinksService);
        _userInput = new UserInput();
    }

    public async Task RunAsync()
    {
        while (true)
        {
            _userInput.Header();

            var categories = await _drinksController.GetCategories();
            var category = _userInput.PickCategory(categories.Categories);
            DrinkDetail drink;

            var drinksResponse = await _drinksController.GetDrinksTypeByCategory(category);
            var drinkType = _userInput.PickDrinkType(drinksResponse.Drinks);

            DrinkDetailResponse drinksList = await _drinksController.GetDrinkDetailsByType(drinkType.Name);

            if (drinksList.Drinks.Count > 1)
            {
                drink = _userInput.PickDrink(drinksList.Drinks);
            }
            else
            {
                drink = drinksList.Drinks.FirstOrDefault(x => x == drinksList.Drinks.First());
            }

            _userInput.ViewDrink(drink);
        }



    }
}

