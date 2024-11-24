using DrinksInfo.Controllers;
using DrinksInfo.Models;
using Spectre.Console;

namespace DrinksInfo.UserInterface;

public class DrinkDetailsView
{
    private HttpClient? _httpClient;
    private DrinkDetails? _drinkDetails;
    public string DrinkId { get; set; }
    public DrinkDetailsView(string drinkId)
    {
        DrinkId = drinkId;
        var task = LoadDrinkDetailsById();
        task.Wait();
    }

    private async Task LoadDrinkDetailsById()
    {
        var filter = "i=" + DrinkId;
        var uriRequest = "https://www.thecocktaildb.com/api/json/v1/1/lookup.php?" + filter;

        _httpClient = new HttpClient();
        _drinkDetails = await ProcessApiRequest.ProcessRequestAsync<DrinkDetails>(_httpClient, uriRequest);
    }

    public void ShowAllDetails()
    {
        Console.Clear();
        if (_drinkDetails == null)
        {
            AnsiConsole.MarkupLine("[red]There are no available information for this drink right now![/]");
            return;
        }

        AnsiConsole.MarkupLine("[darkred]════════════════════════════════════════[/]\n");
        AnsiConsole.MarkupLine($"[cyan bold]Drink Name:[/] {_drinkDetails.Drinks[0].DrinkName}\n");
        AnsiConsole.MarkupLine("[red3_1]────────────────────────────────────\n[/]");
        AnsiConsole.MarkupLine($"[cyan]Category:[/] {_drinkDetails.Drinks[0].DrinkCategory}");
        AnsiConsole.MarkupLine($"[cyan]Alcoholic:[/] {(_drinkDetails.Drinks[0].IsDrinkAlcoholic.Contains("Non") ? "Yes" : "No")}");
        AnsiConsole.MarkupLine($"[cyan]Serving Glass:[/] {_drinkDetails.Drinks[0].DrinkGlassType}");
        AnsiConsole.MarkupLine("\n[red3_1]────────────────────────────────────[/]");

        AnsiConsole.MarkupLine("\n[cyan bold]Instructions:[/]\n");
        foreach (var instrLine in _drinkDetails.Drinks[0].DrinkMakeInstructions.Split('.'))
            AnsiConsole.MarkupLine($"{instrLine.Trim()}");

        AnsiConsole.MarkupLine("[red3_1]────────────────────────────────────[/]");

        var orderedIngredients = _drinkDetails.Drinks[0].Ingredients
                        .Where(kvp => kvp.Value != null) //only this that have a value
                        .OrderBy(kvp => kvp.Key); 

        var orderedMeasures = _drinkDetails.Drinks[0].Measures
                        .Where(kvp => kvp.Value != null) //only this that have a value
                        .OrderBy(kvp => kvp.Key); 

        var orderedIngredientsList = orderedIngredients.ToList();
        var orderedMeasuresList = orderedMeasures.ToList();

        AnsiConsole.MarkupLine("\n[cyan bold]Ingredients:[/]\n");
        int index = 1; // display numbering
        foreach (var ingredient in orderedIngredientsList)
        {
            var measure = orderedMeasuresList.FirstOrDefault(m => m.Key == ingredient.Key).Value;

            AnsiConsole.MarkupLine($"{index++}. {measure} {ingredient.Value}"); 
        }

        AnsiConsole.MarkupLine("\n[darkred]════════════════════════════════════════[/]\n");
        AnsiConsole.MarkupLine("[gray]Press Any Key To Continue[/]");
        Console.ReadKey();
    }
}
