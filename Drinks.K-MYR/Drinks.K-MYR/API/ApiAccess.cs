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

    public async Task<IEnumerable<Category>?> GetCategories()
    {
        try
        {
            var response = await _apiClient.GetFromJsonAsync<CategoryResponse>("list.php?c=list");
            return response?.Categories;
        }
        catch (Exception ex)
        {
            throw new Exception($"An Error Occured Calling The API: {ex.Message}");
        }
    }

    public async Task<IEnumerable<Drink>?> GetDrinksByCategory(string category)
    {
        try
        {
            var response = await _apiClient.GetFromJsonAsync<DrinkResponse>($"filter.php?c={HttpUtility.UrlEncode(category)}");
            return response?.Drinks;
        }
        catch (Exception ex)
        {
            throw new Exception($"An Error Occured Calling The API: {ex.Message}");
        }
    }

    public async Task<DrinkDetail?> GetDrinkById(int drinkId)
    {
        try
        {
            var response = await _apiClient.GetFromJsonAsync<DrinkDetailResponse>($"lookup.php?i={drinkId}");
            return response?.DrinkDetails.ToList()[0];
        }
        catch (Exception ex)
        {
            throw new Exception($"An Error Occured Calling The API: {ex.Message}");
        }
    }
}
