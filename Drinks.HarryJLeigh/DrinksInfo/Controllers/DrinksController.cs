using DrinksInfo.Models;
using DrinksInfo.Utilities;
using DrinksInfo.Views;
using Newtonsoft.Json;
using RestSharp;
using Spectre.Console;

namespace DrinksInfo.Controllers;

public class DrinksController
{
    
    private readonly RestClient restClient = new RestClient("https://www.thecocktaildb.com/api/json/v1/1/");
    internal List<Category> GetCategories()
    {
         return FetchData<Categories>("list.php?c=list")?.CategoriesList;
    }

    internal List<Drink> GetDrinks(string category)
    {
        List<Drink> drinks = FetchData<DrinksList>($"filter.php?c={category}")?.AllDrinks;
        TableVisualisation.ShowDrinks(drinks);
        return drinks;
    }

    internal void GetDrinkData(int id)
    {
        string endPoint = $"lookup.php?i={id}";
        
        List<Ingredients> ingredients = FetchData<IngredientsList>(endPoint)?.AllIngredients;
        List<Measure> measures = FetchData<MeasureList>(endPoint)?.AllMeasures;
        List<Instruction> drinkInstruction = FetchData<InstructionList>(endPoint)?.Instructions;
        
        if (ingredients.Any()|| measures.Any())
        {
            List<string> validIngredients = Validator.ValidIngredients(ingredients);
            List<string> validMeasures = Validator.ValidMeasures(measures);
            TableVisualisation.ShowDrinkData(validIngredients, validMeasures);
            AnsiConsole.MarkupLine("[bold green]How to create drink:[/]");
            AnsiConsole.MarkupLine(drinkInstruction[0].StrInstructions);
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


