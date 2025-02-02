using Drinks.FunRunRushFlush.Data.Model;
using Microsoft.Extensions.Options;
using System.Linq;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace Drinks.FunRunRushFlush.Data;

public class DrinksRequest
{
    private readonly HttpClient _client;


    public DrinksRequest(HttpClient client, IOptions<DrinksApiSettings> setting)
    {
        client.BaseAddress = new Uri(setting.Value.ApiBasePath);
        _client = client;
    }

    public async Task<DrinksResponse?> GetAllCategorysAsync()
    {
        var content = await _client.GetFromJsonAsync<DrinksResponse>("list.php?c=list");
        return content;
    }

    public async Task<DrinksResponse?> GetDrinksFromCategoryAsync(string selectedCat)
    {
        var content = await _client.GetFromJsonAsync<DrinksResponse>($"filter.php?c={Uri.EscapeDataString(selectedCat)}");
        return content;
    }

    public async Task<DrinksResponse?> GetDrinkInfoForIdAsync(string selectedId)
    {
        var content = await _client.GetFromJsonAsync<DrinksResponse>($"lookup.php?i={Uri.EscapeDataString(selectedId)}");
        return content;
    }

}
