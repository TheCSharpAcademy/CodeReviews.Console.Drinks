using Drinks.frockett.Models;
using Spectre.Console;

namespace Drinks.frockett;

public class UserInput
{
    private readonly DrinksService drinksService;
    private readonly Visualization visualization;
    private readonly Validator validator;

    public UserInput(DrinksService drinksService, Visualization visualization, Validator validator)
    {
        this.drinksService = drinksService;
        this.visualization = visualization;
        this.validator = validator;
    }   

    public async Task MenuHandler()
    {
        AnsiConsole.Clear();

        string choice = AnsiConsole.Prompt(
                        new SelectionPrompt<string>()
                        .Title("Select an option using the arrow keys, then press enter...")
                        .PageSize(30)
                        .AddChoices(new string[] { "Drink Search", "Show me a random drink!", "Exit" }));

        switch (choice)
        {
            case "Drink Search":
                await GetCategoriesInput();
                break;
            case "Show me a random drink!":
                await GetRandomDrink();
                break;
            case "Exit":
                Environment.Exit(0);
                break;
        }
    }


    private async Task GetCategoriesInput()
    {
        AnsiConsole.Clear();
        List<Category> categories = await drinksService.GetCategories();

        if (categories == null || !categories.Any())
        {
            AnsiConsole.Markup($"[red]Sorry, an error occurred. The API returned null. Press enter to return to main menu...[/]");
            Console.ReadLine();
            await MenuHandler();
            return;
        }

        visualization.PrintTable(categories);

        string? category = AnsiConsole.Ask<string>("Enter category: ");

        while(!validator.IsStringValid(category) || !categories.Any(x => x.StrCategory.ToLower() == category.ToLower()))
        {
            AnsiConsole.MarkupLine($"[red]{category} is not a valid category![/]");
            category = AnsiConsole.Ask<string>("Enter a valid category: ");
        }

        await GetDrinksInput(category);
    }

    private async Task GetDrinksInput(string category)
    {
        AnsiConsole.Clear();
        List<Drink> drinks = await drinksService.GetDrinksByCategory(category);

        if (drinks == null || !drinks.Any())
        {
            AnsiConsole.Markup($"[red]Sorry, an error occurred. The API returned null. Press enter to return to main menu...[/]");
            Console.ReadLine();
            await MenuHandler();
            return;
        }

        visualization.PrintDrinks(drinks);

        string? drinkSelection = AnsiConsole.Ask<string>("Enter Drink Id: ");

        while (!validator.IsIdValid(drinkSelection) || !drinks.Any(x => x.IdDrink.ToLower() == drinkSelection.ToLower()))
        {
            AnsiConsole.MarkupLine($"[red]{drinkSelection} is not a valid drink![/]");
            drinkSelection = AnsiConsole.Ask<string>("Enter a valid drink Id: ");
        }

        AnsiConsole.Clear();

        var drinkDetail = await drinksService.GetDrinkById(drinkSelection);

        if (drinkDetail == null)
        {
            AnsiConsole.Markup($"[red]Sorry, an error occurred. The API returned null. Press enter to return to main menu...[/]");
            Console.ReadLine();
            await MenuHandler();
            return;
        }

        visualization.PrintDrinkDetails(drinkDetail);
        AnsiConsole.WriteLine("\nPress enter to return to menu...");
        Console.ReadLine();

        await MenuHandler();
    }

    private async Task GetRandomDrink()
    {
        visualization.PrintDrinkDetails(await drinksService.GetRandomDrink());
        AnsiConsole.WriteLine("\nPress enter to return to menu...");
        Console.ReadLine();
        await MenuHandler();
    }
}
