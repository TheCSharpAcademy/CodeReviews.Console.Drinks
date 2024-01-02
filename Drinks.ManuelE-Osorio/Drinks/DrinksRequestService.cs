using System.Net.Http.Headers;
using System.Text.Json;

namespace DrinksProgram;

public class DrinksRequestService
{
    public HttpClient Client;
    private static readonly Uri DrinksBaseAdress = new("https://www.thecocktaildb.com/api/json/v1/1/");

    public DrinksRequestService()
    {
        Client = new()
        {
            BaseAddress = DrinksBaseAdress,
            Timeout = new TimeSpan(0, 0, 10)
        };
        Client.DefaultRequestHeaders.Accept.Clear();
        Client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
    }

    public async Task<CategoriesJSON?> ProcessCategoriesAsync()
    {
        await using Stream stream =
            await Client.GetStreamAsync("list.php?c=list");
        var categories =
            await JsonSerializer.DeserializeAsync<CategoriesJSON>(stream);      
        return categories;
    }

    public async Task<DrinksByCategoryJSON?> ProcessDrinksByCategoryAsync(string category)
    {
        await using Stream stream =
            await Client.GetStreamAsync($"filter.php?c={category}");
        var drinks =
            await JsonSerializer.DeserializeAsync<DrinksByCategoryJSON>(stream);
    
        return drinks;
    }

    public async Task<DrinksJSON?> ProcessDrinksByIDAsync(string idDrink)
    {
        await using Stream stream =
            await Client.GetStreamAsync($"lookup.php?i={idDrink}");
        var drinks =
            await JsonSerializer.DeserializeAsync<DrinksJSON>(stream);
        return drinks;
    }
}