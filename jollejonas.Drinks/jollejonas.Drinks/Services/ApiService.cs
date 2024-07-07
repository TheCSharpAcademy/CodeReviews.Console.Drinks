using System.Text.Json;

namespace jollejonas.Drinks.Services;

public class ApiService
{
    private readonly HttpClient _httpClient;
    private readonly string _baseUrl;

    public ApiService(string baseUrl)
    {
        _httpClient = new HttpClient();
        _baseUrl = baseUrl;
    }
    public async Task<T?> GetAsync<T>(string endpoint)
    {
        try
        {

            string fullUrl = $"{_baseUrl}/{endpoint}";

            HttpResponseMessage response = await _httpClient.GetAsync(fullUrl);

            response.EnsureSuccessStatusCode();

            string responseData = await response.Content.ReadAsStringAsync();

            T? result = JsonSerializer.Deserialize<T>(responseData);

            return result;
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine($"Request exception: {e.Message}");
            return default;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Exception: {e.Message}");
            return default;
        }
    }
}
