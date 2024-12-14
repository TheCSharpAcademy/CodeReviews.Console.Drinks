
namespace Drinks.Bina28.drinks_info;
public class UserInput
{
	DrinksService drinksService = new();

	internal void GetCategoriesInput()
	{var categories = drinksService.GetCategories();

		Console.WriteLine("Choose category:");
		
		string category = Console.ReadLine();

		while (!Validator.IsStringValid(category) || !categories.Any(x => x.strCategory == category))
		{
			if (!Validator.IsStringValid(category))
			{
				Console.WriteLine("\nInvalid category. Try again: ");
			}
			else
			{
				Console.WriteLine("Category doesn't exist. Try again: ");
			}
			category = Console.ReadLine();
		}

		GetDrinksInput(category);
	}

	private void GetDrinksInput(string category)
	{
		var drinks = drinksService.GetDrinksByCategory(category);

		Console.WriteLine("Choose a drink or go back to category menu by typing 0:");

		string drink = Console.ReadLine();

		while (drink != "0" && (!Validator.IsIdValid(drink) || !drinks.Any(x => x.idDrink == drink)))
		{
			if (!Validator.IsIdValid(drink))
			{
				Console.WriteLine("\nInvalid drink. Try again: ");
			}
			else
			{
				Console.WriteLine("Drink doesn't exist. Try again: ");
			}
			drink = Console.ReadLine();
		}

		if (drink == "0")
		{
			GetCategoriesInput();
			return;
		}

		drinksService.GetDrink(drink);

		Console.WriteLine("Press any key to go back to categories menu");
		Console.ReadKey();
		GetCategoriesInput();
	}
}
