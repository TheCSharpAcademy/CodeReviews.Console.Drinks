using System.Net.Http.Headers;

internal static class HttpClientFactory
{
    private static readonly HttpClient _httpClient;

    static HttpClientFactory()
    {
        _httpClient = new HttpClient();
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "1");
    }

    internal static HttpClient GetHttpClient()
    {
        return _httpClient;
    }
}
