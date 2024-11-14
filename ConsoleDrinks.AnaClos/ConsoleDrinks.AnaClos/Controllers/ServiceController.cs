using RestSharp;

namespace ConsoleDrinks.AnaClos.Controllers;

public class ServiceController
{
    RestClient client;
    RestRequest request;

    public ServiceController()
    {
        client = new RestClient("https://www.thecocktaildb.com/api/json/v1/1/");
    }
    
    public string? GetResponse(string resource)
    {
        request = new RestRequest(resource);
        var response = client.ExecuteAsync(request);
        var condition = response.Result.StatusCode == System.Net.HttpStatusCode.OK;
        return condition ? response.Result.Content : string.Empty;
    }
}