using DrinksInfo.Models;
using Newtonsoft.Json;
using RestSharp;

namespace DrinksInfo;

public class DrinksService
{
    public List<Category> GetCategories()
    {
        var client = new RestClient("http://www.thecocktaildb.com/api/json/v1/1/");
        var request = new RestRequest("list.php?c=list");
        var response = client.ExecuteAsync(request);

        if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
        {
            var rawResponse = response.Result.Content;
            var serialize = JsonConvert.DeserializeObject<Categories>(rawResponse!);

            var returnedList = serialize!.CategoriesList;
            return returnedList;
        }
        else
        {
            return [];
        }
    }

    public string SelectCategory(List<Category> categories)
    {
        var category = TableVisualizationEngine.SelectCategory(categories, "Choose a Drink Category");
        return category;
    }

    public List<Drink> GetDrinks(string category)
    {
        var client = new RestClient("http://thecocktaildb.com/api/json/v1/1/");
        var request = new RestRequest($"filter.php?c={category}");
        var response = client.ExecuteAsync(request);

        if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
        {
            var rawResponse = response.Result.Content;
            var serialize = JsonConvert.DeserializeObject<Drinks>(rawResponse!);
            
            List<Drink> returnedList = serialize!.DrinksList;
            return returnedList;
        }
        else
        {
            return [];
        }
    }

    public string SelectDrink(List<Drink> drinks)
    {
        var drink = TableVisualizationEngine.SelectDrink(drinks, "Choose a Drink");
        return drink;
    }
}