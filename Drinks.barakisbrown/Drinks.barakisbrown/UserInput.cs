using Drinks.barakisbrown.Models;
using Spectre.Console;

namespace Drinks.barakisbrown;

public class UserInput
{
    private static string? CategoryNameInput = "Please Select a category from the list.";
    private static string? PressAnyKeyInput = "Press any key to return to the main menu.";

	public UserInput()
	{
	}
    
    public Category PickCategory()
    {
        AnsiConsole.Clear();
        AnsiConsole.WriteLine();
        AnsiConsole.WriteLine("Drink Info App.");
        
        var prompt = new SelectionPrompt<Category>
        {
            PageSize = 10,
            Title = CategoryNameInput,
        };

        var categories = DrinksService.GetCategories();

        foreach (var category in categories)
        {
            prompt.AddChoice(category);
        }

        var catChoice = AnsiConsole.Prompt(prompt);
        return catChoice;
    }

    public Drink PickDrink(Category category)
    {
        AnsiConsole.Clear();
        AnsiConsole.WriteLine();

        var prompt = new SelectionPrompt<Drink> 
        { 
            PageSize=10,
            Title = $"Pick a drink from the category {category.strCategory}"
        };

        var drinks = DrinksService.GetDrinkList(category);

        foreach (var drink in drinks) 
        {
            prompt.AddChoice(drink);
        }

        return AnsiConsole.Prompt(prompt);
    }
}

