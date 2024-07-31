using DrinksInfo;
using Newtonsoft.Json;
using Spectre.Console;

HttpClient httpClient = new HttpClient();

string? url = @"https://www.thecocktaildb.com/api/json/v1/1/search.php?s=margarita";

var response = await httpClient.GetAsync(url);
response.EnsureSuccessStatusCode();

string responseBody = await response.Content.ReadAsStringAsync();

DrinksResponse? drinkResponse = JsonConvert.DeserializeObject<DrinksResponse>(responseBody);

foreach (var drink in drinkResponse.Drinks) {
    //    var properties = typeof(Drink).GetProperties();
    //    var ingredients = typeof(Drink)
    //        .GetProperties()
    //        .Where(s => s.Name.StartsWith("strIngredient"));
    //    foreach (var property in properties) {
    //        if (property.GetValue(drink) is not null) {
    //            AnsiConsole.MarkupLine($"[green]{property.Name}:[/] [yellow]{property.GetValue(drink)}[/]");
    //        }
    //    }
    //    AnsiConsole.WriteLine();
    drink.PrintInfo();
}