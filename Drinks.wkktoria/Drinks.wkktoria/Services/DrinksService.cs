using System.Net;
using System.Web;
using Drinks.wkktoria.Models;
using Drinks.wkktoria.UserInterface;
using Newtonsoft.Json;
using RestSharp;

namespace Drinks.wkktoria.Services;

internal static class DrinksService
{
    internal static List<Category>? GetCategories()
    {
        var client = new RestClient("https://www.thecocktaildb.com/api/json/v1/1/");
        var request = new RestRequest("list.php?c=list");
        var response = client.ExecuteAsync(request);

        List<Category>? categories = new();

        if (response.Result.StatusCode != HttpStatusCode.OK) return categories;

        var rawResponse = response.Result.Content;
        if (rawResponse == null) return categories;

        var deserialized = JsonConvert.DeserializeObject<Categories>(rawResponse);
        categories = deserialized?.CategoriesList;

        return categories;
    }

    internal static List<Drink>? GetDrinksByCategory(string category)
    {
        var client = new RestClient("https://www.thecocktaildb.com/api/json/v1/1/");
        var request = new RestRequest($"filter.php?c={HttpUtility.UrlEncode(category)}");
        var response = client.ExecuteAsync(request);

        List<Drink>? drinks = new();

        if (response.Result.StatusCode != HttpStatusCode.OK) return drinks;

        var rawResponse = response.Result.Content;
        if (rawResponse == null) return drinks;

        var deserialized = JsonConvert.DeserializeObject<Models.Drinks>(rawResponse);
        drinks = deserialized?.DrinksList;

        return drinks;
    }

    internal static void GetDrink(string id)
    {
        var client = new RestClient("https://www.thecocktaildb.com/api/json/v1/1/");
        var request = new RestRequest($"lookup.php?i={id}");
        var response = client.ExecuteAsync(request);

        if (response.Result.StatusCode != HttpStatusCode.OK) return;

        var rawResponse = response.Result.Content;
        if (rawResponse == null) return;

        var deserialized = JsonConvert.DeserializeObject<DrinkDetailsObject>(rawResponse);
        var resultList = deserialized?.DrinkDetailsList;
        var drinkDetails = resultList?[0];
        List<object> prepList = new();
        var formattedName = string.Empty;

        foreach (var propertyInfo in drinkDetails?.GetType().GetProperties()!)
        {
            if (propertyInfo.Name.ToLower().Contains("str")) formattedName = propertyInfo.Name.Substring(3);

            if (!string.IsNullOrEmpty(propertyInfo.GetValue(drinkDetails)?.ToString()))
                prepList.Add(new
                {
                    Key = formattedName,
                    Value = propertyInfo.GetValue(drinkDetails)
                });
        }

        if (resultList != null) TableVisualisationEngine.ShowTable(prepList, drinkDetails.StrDrink);
    }
}