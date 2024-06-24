using System.Net.Http.Json;
using DrinksInfo.Models;

namespace DrinksInfo.API;
internal class DrinksInfoClient : IDrinksInfoClient
{
    private readonly IHttpClientFactory _httpClientFactory;

    public DrinksInfoClient(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IEnumerable<Category>> GetCategories()
    {
        HttpClient client = _httpClientFactory.CreateClient("Drinks");

        try
        {
            CategoryResponse content = await client.GetFromJsonAsync<CategoryResponse>("list.php?c=list");
            return content.Categories;
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"Error retrieving categories: {ex.Message}");
            return Enumerable.Empty<Category>();
        }
    }

    public async Task<IEnumerable<Drink>> GetDrinksByCategory(string category)
    {
        HttpClient client = _httpClientFactory.CreateClient("Drinks");

        try
        {
            DrinkResponse content = await client.GetFromJsonAsync<DrinkResponse>($"filter.php?c={category}");
            return content.Drinks;
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"Error retrieving categories: {ex.Message}");
            return Enumerable.Empty<Drink>();
        }
    }

    public async Task<DrinkDetail> GetDrinkInfoById(int drinkId)
    {
        HttpClient client = _httpClientFactory.CreateClient("Drinks");

        try
        {
            DrinkDetailResponse content = await client.GetFromJsonAsync<DrinkDetailResponse>($"lookup.php?i={drinkId}");
            return content.Details.ToList()[0];
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"Error retrieving categories: {ex.Message}");
            return new DrinkDetail();
        }
    }
}
