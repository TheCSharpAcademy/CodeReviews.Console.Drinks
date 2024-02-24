using System.Text.Json;

namespace DrinksConsoleApp;

public class Application
{
    public async Task run()
    {
        using HttpClient client = new();

        var drink = await ProcessRepositoriesAsync(client);

        Console.Write(drink.Categories.Count);
    }

    private async Task<Drinks> ProcessRepositoriesAsync(HttpClient client)
    {
        await using Stream stream = await client.GetStreamAsync(
            "https://www.thecocktaildb.com/api/json/v1/1/list.php?c=list");
        var repositories =
            await JsonSerializer.DeserializeAsync<Drinks>(stream);
        return repositories;
    }
}

