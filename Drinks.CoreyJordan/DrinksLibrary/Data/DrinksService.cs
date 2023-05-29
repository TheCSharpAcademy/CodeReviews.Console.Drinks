using DrinksLibrary.Models;
using Newtonsoft.Json;
using RestSharp;
using System.Web;

namespace DrinksLibrary.Data;
public class DrinksService
{
    public string CocktailDbAddress { get; } = "http://www.thecocktaildb.com/api/json/v1/1";

    public List<CategoryModel> GetCategories()
    {
        var client = new RestClient(CocktailDbAddress);
        var request = new RestRequest("list.php?c=list");
        var response = client.ExecuteAsync(request);

        List<CategoryModel> categories = new();

        if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
        {
            string rawResponse = response.Result.Content!;
            var serialize = JsonConvert.DeserializeObject<CategoriesModel>(rawResponse);

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

            drinks = serialize!.DrinkList!;
        }
        return drinks;
    }

    public RawInfoModel GetDrink(string id)
    {
        var client = new RestClient(CocktailDbAddress);
        var request = new RestRequest($"lookup.php?i={id}");
        var response = client.ExecuteAsync(request);

        List<RawInfoModel> returnedList = new();

        if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
        {
            string rawResponse = response.Result.Content!;
            var serialize = JsonConvert.DeserializeObject<InfoObject>(rawResponse);

            returnedList = serialize!.DrinkInfoList!;
        }
        return returnedList[0];
    }
}
