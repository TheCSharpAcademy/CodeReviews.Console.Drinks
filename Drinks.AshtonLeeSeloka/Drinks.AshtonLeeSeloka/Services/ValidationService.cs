using HttpRequests.Models;
using HttpRequests.Views;
namespace HttpRequests.Services;

internal class ValidationService
{
	public readonly DrinkViews drinkViews = new DrinkViews();
	public int UserInput(string message, int indexRange)
	{
		while (true)
		{
			string userInput = drinkViews.UserInput(message);
			if (userInput == "0")
				return 0;

			if (int.TryParse(userInput, out _))
			{
				int userInputAsInt = Convert.ToInt32(userInput);
				if (userInputAsInt > 0 && userInputAsInt <= indexRange)
				{
					return userInputAsInt;
				}
			}
			else
				continue;
		}
	}

	public List<string>? GetIngredients(Drink drink)
	{
		List<string>? ingredients = new();

		if (drink.Ingredient1 != null)
			ingredients.Add(drink.Ingredient1);

		if (drink.Ingredient2 != null)
			ingredients.Add(drink.Ingredient2);

		if (drink.Ingredient3 != null)
			ingredients.Add(drink.Ingredient3);

		if (drink.Ingredient4 != null)
			ingredients.Add(drink.Ingredient4);

		if (drink.Ingredient5 != null)
			ingredients.Add(drink.Ingredient5);

		if (drink.Ingredient6 != null)
			ingredients.Add(drink.Ingredient6);

		if (drink.Ingredient7 != null)
			ingredients.Add(drink.Ingredient7);

		if (drink.Ingredient8 != null)
			ingredients.Add(drink.Ingredient8);

		if (drink.Ingredient9 != null)
			ingredients.Add(drink.Ingredient9);

		if (drink.Ingredient10 != null)
			ingredients.Add(drink.Ingredient10);

		if (drink.Ingredient11 != null)
			ingredients.Add(drink.Ingredient11);

		if (drink.Ingredient12 != null)
			ingredients.Add(drink.Ingredient12);

		if (drink.Ingredient13 != null)
			ingredients.Add(drink.Ingredient13);

		if (drink.Ingredient14 != null)
			ingredients.Add(drink.Ingredient14);

		if (drink.Ingredient15 != null)
			ingredients.Add(drink.Ingredient15);

		return ingredients;
	}

	public List<string>? GetMeasures(Drink drink)
	{
		List<string>? Measure = new();

		if (drink.Measure1 != null)
			Measure.Add(drink.Measure1);
		else
			Measure.Add("-");

		if (drink.Measure2 != null)
			Measure.Add(drink.Measure2);
		else
			Measure.Add("-");

		if (drink.Measure3 != null)
			Measure.Add(drink.Measure3);
		else
			Measure.Add("-");

		if (drink.Measure4 != null)
			Measure.Add(drink.Measure4);
		else
			Measure.Add("-");

		if (drink.Measure5 != null)
			Measure.Add(drink.Measure5);
		else
			Measure.Add("-");

		if (drink.Measure6 != null)
			Measure.Add(drink.Measure6);
		else
			Measure.Add("-");

		if (drink.Measure7 != null)
			Measure.Add(drink.Measure7);
		else
			Measure.Add("-");

		if (drink.Measure8 != null)
			Measure.Add(drink.Measure8);
		else
			Measure.Add("-");

		if (drink.Measure9 != null)
			Measure.Add(drink.Measure9);
		else
			Measure.Add("-");

		if (drink.Measure10 != null)
			Measure.Add(drink.Measure10);
		else
			Measure.Add("-");

		if (drink.Measure11 != null)
			Measure.Add(drink.Measure11);
		else
			Measure.Add("-");

		if (drink.Measure12 != null)
			Measure.Add(drink.Measure12);
		else
			Measure.Add("-");

		if (drink.Measure13 != null)
			Measure.Add(drink.Measure13);
		else
			Measure.Add("-");

		if (drink.Measure14 != null)
			Measure.Add(drink.Measure14);
		else
			Measure.Add("-");

		if (drink.Measure15 != null)
			Measure.Add(drink.Measure15);
		else
			Measure.Add("-");

		return Measure;
	}
}
