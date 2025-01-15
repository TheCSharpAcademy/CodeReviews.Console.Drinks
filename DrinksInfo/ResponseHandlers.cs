using Spectre.Console;
using System.Text.Json;

internal class ResponseHandlers
{
    internal static string[] GetCategories()
    {
        try
        {
            var client = HttpClientFactory.GetHttpClient();
            var endpoint = new Uri("https://www.thecocktaildb.com/api/json/v1/1/list.php?c=list");

            var result = client.GetAsync(endpoint).Result;
            var json = result.Content.ReadAsStringAsync().Result;

            var jsonDocument = JsonDocument.Parse(json);
            var categories = jsonDocument.RootElement.GetProperty("drinks").EnumerateArray()
                .Select(e => e.GetProperty("strCategory").GetString() ?? string.Empty)
                .ToArray();
            return categories;
        }
        catch (Exception ex)
        {
            Display.ExceptionInfo(ex);
            return [];
        }
    }

    internal static void ShowDrinkInfo(string drinkId)
    {
        try
        {
            var client = HttpClientFactory.GetHttpClient();
            var endpoint = new Uri("https://www.thecocktaildb.com/api/json/v1/1/lookup.php?i=" + drinkId);

            var result = client.GetAsync(endpoint).Result;
            var json = result.Content.ReadAsStringAsync().Result;

            var jsonDocument = JsonDocument.Parse(json);
            var drinkInfo = jsonDocument.RootElement.GetProperty("drinks").EnumerateArray()
                .Select(e => new
                {
                    Name = e.GetProperty("strDrink").GetString() ?? string.Empty,
                    Category = e.GetProperty("strCategory").GetString() ?? string.Empty,
                    Alcoholic = e.GetProperty("strAlcoholic").GetString() ?? string.Empty,
                    Glass = e.GetProperty("strGlass").GetString() ?? string.Empty,
                    Instructions = e.GetProperty("strInstructions").GetString() ?? string.Empty,
                    Ingredients = string.Join(", ", Enumerable.Range(1, 15)
                        .Select(i => e.GetProperty($"strIngredient{i}").GetString() ?? string.Empty)
                        .Where(i => !string.IsNullOrEmpty(i)))
                })
                .ToArray();

            string alcoholic = drinkInfo[0].Alcoholic switch
            {
                "Alcoholic" => "[hotpink]Yes[/]",
                "Non alcoholic" => "[greenyellow]No[/]",
                _ => ""
            };

            AnsiConsole.Write(
                new Table()
                    .AddColumn("[yellow]Name[/]")
                    .AddColumn($"[hotpink]{drinkInfo[0].Name}[/]")
                    .AddRow("Category", drinkInfo[0].Category)
                    .AddEmptyRow()
                    .AddRow("Alcoholic", alcoholic)
                    .AddEmptyRow()
                    .AddRow("Glass", drinkInfo[0].Glass)
                    .AddEmptyRow()
                    .AddRow("Ingredients", drinkInfo[0].Ingredients)
                    .AddEmptyRow()
                    .AddRow("Instructions", drinkInfo[0].Instructions));

            Display.PressAnyKeyToContinue();
        }
        catch (Exception ex)
        {
            Display.ExceptionInfo(ex);
        }
    }

    internal static string GetDrinkId(string category)
    {
        try
        {
            var client = HttpClientFactory.GetHttpClient();
            var endpoint = new Uri("https://www.thecocktaildb.com/api/json/v1/1/filter.php?c=" + category.Replace(" ", "_"));

            var result = client.GetAsync(endpoint).Result;
            var json = result.Content.ReadAsStringAsync().Result;

            var jsonDocument = JsonDocument.Parse(json);
            var drinks = jsonDocument.RootElement.GetProperty("drinks").EnumerateArray()
                .Select(e => new
                    { 
                        Name = e.GetProperty("strDrink").GetString() ?? string.Empty,
                        Id = e.GetProperty("idDrink").GetString() ?? string.Empty
                    })
                .ToDictionary(x => x.Name, x => x.Id);

            var selectedDrink = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title($"Select a drink from [yellow]{category}[/] category:")
                    .PageSize(10)
                    .AddChoices("Exit to main menu")
                    .AddChoices(drinks.Keys));

            if(selectedDrink == "Exit to main menu")
            {
                Console.Clear();
                return string.Empty;
            }

            return drinks[selectedDrink];
        }
        catch (Exception ex)
        {
            Display.ExceptionInfo(ex);
            return string.Empty;
        }
    }
}
