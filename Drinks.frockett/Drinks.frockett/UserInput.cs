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
        List<Category> categories = drinksService.GetCategories();
        visualization.PrintTable(categories);

        string? category = AnsiConsole.Ask<string>("Enter category: ");

        while(!validator.IsStringValid(category))
        {
            AnsiConsole.MarkupLine($"[red]{category} is not a valid category![/]");
            category = AnsiConsole.Ask<string>("Enter a valid category: ");
        }

        GetDrinksInput(category);
    }

    private void GetDrinksInput(string category)
    {
        List<Drink> drinks = drinksService.GetDrinksByCategory(category);
        visualization.PrintDrinks(drinks);

        string? drinkSelection = AnsiConsole.Ask<string>("Enter Drink Id: ");

        while (!validator.IsIdValid(drinkSelection))
        {
            AnsiConsole.MarkupLine($"[red]{drinkSelection} is not a valid drink![/]");
            drinkSelection = AnsiConsole.Ask<string>("Enter a valid drink Id: ");
        }

        visualization.UseOtherLibraryShowTable(drinksService.GetDrinkById(drinkSelection), "");
        //visualization.PrintDrinkDetails(selectedDrink);
    }
}
