using LONCHANICK.DrinksApp.Models;
using LONCHANICK.DrinksApp.Request;

while (true)
{
	Console.WriteLine("");
	Console.WriteLine("\tDrinks Menu");
	Console.WriteLine(" 1) Drinks Category List");
	Console.WriteLine(" 2) Drinks By Category");
	Console.WriteLine(" 3) Drinks By Id");
	Console.WriteLine(" C) Clear Screen");
	Console.WriteLine(" 4) Exit");
	Console.Write("Type a valid option: ");
	string? op = Console.ReadLine();
	op = op.Trim();

	ListOfCategories drinkcategories = await DrinksRequest.GetDrinkCategories();


	switch (op)
	{
		case "1":
			Console.WriteLine("\n\tDrinks Categories");
			Console.WriteLine(drinkcategories);
			break;

		case "2":
			Console.Write("\nType any valid category: ");
			string category = Console.ReadLine();
			if (drinkcategories.Contains(category))
			{
				Console.WriteLine("\n\t Drinks Category: " + category.ToUpper() + "\n");
				var drinksByCategories = await DrinksRequest.GetDrinksByCategory(category);
				Console.WriteLine(drinksByCategories);
			}
			else
			{
				Console.WriteLine("Category does not exist MMW!");
			}
			break;

		case "3":
			Console.Write("\nType any valid Id Drink: ");
			string id = Console.ReadLine();

			Console.WriteLine("\n\t Drinks Id: " + id + "\n");
			var drinksById = await DrinksRequest.GetDrinksById(id);
			Console.WriteLine(drinksById);
			break;

		case "c":
			Console.Clear();
			break;


		case "4":
			return;

		default:
			Console.WriteLine("Invalid Option");
			break;
	}
}
