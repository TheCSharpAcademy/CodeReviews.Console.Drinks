using System.Diagnostics;
using System.Reflection;
using Newtonsoft.Json;
using RestSharp;
using Spectre.Console;

namespace DrinksInfo;

public class DrinksService
{
    public List<Models.Category> GetCategories()
    {
        var client = new RestClient("https://www.thecocktaildb.com/api/json/v1/1/");
        var request = new RestRequest("list.php?c=list");
        var response = client.ExecuteAsync(request);

        List<Models.Category> categories = new();

        if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
        {
            var rawResponse = response.Result.Content;
            var deserializedResponse = JsonConvert.DeserializeObject<Models.Categories>(rawResponse);

            return categories = deserializedResponse.CategoriesList;
        }
        
        return categories;
    }

    public List<Models.Drink> GetDrinksByCategory(string category)
    {
        var client = new RestClient("https://www.thecocktaildb.com/api/json/v1/1/");
        var request = new RestRequest($"filter.php?c={category}");
        var response = client.ExecuteAsync(request);
        
        List<Models.Drink> drinks = new();

        if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
        {
            var rawResponse = response.Result.Content;
            var deserializedResponse = JsonConvert.DeserializeObject<Models.Drinks>(rawResponse);
            
            return drinks = deserializedResponse.DrinksList;
        }

        return drinks;
    }

    public void GetDrinkDetails(string drinkId)
    {
        var client = new RestClient("https://www.thecocktaildb.com/api/json/v1/1/");
        var request = new RestRequest($"lookup.php?i={drinkId}");
        var response = client.ExecuteAsync(request);
        
        List<Models.DrinkDetail> drinkDetails = new();

        if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
        {
            var rawResponse = response.Result.Content;
            var deserializedResponse = JsonConvert.DeserializeObject<Models.DrinkDetails>(rawResponse);
            
            drinkDetails = deserializedResponse.DrinkDetailsList;
        }
        
        List<string> informations = new();
        List<string> ingredients = new();
        List<string> measurements = new();

        string imageUrl = "";
        string tableTitle = "";
        int ingredientCounter = 0;
        
        foreach (var drinkDetail in drinkDetails)
        {
            foreach (PropertyInfo prop in drinkDetail.GetType().GetProperties())
            {
                if (prop.Name == "DrinkName")
                {
                    if (!string.IsNullOrEmpty($"{prop.GetValue(drinkDetail)}"))
                    {
                        tableTitle += $"[underline][mediumorchid]{prop.GetValue(drinkDetail)}[/][/]";
                    }
                }
                
                if (prop.Name == "Category")
                {
                    if (!string.IsNullOrEmpty($"{prop.GetValue(drinkDetail)}"))
                    {
                        tableTitle += $" from '{prop.GetValue(drinkDetail)}' category.";
                    }
                }
                
                if (prop.Name == "Alcoholic")
                {
                    if (!string.IsNullOrEmpty($"{prop.GetValue(drinkDetail)}"))
                    {
                        tableTitle += " (Alcoholic!)";
                    }
                }
                
                if (prop.Name == "Glass")
                {
                    if (!string.IsNullOrEmpty($"{prop.GetValue(drinkDetail)}"))
                    {
                        informations.Add($"Glass: {prop.GetValue(drinkDetail)}");
                    }
                }
                
                if (prop.Name == "Instructions")
                {
                    if (!string.IsNullOrEmpty($"{prop.GetValue(drinkDetail)}"))
                    {
                        informations.Add($"Instructions: {prop.GetValue(drinkDetail)}");
                    }
                }
                
                if (prop.Name.Contains("Ingredient") && !prop.Name.Contains("Measurement"))
                {
                    if (!string.IsNullOrEmpty(prop.GetValue(drinkDetail)?.ToString()))
                    {
                        ingredientCounter++;
                        ingredients.Add($"{ingredientCounter}. {prop.GetValue(drinkDetail)}");
                    }
                }
                
                if (prop.Name.Contains("Measurement"))
                {
                    if (!string.IsNullOrEmpty(prop.GetValue(drinkDetail)?.ToString()))
                    {
                        measurements.Add($"{prop.GetValue(drinkDetail)}");
                    }
                }
                
                if (prop.Name.Contains("ImageUrl"))
                {
                    if (!string.IsNullOrEmpty(prop.GetValue(drinkDetail)?.ToString()))
                    {
                        imageUrl = $"{prop.GetValue(drinkDetail)}";
                    }
                }
            }
        }

        var table = new Table();
        table.Title(tableTitle);
        table.Caption("Press 'I' to open this drink's image on browser.    Press 'E' to exit to menu.");
        table.AddColumn("[mediumorchid]Informations[/]");
        table.AddColumn("[mediumorchid]Ingredients[/]");
        table.AddColumn("[mediumorchid]Measurements[/]");
        
        var informationCell = string.Join("\n \n", informations);
        var ingredientCell = string.Join("\n", ingredients);
        var measurementCell = string.Join("\n", measurements);
        table.AddRow(informationCell, ingredientCell, measurementCell);
        
        AnsiConsole.Write(table);

        var keyReader = Console.ReadKey(true);
        while (keyReader.Key != ConsoleKey.E)
        {
            if (keyReader.Key == ConsoleKey.I)
            {
                if (!string.IsNullOrEmpty(imageUrl))
                {
                    try
                    {
                        ProcessStartInfo psi = new ProcessStartInfo()
                        {
                            FileName = imageUrl,
                            UseShellExecute = true
                        };
            
                        Process.Start(psi);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }
                }
                else
                {
                    AnsiConsole.MarkupLine("No image found.");
                }
                
                keyReader = Console.ReadKey(true);
            }
        }
    }
}