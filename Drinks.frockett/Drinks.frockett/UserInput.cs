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

    public void GetCategoriesInput()
    {
        AnsiConsole.Clear();
        List<Category> categories = drinksService.GetCategories();
        visualization.PrintTable(categories);

        string? category = AnsiConsole.Ask<string>("Enter category or enter 0 to exit: ");

        if (category == "0")
        {
            Environment.Exit(0);
        }

        while(!validator.IsStringValid(category) || !categories.Any(x => x.strCategory.ToLower() == category.ToLower()))
        {
            AnsiConsole.MarkupLine($"[red]{category} is not a valid category![/]");
            category = AnsiConsole.Ask<string>("Enter a valid category or 0 to exit: ");
        }

        GetDrinksInput(category);
    }

    private void GetDrinksInput(string category)
    {
        AnsiConsole.Clear();
        List<Drink> drinks = drinksService.GetDrinksByCategory(category);
        visualization.PrintDrinks(drinks);

        string? drinkSelection = AnsiConsole.Ask<string>("Enter Drink Id: ");

        while (!validator.IsIdValid(drinkSelection) || !drinks.Any(x => x.idDrink.ToLower() == drinkSelection.ToLower()))
        {
            AnsiConsole.MarkupLine($"[red]{drinkSelection} is not a valid drink![/]");
            drinkSelection = AnsiConsole.Ask<string>("Enter a valid drink Id: ");
        }

        AnsiConsole.Clear();

        visualization.PrintDrinkDetails(drinksService.GetDrinkById(drinkSelection));
        AnsiConsole.WriteLine("\nPress enter to return to categories menu...");
        Console.ReadLine();
        GetCategoriesInput();
    }
}
