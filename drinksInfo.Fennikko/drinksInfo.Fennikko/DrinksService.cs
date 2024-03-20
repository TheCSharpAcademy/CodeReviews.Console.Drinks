using System.Net;
using System.Web;
using drinksInfo.Fennikko.Models;
using Newtonsoft.Json;
using RestSharp;

namespace drinksInfo.Fennikko;

public class DrinksService
{
    private static readonly RestClient Client = new("http://www.thecocktaildb.com/api/json/v1/1/");

    public List<Category> GetCategories()
    {
        var request = new RestRequest("list.php?c=list");
        var response = Client.ExecuteAsync(request);

        List<Category> categories = [];

        if (response.Result.StatusCode != HttpStatusCode.OK) return categories;

        var rawResponse = response.Result.Content;
        var serialize = JsonConvert.DeserializeObject<Categories>(rawResponse);
        categories = serialize.CategoriesList;

        TableVisualizationEngine.ShowTable(categories, "Categories Menu");

        return categories;

    }

    public List<Drink> GetDrinksByCategory(string category)
    {
        var request = new RestRequest($"filter.php?c={category}");
        var response = Client.ExecuteAsync(request);
        List<Drink> drinks = [];

        if (response.Result.StatusCode != HttpStatusCode.OK) return drinks;

        var rawResponse = response.Result.Content;
        var serialize = JsonConvert.DeserializeObject<Drinks>(rawResponse);
        drinks = serialize.DrinksList;

        TableVisualizationEngine.ShowTable(drinks, "Drinks Menu");

        return drinks;
    }


}