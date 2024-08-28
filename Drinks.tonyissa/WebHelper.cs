using Drinks.tonyissa.Models;
using System.Net.Http.Headers;
using System.Text.Json;

namespace Drinks.tonyissa.WebHelper;

internal static class WebHelper
{
    private static HttpClient Client;

    private static readonly Dictionary<string, string> ApiUrlMap = new()
    {
        { "lookup", "www.thecocktaildb.com/api/json/v1/1/lookup.php?i=" },
        { "random", "www.thecocktaildb.com/api/json/v1/1/random.php" },
        { "categories", "www.thecocktaildb.com/api/json/v1/1/filter.php?c=" },
        { "list-categories", "www.thecocktaildb.com/api/json/v1/1/filter.php?c=list"}
    };

    static WebHelper()
    {
        Client = new HttpClient();
        Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        Client.DefaultRequestHeaders.Add("User-Agent", "Console.Drinks.tonyissa v0.0.1");
    }

    private static async Task<Stream> FetchRequestAsync(string ApiUrl)
    {
        var response = await Client.GetAsync(ApiUrl);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadAsStreamAsync();
    }
}