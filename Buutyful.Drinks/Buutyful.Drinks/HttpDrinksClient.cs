using Buutyful.Drinks.Models;
using System.Text.Json;

namespace Buutyful.Drinks;

class HttpDrinksClient()
{
    private readonly HttpClient httpClient = new();  

    public async Task<List<Category>> GetDrinkCategoriesAsync()
    {
        string endpoint = "list.php?c=list";
        var (status, content) = await SendRequestAsync(endpoint);

        if (status)
        {
            return JsonSerializer.Deserialize<CategoriesResponse>(content)?
                .Categories ?? [];
        }
        else
        {
            Console.WriteLine($"Error in GetDrinkCategoriesAsync: {content}");
            return [];           
        }
    }
    public async Task<List<Drink>> GetDrinksByCategoryAsync(string category)
    {
        string endpoint = $"filter.php?c={category}";
        var (status, content) = await SendRequestAsync(endpoint);
        if (status)
        {
            return JsonSerializer.Deserialize<DrinksInCategoryResponse>(content)?
                .Drinks ?? [];
        }
        else
        {
            Console.WriteLine($"Error in GetDrinksByCategoryAsync: {content}");
            return [];
        }

    }
    public async Task<Drink> GetDrinkDetailsAsync(string drink)
    {
        string endpoint = $"search.php?s={drink}";
        var (status, content) = await SendRequestAsync(endpoint);
        if (status)
        {
            try
            {
                var result = JsonSerializer.Deserialize<DrinksInCategoryResponse>(content);
                return result?.Drinks.FirstOrDefault() ?? new Drink { StrDrink = drink };
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Error deserializing JSON in GetDrinkDetailsAsync for {drink}: {ex.Message}");
                return new Drink { StrDrink = drink };
            }

        }
        else
        {
            Console.WriteLine($"Error in GetDrinkDetailsAsync: {content}");
            return new Drink() { StrDrink = drink };
        }

    }
    private async Task<(bool Status, string Content)> SendRequestAsync(string endpoint)
    {
        string url = $"https://www.thecocktaildb.com/api/json/v1/1/{endpoint}";
       
        try
        {
            HttpResponseMessage response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                return (true, await response.Content.ReadAsStringAsync());
            }
            else
            {
                return (false, $"Error: {response.StatusCode} - {response.ReasonPhrase}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception in SendRequestAsync: {ex.Message}");
            return (false, $"Exception: {ex.Message}");
        }
    }
}
