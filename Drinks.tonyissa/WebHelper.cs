using Drinks.tonyissa.Models;
using System.Net.Http.Headers;
using System.Text.Json;

namespace Drinks.tonyissa.WebHelper;

internal static class WebController
{
    private static readonly HttpClient Client;

    private static readonly Dictionary<string, string> ApiUrlMap = new()
    {
        { "lookup", "https://www.thecocktaildb.com/api/json/v1/1/lookup.php?i="},
        { "random", "https://www.thecocktaildb.com/api/json/v1/1/random.php"},
        { "categories", "https://www.thecocktaildb.com/api/json/v1/1/filter.php?c="},
        { "list-categories", "https://www.thecocktaildb.com/api/json/v1/1/list.php?c=list"}
    };

    static WebController()
    {
        Client = new HttpClient();
        Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        Client.DefaultRequestHeaders.Add("User-Agent", "Console.Drinks.tonyissa v0.0.1");
    }

    private static async Task<Stream> FetchRequestAsync(string ApiUrl)
    {
        var response = await Client.GetAsync(ApiUrl);
        response.EnsureSuccessStatusCode();
        var stream = await response.Content.ReadAsStreamAsync();

        return stream;
    }

    public static async Task<List<Category>> GetCategories()
    {
        var ApiUrl = ApiUrlMap["list-categories"];
        await using var categoriesStream = await FetchRequestAsync(ApiUrl);
        var categories = await JsonSerializer.DeserializeAsync<CategoryResponse>(categoriesStream);

        return categories?.drinks ?? [];
    }
}