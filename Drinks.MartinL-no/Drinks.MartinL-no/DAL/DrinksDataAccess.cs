using System.Net.Http.Json;

using Drinks.MartinL_no.Models;

namespace Drinks.MartinL_no.DAL;

internal class DrinksDataAccess : IDrinksDataAccess
{
	private readonly HttpClient _client;

    public DrinksDataAccess(HttpClient client)
	{
        _client = client;
    }

    public async Task<IEnumerable<Category>> GetCategories()
    {
        var response = await _client.GetFromJsonAsync<CategoryResponse>("list.php?c=list");

        return response.Categories;
    }

    public async Task<IEnumerable<Drink>> GetDrinks(string categoryName)
    {
        var categoryNameUrlString = categoryName.Replace(" ", "_");
        var response = await _client.GetFromJsonAsync<DrinksResponse>($"filter.php?c={categoryNameUrlString}");

        return response.drinks;
    }

    public async Task<DrinkDetails> GetDrinkDetails(int drinkId)
    {
        var response = await _client.GetFromJsonAsync<DrinkDetailsResponse>($"lookup.php?i={drinkId}");

        return response.Drinks.ToList()[0];
    }
}
