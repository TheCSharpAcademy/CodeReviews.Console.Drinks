using System.Net.Http.Headers;
using System.Text.Json;
using Drinks.Models;
using Microsoft.Extensions.Configuration;

namespace Drinks;

public class DataAccess
{
    public string CategoryUrl { get; set; }
    public string DrinksByCategoryUrl { get; set; }
    public string DrinkInfoUrl { get; set; }
    private readonly HttpClient _client;

    public DataAccess()
    {
        IConfiguration configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

        string basePath = GetConfigurationValue(configuration, "DrinksAPI", "BasePath");
        CategoryUrl = basePath + GetConfigurationValue(configuration, "DrinksAPI", "CategoryPath");
        DrinksByCategoryUrl = basePath + GetConfigurationValue(configuration, "DrinksAPI", "DrinksByCategoryPath");
        DrinkInfoUrl = basePath + GetConfigurationValue(configuration, "DrinksAPI", "DrinkInfoPath");

        _client = new();
        _client.DefaultRequestHeaders.Accept.Clear();
        _client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
    }

    private static string GetConfigurationValue(IConfiguration configuration, string section, string key)
    {
        string? value = configuration.GetSection(section)[key];
        if (value == null)
        {
            return $"{key} not found";
        }
        return value;
    }

    public async Task<IEnumerable<Category>> GetDrinkCategories()
    {
        var json = await _client.GetStringAsync(CategoryUrl);
        CategoryResponse response = JsonSerializer.Deserialize<CategoryResponse>(json) ?? new();

        return response.Categories;
    }

    public async Task<IEnumerable<Drink>> GetDrinksByCategory(string category)
    {
        var json = await _client.GetStringAsync($"{DrinksByCategoryUrl}{category}");
        DrinksResponse response = JsonSerializer.Deserialize<DrinksResponse>(json) ?? new();

        return response.Drinks;
    }

    public async Task<IEnumerable<DrinkInfo>> GetDrinksInfo(string drinkName)
    {
        var json = await _client.GetStringAsync($"{DrinkInfoUrl}{drinkName}");
        DrinkInfoResponse response = JsonSerializer.Deserialize<DrinkInfoResponse>(json) ?? new();

        return response.Drinks;
    }
}