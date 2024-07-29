using Drinks.Models;
using RestSharp;
using Spectre.Console;

var options = new RestClientOptions("https://www.thecocktaildb.com/api/json/v1/1");
var client = new RestClient(options);
var request = new RestRequest("/list.php?c=list");

var drinkCategories = client.Get<Categories>(request);

var category = AnsiConsole.Prompt(
    new SelectionPrompt<string>()
        .Title("Choose a drink [green]category[/]")
        .PageSize(10)
        .MoreChoicesText("[grey](Move up and down to reveal more categories)[/]")
        .AddChoices(drinkCategories.Drinks.Select(d => d.StrCategory)));

var categoryEndpoint = "/filter.php?c=" + category;

request = new RestRequest(categoryEndpoint);

var drinks = client.Get<DrinksList>(request);

var drink = AnsiConsole.Prompt(
    new SelectionPrompt<string>()
    .Title("Select a [green]drink[/] from the category '" + category + "'.")
    .PageSize(10)
    .MoreChoicesText("[grey](Move up and down to reveal more drinks)[/]")
    .AddChoices(drinks.Drinks.Select(d => d.StrDrink))
);

var drinkEndpoint = "/search.php?s=" + drink;

request = new RestRequest(drinkEndpoint);

var information = client.Get<DrinkInfoList>(request);

var drinkInfo = information.Drinks.First();

var table = new Table();

string[] columns = ["Drink name", "Drink category", "Alcoholic?", "Glass", "Instructions"];
table.AddColumns(columns);

table.AddRow(drinkInfo.StrDrink, drinkInfo.StrCategory, drinkInfo.StrAlcoholic, drinkInfo.StrGlass, drinkInfo.StrInstructions);

AnsiConsole.Write(table);