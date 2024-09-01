using System.Reflection;
using DrinksInfo.Models;
using Newtonsoft.Json;
using RestSharp;

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
            var serialize = JsonConvert.DeserializeObject<DrinkDetailObject>(rawResponse);

            var returnedList = serialize.DrinkDetailList;

            DrinkDetail drinkDetail = returnedList[0];
            Dictionary<string, object> prepList = new();
            string formattedName = "";

            foreach (PropertyInfo prop in drinkDetail.GetType().GetProperties())
            {
                if (prop.Name.Contains("str"))
                {
                    formattedName = prop.Name.Substring(3);
                }

                if (!string.IsNullOrEmpty(prop.GetValue(drinkDetail)?.ToString()))
                {
                    prepList[formattedName] = prop.GetValue(drinkDetail);
                }
            }
            
            TableVisualizationEngine.ShowDrinkDetail(prepList, drinkDetail.strDrink);
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