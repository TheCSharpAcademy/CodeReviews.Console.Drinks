using DrinksInfo.Models;
using System.Configuration;

public class App
{
    private DrinksService? _drinksService;
    private readonly string? _baseUrl = ConfigurationManager.AppSettings["ApiBaseUrl"];

    public async Task RunAsync()
    {
        _drinksService = new DrinksService(_baseUrl);
        var categories = await _drinksService.GetAsync<DrinkCategories>("/list.php?c=list");

        Console.ReadKey();
    }
}


