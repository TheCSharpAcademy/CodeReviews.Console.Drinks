using DrinksLibrary.Models;
using Newtonsoft.Json;
using RestSharp;
using System.Web;

namespace DrinksLibrary.Data;
public class DrinksService
{
    public string CocktailDbAddress { get; } = "http://www.thecocktaildb.com/api/json/v1/1";

    public List<DrinkCategoryModel> GetCategories()
    {
        var client = new RestClient(CocktailDbAddress);
        var request = new RestRequest("list.php?c=list");
        var response = client.ExecuteAsync(request);

        List<DrinkCategoryModel> categories = new();

        if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
        {
            string rawResponse = response.Result.Content!;
            var serialize = JsonConvert.DeserializeObject<DrinkCategoriesModel>(rawResponse);

            categories = serialize!.CategoriesList;
        }
        return categories;
    }

    public List<DrinkModel> GetDrinksByCategory(string category)
    {
        var client = new RestClient(CocktailDbAddress);
        var request = new RestRequest($"filter.php?c={HttpUtility.UrlEncode(category)}");
        var response = client.ExecuteAsync(request);

        List<DrinkModel> drinks = new();

        if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
        {
            string rawResponse = response.Result.Content!;
            var serialize = JsonConvert.DeserializeObject<DrinksModel>(rawResponse);

            drinks = serialize!.DrinkList;
        }
        return drinks;
    }
}
