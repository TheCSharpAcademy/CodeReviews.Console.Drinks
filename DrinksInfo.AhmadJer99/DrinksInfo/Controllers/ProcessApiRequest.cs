using Newtonsoft.Json;

namespace DrinksInfo.Controllers;

public static class ProcessApiRequest
{
    public static async Task<T> ProcessRequestAsync<T>(HttpClient client, string drinksApiUri)
    {
        await using var stream =
            await client.GetStreamAsync(drinksApiUri);

        using var streamReader = new StreamReader(stream);
        using var jsonReader = new JsonTextReader(streamReader);

        var serializer = new JsonSerializer();
        var result = serializer.Deserialize<T>(jsonReader);

        return result;
    }
}