namespace TheCocktailDb;

using System.Net;
using System.Net.Http.Headers;
using System.Text.Json;

class ApiClient
{
    private Uri baseUri;

    public ApiClient(Uri baseUri)
    {
        this.baseUri = baseUri;
    }

    public async Task<IList<Category>> GetCategoriesAsync()
    {
        using HttpClient client = prepareHttpClient();
        var requestUri = new Uri(baseUri, "list.php?c=list");
        using Stream stream = await client.GetStreamAsync(requestUri);
        var response = await JsonSerializer.DeserializeAsync<GetCategoriesResponse>(stream);
        if (response == null || response.Categories == null)
        {
            return new List<Category>();
        }
        return response.Categories;
    }

    public async Task<IList<Drink>> GetDrinksByCategoryAsync(string categoryName)
    {
        using HttpClient client = prepareHttpClient();
        var requestUri = new Uri(baseUri, "filter.php?c=" + categoryName.Replace(" ", "_"));
        using Stream stream = await client.GetStreamAsync(requestUri);
        var response = await JsonSerializer.DeserializeAsync<GetDrinksByCategoryResponse>(stream);
        if (response == null || response.Drinks == null)
        {
            return new List<Drink>();
        }
        return response.Drinks;
    }

    private HttpClient prepareHttpClient()
    {
        HttpClient client = new();
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(
        new MediaTypeWithQualityHeaderValue("application/json"));
        client.DefaultRequestHeaders.Add("User-Agent", "TheCocktailDbApiClient");
        return client;
    }
}