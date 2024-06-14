using Newtonsoft.Json;

public class DrinksService : IDrinksService
{
    private string _baseUrl { get; set; }

    private HttpClient client;

    public DrinksService(string baseUrl)
    {
        _baseUrl = baseUrl;
        client = new HttpClient();
        client.BaseAddress = new Uri(_baseUrl);
    }

    public async Task<T> GetAsync<T>(string endpoint)
    {
        var response = await client.GetAsync($"{client.BaseAddress}/{endpoint}");

        if (response.IsSuccessStatusCode)
        {
            var data = await response.Content.ReadAsStringAsync();
            T? json = JsonConvert.DeserializeObject<T>(data);
            return json;
        }
        else
        {
            throw new JsonException("Problems getting data .... "); // add some info here.
        }
    }
}


