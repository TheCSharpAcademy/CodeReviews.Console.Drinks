using System.Net.Http.Json;
using System.Web;

namespace Drinks.K_MYR;

internal class ApiAccess : IApiAccess
{
    private readonly HttpClient _apiClient;

    public ApiAccess(HttpClient apiClient)
    {
        _apiClient = apiClient;
    }

    public async Task<IEnumerable<Category>> GetCategories()
    {
        var response = await _apiClient.GetFromJsonAsync<CategoryResponse>("list.php?c=list");
        
        return response.Categories;
    }

    public async Task<IEnumerable<Drink>> GetDrinksByCategory(string category)
    {
        var response = await _apiClient.GetFromJsonAsync<DrinkResponse>($"filter.php?c={HttpUtility.UrlEncode(category)}");

        return response.Drinks;
    }

    public async Task<DrinkDetail> GetDrinkById(int drinkId)
    {
        var response = await _apiClient.GetFromJsonAsync<DrinkDetailResponse>($"lookup.php?i={drinkId}");

        return response.DrinkDetails.ToList()[0];
    }
}
