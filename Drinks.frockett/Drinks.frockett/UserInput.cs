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

    public void MenuHandler()
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
                GetCategoriesInput();
                break;
            case "Show me a random drink!":
                GetRandomDrink();
                break;
            case "Exit":
                Environment.Exit(0);
                break;
        }
    }


    private void GetCategoriesInput()
    {
        AnsiConsole.Clear();
        List<Category> categories = drinksService.GetCategories();
        visualization.PrintTable(categories);

        string? category = AnsiConsole.Ask<string>("Enter category: ");

        while(!validator.IsStringValid(category) || !categories.Any(x => x.StrCategory.ToLower() == category.ToLower()))
        {
            AnsiConsole.MarkupLine($"[red]{category} is not a valid category![/]");
            category = AnsiConsole.Ask<string>("Enter a valid category: ");
        }

        GetDrinksInput(category);
    }

    private void GetDrinksInput(string category)
    {
        AnsiConsole.Clear();
        List<Drink> drinks = drinksService.GetDrinksByCategory(category);
        visualization.PrintDrinks(drinks);

        string? drinkSelection = AnsiConsole.Ask<string>("Enter Drink Id: ");

        while (!validator.IsIdValid(drinkSelection) || !drinks.Any(x => x.IdDrink.ToLower() == drinkSelection.ToLower()))
        {
            AnsiConsole.MarkupLine($"[red]{drinkSelection} is not a valid drink![/]");
            drinkSelection = AnsiConsole.Ask<string>("Enter a valid drink Id: ");
        }

        AnsiConsole.Clear();

        visualization.PrintDrinkDetails(drinksService.GetDrinkById(drinkSelection));
        AnsiConsole.WriteLine("\nPress enter to return to menu...");
        Console.ReadLine();
        MenuHandler();
    }

    private void GetRandomDrink()
    {
        visualization.PrintDrinkDetails(drinksService.GetRandomDrink());
        AnsiConsole.WriteLine("\nPress enter to return to menu...");
        Console.ReadLine();
        MenuHandler();
    }
}
