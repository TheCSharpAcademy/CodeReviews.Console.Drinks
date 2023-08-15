using System.Net.Http.Json;

using Drinks.MartinL_no.Models;

namespace Drinks.MartinL_no.DAL;

internal class DrinksDataAccess
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

        return response.drinks.ToList()[0];
    }
}

/*
 * Code for viewing Json response in console
 * 

using HttpResponseMessage response = await _client.GetAsync("list.php?c=list");

response.EnsureSuccessStatusCode().WriteRequestToConsole();

var jsonResponse = await response.Content.ReadAsStringAsync();
Console.WriteLine($"{jsonResponse}\n");

static class HttpResponseMessageExtensions
{
    internal static void WriteRequestToConsole(this HttpResponseMessage response)
    {
        if (response is null)
        {
            return;
        }

        var request = response.RequestMessage;
        Console.Write($"{request?.Method} ");
        Console.Write($"{request?.RequestUri} ");
        Console.WriteLine($"HTTP/{request?.Version}");
    }
}

*
*/