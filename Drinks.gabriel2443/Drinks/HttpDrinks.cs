using Drinks.Models;
using Spectre.Console;
using System.Text.Json;

namespace Drinks;

public class HttpDrinks
{
    private static readonly HttpClient client = new HttpClient();

    internal static async Task<DrinkCategoryList> GetDrinksCategory()
    {
        string url = "https://www.thecocktaildb.com/api/json/v1/1/list.php?c=list";
        try
        {
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<DrinkCategoryList>(responseBody);
        }
        catch (Exception ex)
        {
            AnsiConsole.WriteLine($"Error: {ex.Message}");
            throw;
        }
    }

    internal static async Task<DrinkInformationsList> ShowDrinkCategory(string selectedCategory)
    {
        string url = $"https://www.thecocktaildb.com/api/json/v1/1/filter.php?c={selectedCategory}";
        try
        {
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<DrinkInformationsList?>(responseBody);
        }
        catch (Exception ex)
        {
            AnsiConsole.WriteLine($"Error: {ex.Message}");
            throw;
        }
    }

    internal static async Task<DrinkIngredientList> GetDrinksIngredients(string name)
    {
        string url = $"https://www.thecocktaildb.com/api/json/v1/1/search.php?s={name}";

        try
        {
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<DrinkIngredientList>(responseBody);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            throw;
        }
    }
}