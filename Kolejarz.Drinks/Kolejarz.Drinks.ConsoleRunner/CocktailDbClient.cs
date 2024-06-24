using Kolejarz.Drinks.ConsoleRunner.DTO;
using System.Text.Json.Nodes;
using System.Text.Json;

namespace Kolejarz.Drinks.ConsoleRunner;

internal class CocktailDbClient : IDisposable
{
    private readonly HttpClient _client;

    public CocktailDbClient(Uri baseUrl, string apiKey)
    {
        _client = new HttpClient
        {
            BaseAddress = new Uri(baseUrl.AbsoluteUri + apiKey + "/")
        };
    }

    public async Task<IEnumerable<DrinkCategory>> GetDrinkCategories()
    {
        var result = await _client.GetAsync("list.php?c=list");
        var content = await result.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<IEnumerable<DrinkCategory>>(JsonNode.Parse(content)!["drinks"])!;
    }

    public async Task<IEnumerable<Drink>> GetDrinks(DrinkCategory selectedCategory)
    {
        var result = await _client.GetAsync($"filter.php?c={selectedCategory.CategoryName}");
        var content = await result.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<IEnumerable<Drink>>(JsonNode.Parse(content)!["drinks"])!;
    }

    public async Task<Dictionary<string, string>> GetDrinkDetails(Drink selectedDrink)
    {
        var result = await _client.GetAsync($"lookup.php?i={selectedDrink.Id}");
        var content = await result.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<Dictionary<string, string>>(JsonNode.Parse(content)!["drinks"]![0])!;
    }

    public async Task<Stream> GetDrinkThumbnail(Drink selectedDrink)
    {
        var image = await _client.GetStreamAsync(selectedDrink.Thumbnail);
        return image;
    }

    public void Dispose()
    {
        _client.Dispose();
    }
}
