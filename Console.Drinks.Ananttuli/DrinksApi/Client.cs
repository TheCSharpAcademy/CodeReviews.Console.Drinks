namespace DrinksApi;

using System.Net.Http.Headers;

public class Client
{
    public HttpClient client;

    public Client()
    {
        client = new HttpClient();
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
    }
}