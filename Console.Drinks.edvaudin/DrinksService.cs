using DrinksInfo.Models;
using Newtonsoft.Json;
using RestSharp;
using System.Reflection;
using System.Web;

namespace DrinksInfo;

internal class DrinksService
{
    public List<Category> GetCategories()
    {
        var client = new RestClient("http://www.thecocktaildb.com/api/json/v1/1");
        var request = new RestRequest("list.php?c=list");
        var response = client.ExecuteAsync(request);

        List<Category> categories = new();
        if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
        {
            string rawResponse = response.Result.Content;
            var serialize = JsonConvert.DeserializeObject<Categories>(rawResponse);
            categories = serialize.CategoriesList;
            TableVisualisationEngine.ShowTable<Category>(categories, "Categories");
            return categories;
        }
        return categories;
    }

    public List<Drink> GetDrinksByCategory(string category)
    {
        var client = new RestClient("http://www.thecocktaildb.com/api/json/v1/1");
        var request = new RestRequest($"filter.php?c={HttpUtility.UrlEncode(category)}");
        var response = client.ExecuteAsync(request);
        List<Drink> drinks = new();
        if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
        {
            var rawResponse = response.Result.Content;
            var serialize = JsonConvert.DeserializeObject<Drinks>(rawResponse);
            drinks = serialize.DrinksList;
            TableVisualisationEngine.ShowTable<Drink>(drinks, $"{category} Drinks");
            return drinks;
        }
        return drinks;
    }

    public void GetDrinkDetails(string drinkId)
    {
        var client = new RestClient("http://www.thecocktaildb.com/api/json/v1/1");
        var request = new RestRequest($"lookup.php?i={HttpUtility.UrlEncode(drinkId)}");
        var response = client.ExecuteAsync(request);
        if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
        {
            var rawResponse = response.Result.Content;
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
                    prepList.Add(new { Key = formattedName, Value = prop.GetValue(drinkDetail) });
                }
            }
            TableVisualisationEngine.ShowTable(prepList, drinkDetail.strDrink);
        }
    }
}