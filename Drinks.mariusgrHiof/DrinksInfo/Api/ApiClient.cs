using System.Net.Http.Json;

namespace DrinksInfo.Api;

public class ApiClient : IApiClient
{
    private readonly HttpClient _client;

    public ApiClient(HttpClient client)
    {
        _client = client;
    }
    public async Task<IEnumerable<Category>> GetCategories()
    {
        var categoryResponse = await _client.GetFromJsonAsync<CategoryResponse>("list.php?c=list");

        return categoryResponse.Categories;
    }



    public async Task<Drink> GetDrinkDetailById(string id)
    {
        try
        {
            var drinkReponse = await _client.GetFromJsonAsync<DrinkResponse>($"lookup.php?i={id}");
            if (drinkReponse.Drinks == null)
            {
                return null;
            }

            return drinkReponse.Drinks[0];
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }

    }

    public async Task<IEnumerable<Drink>> GetDrinksByCategory(string category)
    {
        var drinksResponse = await _client.GetFromJsonAsync<DrinkResponse>($"filter.php?c={category}");

        return drinksResponse.Drinks;
    }
}

