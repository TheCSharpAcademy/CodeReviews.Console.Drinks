using DrinksInfo.Models;
using System.Text.Json;

namespace DrinksInfo;
public class DrinksService : IDrinksService
{
    public async Task<List<Category>> GetCategories()
    {
        using HttpClient client = new HttpClient();

        client.BaseAddress = new Uri("https://www.thecocktaildb.com/api/json/v1/1/");

        var response = await client.GetAsync("list.php?c=list");

        List<Category> categories = new();

        if (response.StatusCode == System.Net.HttpStatusCode.OK)
        {
            var content = await response.Content.ReadAsStringAsync();

            var serialize = JsonSerializer.Deserialize<Categories>(content);

            categories = serialize.CategoriesList;

            TableVisualization.ShowCategoriesTable(categories);
            return categories;
        }
        return categories;
    }

    public async Task<List<Drink>> GetDrinksByCategory(string category)
    {
        using HttpClient client = new HttpClient();

        client.BaseAddress = new Uri("https://www.thecocktaildb.com/api/json/v1/1/");

        var response = await client.GetAsync($"filter.php?c={category}");

        List<Drink> drinks = new();

        if (response.StatusCode == System.Net.HttpStatusCode.OK)
        {
            var content = await response.Content.ReadAsStringAsync();

            var serialize = JsonSerializer.Deserialize<Drinks>(content);

            drinks = serialize.DrinksList;

            TableVisualization.ShowDrinksTable(drinks);
            return drinks;
        }
        return drinks;
    }

    public async Task GetDrink(string drink)
    {
        using HttpClient client = new HttpClient();

        client.BaseAddress = new Uri("https://www.thecocktaildb.com/api/json/v1/1/");

        var response = await client.GetAsync($"lookup.php?i={drink}");

        if (response.StatusCode == System.Net.HttpStatusCode.OK)
        {
            var content = await response.Content.ReadAsStringAsync();

            var serialize = JsonSerializer.Deserialize<DrinkDetailObject>(content);

            List<DrinkDetail> returnedList = serialize.DrinkDetailList;

            DrinkDetail drinkDetail = returnedList[0];

            TableVisualization.ShowDrinkTable(drinkDetail);
        }
    }
}
