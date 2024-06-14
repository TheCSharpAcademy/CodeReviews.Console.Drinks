using Newtonsoft.Json;
using System.Collections.Generic;

public class App
{
    private readonly IDrinksService _drinksService;
    private readonly DrinksController _drinksController;
    private readonly string? _baseUrl;

    public App(string? baseUrl)
    {
        _baseUrl = baseUrl;
        _drinksService = new DrinksService(_baseUrl);
        _drinksController = new DrinksController(_drinksService);
    }

    public async Task RunAsync()
    {
        await Console.Out.WriteLineAsync("Building Categories..");
        var categories = await _drinksController.GetCategories();
        await Console.Out.WriteLineAsync("Building drink types..");
        var drinksResponse = await _drinksController.GetDrinksTypeByCategory(categories.Categories);
        await Console.Out.WriteLineAsync("Getting drink details by drink type...");
        var drinksList = await _drinksController.GetDrinkDetailsByType("margarita");


        Console.ReadKey();
    }
}

