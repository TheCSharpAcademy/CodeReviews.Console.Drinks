using System.Net.Http.Headers;
using System.Text.Json;
namespace Drinks.Models;

internal class DrinksService
{
    internal string ApiBaseUrl = "https://www.thecocktaildb.com/api/json/v1/1/";

    internal async Task<List<DrinkCategory>> GetDrinkCategories()
    {
        using (HttpClient client = GetHttpClient())
        {
            await using Stream stream = await client.GetStreamAsync($"list.php?c=list");
            var response = await JsonSerializer.DeserializeAsync<DrinkCategoriesResponse>(stream);
            return response?.Drinks ?? new List<DrinkCategory>();
        }
    }

    internal async Task<List<Drink>> GetDrinksByCategory(string categoryName)
    {
        using (HttpClient client = GetHttpClient())
        {
            await using Stream stream = await client.GetStreamAsync($"filter.php?c={categoryName}");
            var response = await JsonSerializer.DeserializeAsync<DrinksResponse>(stream);
            return response?.Drinks ?? new List<Drink>();
        }
    }

    internal async Task<List<DrinkDetail>> GetDrinkDetailById(int id)
    {
        using (HttpClient client = GetHttpClient())
        {
            await using Stream stream = await client.GetStreamAsync($"lookup.php?i={id}");
            var response = await JsonSerializer.DeserializeAsync<DrinkDetailsResponse>(stream);

            return response?.DrinkDetails ?? new List<DrinkDetail>();
        }
    }

    private HttpClient GetHttpClient()
    {
        HttpClient client = new HttpClient();
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        client.BaseAddress = new Uri(ApiBaseUrl);
        return client;
    }

}