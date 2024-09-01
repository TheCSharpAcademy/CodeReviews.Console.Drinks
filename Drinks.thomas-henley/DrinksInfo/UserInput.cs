using System.Reflection;
using DrinksInfo.Models;
using Newtonsoft.Json;
using RestSharp;

namespace DrinksInfo;

public class UserInput
{
    private readonly DrinksService _drinksService = new();
    
    internal string GetCategoriesInput()
    {
        var categories = _drinksService.GetCategories();
        
        return _drinksService.SelectCategory(categories);
    }

    internal string GetDrinksInput(string category)
    {
        var drinks = _drinksService.GetDrinks(category);

        return _drinksService.SelectDrink(drinks);
    }

    internal void ShowDrinkDetail(string drink)
    {
        var client = new RestClient("http://www.thecocktaildb.com/api/json/v1/1/");
        var request = new RestRequest($"search.php?s={drink}");
        var response = client.ExecuteAsync(request);

        if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
        {
            var rawResponse = response.Result.Content;
            var serialize = JsonConvert.DeserializeObject<DrinkDetailObject>(rawResponse ?? string.Empty);

            var returnedList = serialize!.DrinkDetailList;

            var drinkDetail = returnedList[0];
            Dictionary<string, object?> prepList = new();

            foreach (PropertyInfo prop in drinkDetail.GetType().GetProperties())
            {
                if (!string.IsNullOrEmpty(prop.GetValue(drinkDetail)?.ToString()))
                {
                    prepList[prop.Name] = prop.GetValue(drinkDetail);
                }
            }
            
            TableVisualizationEngine.ShowDrinkDetail(prepList, drinkDetail.Name ?? "Missing Name");
        }
        else
        {
            TableVisualizationEngine.NotFound();
        }
    }

    internal bool Continue()
    {
        return TableVisualizationEngine.Continue();
    }
}