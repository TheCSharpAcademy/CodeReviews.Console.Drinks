using System.Net.Http.Headers;

namespace drinks_info_console.APIConsumerServices;

public static class ApiClientHelper
{
    public static HttpClient? Client { get; set; }

    public static void InitializeClient()
    {
        Client = new HttpClient();

        Client.DefaultRequestHeaders.Accept.Clear();
        Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }
}