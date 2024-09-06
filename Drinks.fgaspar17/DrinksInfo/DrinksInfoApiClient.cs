using System.Net.Http.Headers;
using System.Text.Json;

namespace DrinksInfo;

public sealed class DrinksInfoApiClient
{
    private static readonly HttpClient _httpClient;
    private const string _baseUrl = "https://www.thecocktaildb.com/api/json/v1/1";

    static DrinksInfoApiClient()
    {
        _httpClient = new HttpClient()
        {
            BaseAddress = new Uri(_baseUrl),
        };
        _httpClient.DefaultRequestHeaders.Accept
            .Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }

    public static async Task<T> GetAsyncDataFromDrinksInfo<T>(string endpoint) where T : class, new()
    {
        await using Stream stream = await _httpClient.GetStreamAsync(_baseUrl + endpoint);

        return await JsonSerializer.DeserializeAsync<T>(stream) ?? new();
    }
}