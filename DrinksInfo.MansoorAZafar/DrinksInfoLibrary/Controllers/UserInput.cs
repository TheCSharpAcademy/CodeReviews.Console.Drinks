using DrinksInfoLibrary.Models;
namespace DrinksInfoLibrary.Controllers;

public class UserInput
{
	DrinksService drinksService = new();
	
	internal void GetCategoriesInput()
	{
		bool continueCategoriesInput = true;
		while(continueCategoriesInput)
		{
			System.Console.Clear();
			var categories = this.drinksService.GetCategories();

			System.Console.Write("Choose category\n> ");
			string category = System.Console.ReadLine();

			while (!Validator.IsStringValid(category))
			{
				System.Console.Write("\nInvalid category\n> ");
				category = System.Console.ReadLine();
			}

			if(!categories.Any(x => x.StrCategory == category)) 
			{
				System.Console.WriteLine("Category doesn't exist.");
				continue;
			}
			
			GetDrinksInput(category);
		}
		
	}

	private void GetDrinksInput(string category)
	{
		var drinks = this.drinksService.GetDrinksByCategory(category);
		System.Console.Write("Choose a drink or go back to category menu by typing 0\n> ");

		string drink = System.Console.ReadLine();
		if (drink == "0") return;

		while (!Validator.IsIdValid(drink))
		{
			System.Console.Write("\nInvalid drink\n> ");
			drink = Console.ReadLine();
		}

		if(!drinks.Any(x => x.IdDrink == drink)) 
		{
			System.Console.WriteLine("Drink doesn't exist.");
			GetDrinksInput(category);
		}
		drinksService.GetDrink(drink);
		
		System.Console.WriteLine("\nPress any key to go back to categories menu...");
		System.Console.ReadKey();
		if (!System.Console.KeyAvailable) return;
	}
}
