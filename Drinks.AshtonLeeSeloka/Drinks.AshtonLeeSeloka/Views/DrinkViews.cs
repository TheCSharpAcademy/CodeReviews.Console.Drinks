using HttpRequests.Models;
using HttpRequests.Repositories;
using Spectre.Console;

namespace HttpRequests.Views;

public class DrinkViews
{
	public Drink displayCategories(List<Drink>? categories) 
	{
		Console.Clear();
		var selection = AnsiConsole.Prompt(
			new SelectionPrompt<Drink>()
			.Title("Select Category")
			.UseConverter(c=>c.Category)
			.AddChoices(categories)
			);
		return selection;
	}

	public string displayDrinks(List<Drink>? drinks)
	{
		List<string> drinksList = new List<string>();

		foreach (var drink in drinks) 
		{ 
			drinksList.Add(drink.DrinkName); 
		}

		drinksList.Add("exit");
		
		Console.Clear();
		var selection = AnsiConsole.Prompt(
			new SelectionPrompt<string>()
			.Title("Select Drink")
			.AddChoices(drinksList)
			);

		foreach (var drink in drinks) 
		{
			if (drink.DrinkName == selection)
				return drink.IdDrink.ToString();
		}

		return selection;
	}

	public void DisplayCategoriesAsTable(List<Drink>? categories) 
	{
		AnsiConsole.WriteLine("Enter index or type 0 to exit");
		var table = new Table();
		table.AddColumn("[yellow]Index[/]");
		table.AddColumn("[blue]Menu[/]");
		table.Border(TableBorder.Rounded);
		table.Width(100);

		for (int i = 0; i < categories.Count; i++) 
		{
			table.AddRow($"[yellow]{i+1}[/]", $"[blue]{categories[i].Category}[/]");
		}
		AnsiConsole.Write(table);
	}

	public void DisplayDrinksAsTable(List<Drink>? drinks)
	{
		Console.Clear ();
		Console.Clear();
		AnsiConsole.WriteLine("Enter index or type 0 to exit");
		var table = new Table();
		table.AddColumn("[yellow]Index[/]");
		table.AddColumn("[blue]Menu[/]");
		table.Border(TableBorder.Rounded);
		for (int i = 0; i < drinks.Count; i++)
		{
			table.AddRow($"[yellow]{drinks[i].IdDrink}[/]", $"[blue]{drinks[i].DrinkName}[/]");
		}
		AnsiConsole.Write(table);
	}

	public string UserInput(string message) 
	{
		string s = AnsiConsole.Ask<string>(message);
		return s;
	}

	public void DisplayDrinkDetails(Drink drink, List<string>? ingredients, List<string>? measure) 
	{
		AnsiConsole.WriteLine($"Drink Name: {drink.DrinkName}");
		AnsiConsole.WriteLine($"Alcohol content: {drink.Alcoholic}");
		AnsiConsole.WriteLine($"Serve in : {drink.Glass}\n");

		var table = new Table();
		table.AddColumn("[yellow]Ingredient[/]");
		table.AddColumn("[blue]Measure[/]");
		table.Border(TableBorder.Rounded);
		table.Width(100);

		for (int i = 0; i < ingredients.Count; i++)
		{
			table.AddRow($"[yellow] {ingredients[i]}[/]", $"[blue]{measure[i]}[/]");
		}

		AnsiConsole.Write(table);
		AnsiConsole.Write($"\nInstructions: {drink.Instructions}\n\n\n");
		AnsiConsole.WriteLine("\nPress any key to return to main menu");
		Console.ReadLine();
	}
}
