using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using DrinksInfo.StevieTV.Models;
using Newtonsoft.Json;
using RestSharp;

namespace DrinksInfo.StevieTV.Data;

internal class DrinksService
{
    public static List<Category> GetCategories()
    {
        var client = new RestClient("http://www.thecocktaildb.com/api/json/v1/1/");
        var request = new RestRequest("list.php?c=list");
        var response = client.ExecuteAsync(request);

        if (response.Result.StatusCode != HttpStatusCode.OK) return new List<Category>();
        
        var rawResponse = response.Result.Content;
        var serialize = JsonConvert.DeserializeObject<Categories>(rawResponse);

        return serialize.CategoriesList;
    }

    public static List<Drink> GetDrinksByCategory(string category)
    {
        var client = new RestClient("http://www.thecocktaildb.com/api/json/v1/1/");
        var request = new RestRequest($"filter.php?c={HttpUtility.UrlEncode(category)}");
        var response = client.ExecuteAsync(request);

        if (response.Result.StatusCode != HttpStatusCode.OK) return new List<Drink>();
        
        var rawResponse = response.Result.Content;
        var serialize = JsonConvert.DeserializeObject<Drinks>(rawResponse);

        return serialize.DrinksList;
    }

    public static List<DrinkFormatted> GetDrink(Drink drink)
    {
        var client = new RestClient("http://www.thecocktaildb.com/api/json/v1/1/");
        var request = new RestRequest($"lookup.php?i={drink.idDrink}");
        var response = client.ExecuteAsync(request);

        if (response.Result.StatusCode != HttpStatusCode.OK) return new List<DrinkFormatted>();
        
        var rawResponse = response.Result.Content;
        var serialize = JsonConvert.DeserializeObject<DrinkDetailObject>(rawResponse);

        var returnedList = serialize.DrinkDetailList;

        var drinkDetail = returnedList[0];

        List<DrinkFormatted> formattedDrink = new();

        var formattedName = "";

        foreach (var prop in drinkDetail.GetType().GetProperties())
        {
            if (prop.Name.StartsWith("str"))
            {
                formattedName = prop.Name.Substring(3);
            }

            if (!string.IsNullOrEmpty(prop.GetValue(drinkDetail)?.ToString()))
            {
                if (formattedName.StartsWith("Ingredient"))
                {
                    var ingredientNumber = Regex.Match(formattedName, @"\d+").Value;

                    try
                    {
                        var measure = drinkDetail.GetType().GetProperty($"strMeasure{ingredientNumber}").GetValue(drinkDetail).ToString().Trim();

                        formattedDrink.Add(new DrinkFormatted
                        {
                            Key = formattedName,
                            Value = $"{measure} {prop.GetValue(drinkDetail)}"
                        });
                    }
                    catch (NullReferenceException)
                    {
                        formattedDrink.Add(new DrinkFormatted
                        {
                            Key = formattedName,
                            Value = $"{prop.GetValue(drinkDetail)}"
                        });
                    }
                }
                else if (!formattedName.StartsWith("Measure") && !formattedName.StartsWith("DrinkThumb"))
                {

                    formattedDrink.Add(new DrinkFormatted
                    {
                        Key = !string.IsNullOrWhiteSpace(formattedName) ? formattedName : prop.Name,
                        Value = prop.GetValue(drinkDetail).ToString()
                    });
                }
            }
        }
        
        return formattedDrink;
    }
}