using System.Net.Http.Headers;
using System.Text.Json;
using drinks_info_console.Models;

namespace drinks_info_console.APIConsumerServices;

public class DrinksProcessor
{
    private HttpClient _client;
    public DrinksProcessor(HttpClient client)
    {
        _client = client;
        _client.DefaultRequestHeaders.Accept.Clear();
        _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }

    public async Task<List<Category>> GetCategoriesListAsync()
    {
        List<Category> categoryList = new List<Category>();

        using (var stream = await _client.GetStreamAsync("https://www.thecocktaildb.com/api/json/v1/1/list.php?c=list"))
        {
            var categories = await JsonSerializer.DeserializeAsync<Categories>(stream);

            categoryList = categories!.CategoryList!;
        }

        return categoryList;
    }

    public async Task<List<Drink>> GetDrinksListAsync(string category)
    {
        List<Drink> drinkList = new List<Drink>();

        using (var stream = await _client.GetStreamAsync($"https://www.thecocktaildb.com/api/json/v1/1/filter.php?c={category}"))
        {
            var drinks = await JsonSerializer.DeserializeAsync<Drinks>(stream);

            drinkList = drinks!.DrinkList!;
        }

        return drinkList;
    }

    public async Task<List<DrinkDetail>> GetDrinksDetailsAsync(string id)
    {
        List<DrinkDetail> drinkDetailList = new List<DrinkDetail>();

        using (var stream = await _client.GetStreamAsync($"https://www.thecocktaildb.com/api/json/v1/1/lookup.php?i={id}"))
        {
            var details = await JsonSerializer.DeserializeAsync<DrinkDetails>(stream);

            drinkDetailList = details!.DrinkDetailList!;
        }

        return drinkDetailList;
    }
}
