using drinksLibrary.Models;
using System.Net.Http.Json;

namespace drinksLibrary;

public class DrinksHttpClient
{
    private readonly HttpClient _client;

    public DrinksHttpClient()
    {
        _client = new HttpClient();
        _client.BaseAddress = new Uri("https://www.thecocktaildb.com/api/json/v1/1/");
    }

    public async Task<Categories> GetCategories()
    {
        Categories? categories = await _client.GetFromJsonAsync<Categories>($"list.php?c=list");
        if (categories is null)
            throw new NullReferenceException();
        return categories;
    }

    public async Task<Drinks> GetDrinksFromCategory(string categoryName)
    {
        Drinks? drinks = await _client.GetFromJsonAsync<Drinks>($"filter.php?c={categoryName}");
        if (drinks is null)
            throw new NullReferenceException();
        return drinks;
    }

    public async Task<DrinkDetailObject> GetDrinkDetails(int drinkId)
    {
        DrinkDetailObject? details = await _client.GetFromJsonAsync<DrinkDetailObject>($"lookup.php?i={drinkId}");
        if (details is null)
            throw new NullReferenceException();
        return details;
    }
}
