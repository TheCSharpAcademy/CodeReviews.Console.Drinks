using Newtonsoft.Json;
using RestSharp;
using Drinks.frockett.Models;
using System.Web;
using System.Reflection;

namespace Drinks.frockett;

public class DrinksService
{
    public List<Category> GetCategories()
    {
        var clinet = new RestClient("http://www.thecocktaildb.com/api/json/v1/1/");
        var request = new RestRequest("list.php?c=list");
        var response = clinet.ExecuteAsync(request);

        List<Category> categories = new List<Category>();

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

    internal List<object> GetDrinkById(string drink)
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

            List<object> prepList = new();

            string formattedName = "";

            foreach (PropertyInfo prop in drinkDetail.GetType().GetProperties())
            {

                if (prop.Name.Contains("str"))
                {
                    formattedName = prop.Name.Substring(3);
                }

                if (!string.IsNullOrEmpty(prop.GetValue(drinkDetail)?.ToString()))
                {
                    prepList.Add(new
                    {
                        Key = formattedName,
                        Value = prop.GetValue(drinkDetail)
                    });
                }
            }
            return prepList;
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
}
