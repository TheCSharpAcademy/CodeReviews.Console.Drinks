using Spectre.Console;
using DrinksInfo.dunow0033.Controllers;
using DrinksInfo.dunow0033.Models;

namespace DrinksInfo.dunow0033.UI
{
	internal class UserInterface
	{
		private DrinksController _controller;

		public UserInterface(DrinksController controller)
		{
			_controller = controller;
		}

		public async Task Run()
		{
			List<string> categories = (await _controller.GetCategories()).ToList();

			while (true)
			{
				Console.Clear();
				foreach (var category in categories)
				{
					Console.WriteLine(category);
				}

				Console.Write("\nPlease enter your choice (0 to exit):  ");

				string drink = Console.ReadLine();

				if (drink == "0")
					Environment.Exit(1);

				while (!categories.Any(c => c.ToLower() == drink.ToLower()))
				{
					Console.Write("\nCategory doesn't exit, please try again (0 to exit):  ");
					drink = Console.ReadLine();

					if (drink == "0")
						Environment.Exit(1);
				}

				await ShowDrinksMenu(drink);
			}
		}

		public async Task ShowDrinksMenu(string choice)
		{
			List<Drink> drinks = (await _controller.GetDrinksByCategory(choice)).ToList();

			while (true)
			{
				Console.Clear();

				foreach (var drink in drinks)
				{
					Console.WriteLine($"{drink.Id} -- {drink.Name}");
				}

				Console.Write("\nPlease enter ID of your drink choice (0 for main menu):  ");

				string detailChoice = Console.ReadLine();

				while (!Int32.TryParse(detailChoice, out _))
				{
					Console.Write("\nInvalid entry.  Please try again (0 for main menu):  ");
					detailChoice = Console.ReadLine();
				}

				if (Int32.Parse(detailChoice) == 0)
					await Run();

				while (!drinks.Any(c => c.Id == Int32.Parse(detailChoice)))
				{
					Console.Write("\nInvalid choice, please try again (0 for main menu):  ");
					detailChoice = Console.ReadLine();

					if (Int32.Parse(detailChoice) == 0)
						await Run();
				}

				await ShowDrinkDetail(Int32.Parse(detailChoice));
				break;
			}
		}

		public async Task ShowDrinkDetail(int choice)
		{
			DrinkDetailsDto selectedDrink = (await _controller.GetDrinkDetail(choice));

			Console.Clear();

			Console.WriteLine($"{selectedDrink.Name}");
			Console.WriteLine($"\nDrink Category:  {selectedDrink.Category}");
			Console.WriteLine($"\nGlass:  {selectedDrink.Glass}");
			Console.WriteLine($"\nAlcoholic or not:  {selectedDrink.Alcoholic}");

			var instructionsTable = new Table();

			instructionsTable.Title($"Instructions:  {selectedDrink.Instructions}");
			instructionsTable.AddColumn(new TableColumn("Ingredients").Centered());
			instructionsTable.AddColumn(new TableColumn("Measurements").Centered());
			instructionsTable.Expand();

			foreach (var ingredient in selectedDrink.Ingredients)
			{
				var ingredientName = ingredient.Name;
				var measurement = ingredient.Measure;

				instructionsTable.AddRow(ingredientName, measurement);
			}

			var layout = new Panel(new Rows(
			instructionsTable
			));
			layout.Expand();

			AnsiConsole.Write(layout);

			Console.WriteLine("\nPress any key for the main menu...");
			Console.ReadKey();
		}
	}
}
