using Kolejarz.Drinks.ConsoleRunner;
using Kolejarz.Drinks.ConsoleRunner.DTO;
using Spectre.Console;

using var client = new CocktailDbClient(baseUrl: new Uri(@"http://www.thecocktaildb.com/api/json/v1/"), apiKey: "1");

do
{
    var categories = await client.GetDrinkCategories();
    var promptCategory = new SelectionPrompt<DrinkCategory>().Title($"Please select drink [blue]category[/]");
    promptCategory.AddChoices(categories);

    var selectedCategory = AnsiConsole.Prompt(promptCategory);

    var drinks = await client.GetDrinks(selectedCategory);
    var promptDrink = new SelectionPrompt<Drink>().Title($"Please select [blue]drink[/]");
    promptDrink.AddChoices(drinks);

    var selectedDrink = AnsiConsole.Prompt(promptDrink);
    var details = await client.GetDrinkDetails(selectedDrink);
    using var stream = await client.GetDrinkThumbnail(selectedDrink);
    var canvasImage = new CanvasImage(stream);

    PrintDrinkSummary(canvasImage, details);
} while (Console.ReadKey().Key != ConsoleKey.Escape);

void PrintDrinkSummary(CanvasImage thumbnail, Dictionary<string, string> details)
{
    var grid = new Grid();
    grid.AddColumn();
    grid.AddColumn();

    thumbnail.MaxWidth = 20;
    var description = CreateDescription(details);

    grid.AddRow(thumbnail, description);

    AnsiConsole.Write(grid);
    AnsiConsole.MarkupLine("Press [blue]any key[/] to continue or [blue]ESC[/] to close program.");
}

Grid CreateDescription(Dictionary<string, string> details)
{
    var description = new Grid();
    description.AddColumn();
    description.AddColumn();

    var entries = new List<(string, string)>
    {
        ("Category", details["strCategory"]),
        ("Name", details["strDrink"]),
        ("Alternative name", details["strDrinkAlternate"]),
        ("Is Alcoholic?", details["strAlcoholic"]),
        ("IBA", details["strIBA"]),
        ("Glass", details["strGlass"])
    };

    var ingredients = details.Where(x => x.Key.StartsWith("strIngredient")).Where(x => x.Value is not null).Select(x => x.Value);
    var measurements = details.Where(x => x.Key.StartsWith("strMeasure")).Where(x => x.Value is not null).Select(x => x.Value);
    var list = ingredients.Zip(measurements).Select(x => $"{x.First} ([italic][blue]{x.Second.Trim()}[/][/])");

    entries.Add(("Ingredients", string.Join('\n', list)));

    entries.Add(("Instructions", details["strInstructions"]));
    entries.Add(("Tags", details["strTags"]));
    entries.Add(("Video", details["strVideo"]));

    foreach(var (key, value) in entries.Where(e => e.Item2 is not null))
    {
        description.AddRow(new string[] {
            $"[lime]{key}:[/]",
            $"[gray][bold]{value}[/][/]"
        });
    }

    return description;
}
