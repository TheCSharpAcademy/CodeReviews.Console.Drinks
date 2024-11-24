using DrinksInfo.Models;
using DrinksInfo.Utilities;
using DrinksInfo.Views;
using Newtonsoft.Json;
using RestSharp;

namespace DrinksInfo.Controllers;

public class DrinksController
{
    
    private readonly RestClient restClient = new RestClient("https://www.thecocktaildb.com/api/json/v1/1/");
    internal List<Category> GetCategories()
    {
        List<Category> drinkCategories = FetchData<Categories>("list.php?c=list")?.CategoriesList;

        if (drinkCategories.Any())
        {
            TableVisualisation.ShowTable(drinkCategories, ("Categories", null));
        }
        return drinkCategories;
    }

    internal List<Drink> GetDrinks(string category)
    {
        List<Drink> drinks = FetchData<DrinksList>($"filter.php?c={category}")?.AllDrinks;
        if (drinks.Any())
        {
            TableVisualisation.ShowTable(drinks, ("ID", "Drinks"));
        }
        return drinks;
    }

    internal void GetIngredients(int id)
    {
        List<Ingredients> ingredients = FetchData<IngredientsList>($"lookup.php?i={id}")?.AllIngredients;
       
        if (ingredients.Any())
        {
            List<string> validIngredients = Validator.ValidIngredients(ingredients);
            TableVisualisation.ShowIngredients(validIngredients, "Ingredients");
        }
    }

    private T? FetchData<T>(string endPoint) where T : class
    {
        var request = new RestRequest(endPoint);
        var response = restClient.ExecuteAsync(request).Result;

        if (response.StatusCode == System.Net.HttpStatusCode.OK)
        {
            return JsonConvert.DeserializeObject<T>(response.Content);
        }

        return null;
    }
}


