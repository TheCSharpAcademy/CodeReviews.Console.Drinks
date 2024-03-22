using System.Collections.Generic;
using System.Net;
using drinksInfo.Fennikko.Models;
using Newtonsoft.Json;
using RestSharp;

namespace drinksInfo.Fennikko;

public class DrinksService
{
    private static readonly RestClient Client = new("http://www.thecocktaildb.com/api/json/v1/1/");

    public static List<Category> GetCategories()
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

    public static List<Drink> GetDrinksByCategory(string category)
    {
        var request = new RestRequest($"filter.php?c={category}");
        var response = Client.ExecuteAsync(request);
        List<Drink> drinks = [];

        if (response.Result.StatusCode != HttpStatusCode.OK) return drinks;

        var rawResponse = response.Result.Content;
        var serialize = JsonConvert.DeserializeObject<Drinks>(rawResponse);
        drinks = serialize.DrinksList;

        return drinks;
    }

    public static void GetDrink(string drink)
    {
        var request = new RestRequest($"lookup.php?i={drink}");
        var response = Client.ExecuteAsync(request);
        if(response.Result.StatusCode != HttpStatusCode.OK) return;

        var rawResponse = response.Result.Content;
        var serialize = JsonConvert.DeserializeObject<DrinkDetailObject>(rawResponse);
        var returnedList = serialize.DrinkDetailList;
        var drinkDetail = returnedList[0];
        var prepList = new List<object>();
        var formattedName = "";

        foreach (var property in drinkDetail.GetType().GetProperties())
        {
            if (property.Name.Contains("Str"))
            {
                formattedName = property.Name[3..];
            }

            if (!string.IsNullOrWhiteSpace(property.GetValue(drinkDetail)?.ToString()))
            {
                prepList.Add(new
                {
                    Key = formattedName,
                    Value = property.GetValue(drinkDetail)
                });
            }
        }
        TableVisualizationEngine.ShowTable(prepList, drinkDetail.StrDrink);
    }
}