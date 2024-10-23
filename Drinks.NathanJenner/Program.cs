using Drinks_Info_Application;
using Spectre.Console;
using System.Reflection;
using System.Text.Json;

List<Drink> drinksList;

do
{
    AnsiConsole.Clear();
    var mainMenuSelection = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("[green]Please select from the options below: [/]")
                .PageSize(20)
                .AddChoices(new[] {
            "Ordinary Drink", "Cocktail", "Punch / Party Drink", "Shake", "Other / Unknown", "Cocoa", "Shot", "Coffee / Tea", "Homemade Liqueur", "Beer", "Soft Drink"
                }));

    using HttpClient client = new HttpClient();

    drinksList = await GetDrinksInCategory(client, mainMenuSelection);
    string drinkSelection = DisplayListOfDrinks(drinksList);
    List<Drink> selectedDrink = await GetSelectedDrinkDetails(drinksList, drinkSelection);
    DisplayDetailsOfSelectedDrink(selectedDrink[0]);

} while (Console.ReadKey().Key != ConsoleKey.Escape);

async Task<List<Drink>> GetDrinksInCategory(HttpClient client, string mainMenuSelection)
{
    string json = await client.GetStringAsync(
         "https://www.thecocktaildb.com/api/json/v1/1/filter.php?c=" + mainMenuSelection);

    Root root = JsonSerializer.Deserialize<Root>(json);
    drinksList = root.drinks;
    return drinksList;
}

string DisplayListOfDrinks(List<Drink> drinksList)
{
    var drinkSelection = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("[green]Please select from the options below: [/]")
                .PageSize(10)
                .AddChoices(drinksList.Select(l => l.strDrink.ToString())));

    return drinkSelection;
}

async Task<List<Drink>> GetSelectedDrinkDetails(List<Drink> drinksList, string drinkSelection)
{
    foreach (var drink in drinksList)
    {
        if (drink.strDrink == drinkSelection)
        {
            var client = new HttpClient();
            string drinkDetailsJson = await client.GetStringAsync(
                "https://www.thecocktaildb.com/api/json/v1/1/lookup.php?i=" + drink.idDrink);

            Root root = JsonSerializer.Deserialize<Root>(drinkDetailsJson);
            List<Drink> drinksDetails = root.drinks;
            return drinksDetails;
        }
    }
    return drinksList;
}

void DisplayDetailsOfSelectedDrink(Drink drink)
{
    AnsiConsole.Markup("[red]Here are the details of your selected drink - [/]\n\n");

    var table = new Table();
    table.AddColumn("Item");
    table.AddColumn("Value");

    foreach (PropertyInfo property in drink.GetType().GetProperties())
    {
        var value = property.GetValue(drink)?.ToString();
        if (!string.IsNullOrEmpty(value))
        {
            if (property.Name.ToString() != "idDrink")
            {
                string formattedName = property.Name.Substring(3);
                table.AddRow(formattedName, value);
            }
        }
    }
    AnsiConsole.Write(table);
    AnsiConsole.Markup("\n\n\n\n\n\n");
    AnsiConsole.MarkupLine("Press [green]any key[/] to return to Menu or [red]ESC[/] to close program.");
}
