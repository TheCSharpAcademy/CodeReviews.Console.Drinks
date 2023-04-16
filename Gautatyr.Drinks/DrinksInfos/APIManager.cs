using System.Net.Http.Headers;
using System.Text.Json;

namespace DrinksInfos;

public static class ApiManager
{
    public static Categories[] GetCategoriesAsync()
    {
        using HttpClient client = new();
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        var categoriesRootTask = ProcessDrinkCategoriesAsync(client);

        CategoriesRoot categoriesRoot = new CategoriesRoot(categoriesRootTask.Result.Categories);
        return categoriesRoot.Categories;
    }

    private static async Task<CategoriesRoot> ProcessDrinkCategoriesAsync(HttpClient client)
    {
        await using Stream stream =
            await client.GetStreamAsync("https://www.thecocktaildb.com/api/json/v1/1/list.php?c=list");

        var categoriesRoot =
            await JsonSerializer.DeserializeAsync<CategoriesRoot>(stream);

        return categoriesRoot;
    }

    public static Drink[] GetDrinksAsync(string category)
    {
        using HttpClient client = new();
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        var drinkRootTask = ProcessDrinkAsync(client, category);

        DrinkRoot drinkRoot = new DrinkRoot(drinkRootTask.Result.drinks);
        return drinkRoot.drinks;
    }

    private static async Task<DrinkRoot> ProcessDrinkAsync(HttpClient client, string category)
    {
        await using Stream stream =
            await client.GetStreamAsync($"https://www.thecocktaildb.com/api/json/v1/1/filter.php?c={category}");

        var drinkRoot =
            await JsonSerializer.DeserializeAsync<DrinkRoot>(stream);

        return drinkRoot;
    }

    public static DrinkInfo[] GetDrinkInfoAsync(string drink)
    {
        using HttpClient client = new();
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        var drinkInfoRootTask = ProcessDrinkInfoAsync(client, drink);

        DrinkInfoRoot drinkInfoRoot = new DrinkInfoRoot(drinkInfoRootTask.Result.Infos);
        return drinkInfoRoot.Infos;
    }

    private static async Task<DrinkInfoRoot> ProcessDrinkInfoAsync(HttpClient client, string drink)
    {
        await using Stream stream =
            await client.GetStreamAsync($"https://www.thecocktaildb.com/api/json/v1/1/search.php?s={drink}");

        var drinkInfoRoot =
            await JsonSerializer.DeserializeAsync<DrinkInfoRoot>(stream);

        return drinkInfoRoot;
    }
}
