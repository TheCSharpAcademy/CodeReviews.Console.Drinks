using Newtonsoft.Json;
using RestSharp;
using Drinks.frockett.Models;
using System.Web;

namespace Drinks.frockett;

public class DrinksService
{
    public List<Category> GetCategories()
    {
        var clinet = new RestClient("http://www.thecocktaildb.com/api/json/v1/1/");
        var request = new RestRequest("list.php?c=list");
        var response = clinet.ExecuteAsync(request);

        if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
        {
            string rawResponse = response.Result.Content;
            var serialize = JsonConvert.DeserializeObject<Categories>(rawResponse);

            List<Category> returnedList = serialize.CategoriesList;

            // TODO return list either by passing as parameter or as return type
            return returnedList;
        }
        return null;
    }

    internal DrinkDetail GetDrinkById(string drink)
    {
        var client = new RestClient("http://www.thecocktaildb.com/api/json/v1/1/");
        var request = new RestRequest($"lookup.php?i={drink}");
        var response = client.ExecuteAsync(request);

        if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
        {
            string rawResponse = response.Result.Content;

            var serialize = JsonConvert.DeserializeObject<DrinkDetailObject>(rawResponse);

            List<DrinkDetail> returnedList = serialize.DrinkDetailList;

            DrinkDetail drinkDetail = returnedList[0];

            return drinkDetail;
        }
        return null;
    }

    internal List<Drink> GetDrinksByCategory(string category)
    {
        var client = new RestClient("http://www.thecocktaildb.com/api/json/v1/1/");
        var request = new RestRequest($"filter.php?c={HttpUtility.UrlEncode(category)}");

        var response = client.ExecuteAsync(request);

        List<Drink> drinks = new();

        if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
        {
            string rawResponse = response.Result.Content;

            var serialize = JsonConvert.DeserializeObject<DrinksL>(rawResponse);

            drinks = serialize.DrinksList;

            return drinks;
        }
        return drinks;
    }

    internal DrinkDetail GetRandomDrink()
    {
        var client = new RestClient("http://www.thecocktaildb.com/api/json/v1/1/");
        var request = new RestRequest($"random.php");
        var response = client.ExecuteAsync(request);

        if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
        {
            string rawResponse = response.Result.Content;

            var serialize = JsonConvert.DeserializeObject<DrinkDetailObject>(rawResponse);

            List<DrinkDetail> returnedList = serialize.DrinkDetailList;

            DrinkDetail drinkDetail = returnedList[0];

            return drinkDetail;
        }
        return null;
    }
}
