using DrinksLibrary.Models;
using Newtonsoft.Json;
using RestSharp;

namespace DrinksLibrary.Data;
public class DrinksService
{
    public string CocktailDbAddress { get; } = "http://www.thecocktaildb.com/api/json/v1/1";

    public List<DrinkCategory> GetCategories()
    {
        var client = new RestClient(CocktailDbAddress);
        var request = new RestRequest("list.php?c=list");
        var response = client.ExecuteAsync(request);

        List<DrinkCategory> categories = new();

        if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
        {
            string rawResponse = response.Result.Content!;
            var serialize = JsonConvert.DeserializeObject<DrinkCategories>(rawResponse);

            categories = serialize!.CategoriesList;
        }
        return categories;
    }
}
