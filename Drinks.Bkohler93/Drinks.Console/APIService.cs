using Drinks.Models;
using RestSharp;

namespace Drinks.Service;

public class APIService {
    private readonly RestClient client;

    public APIService(string baseUrl)
    {
        var options = new RestClientOptions(baseUrl);
        client = new RestClient(options);
    }

    public Categories GetDrinkCategories()
    {
        var request = new RestRequest("/list.php?c=list");
        return client.Get<Categories>(request)!;
    }

    public DrinksList GetDrinksByCategory(string category)
    {
        var request = new RestRequest($"/filter.php?c={category}");
        return client.Get<DrinksList>(request)!;
    }

    public DrinkInfoList GetDrinkInfo(string drink)
    {
        var request = new RestRequest($"/search.php?s={drink}");
        return client.Get<DrinkInfoList>(request)!;
    }
}