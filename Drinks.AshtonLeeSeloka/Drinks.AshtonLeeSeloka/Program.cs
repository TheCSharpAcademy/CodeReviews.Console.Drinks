using HttpRequests.Models;
using HttpRequests.Repositories;
using HttpRequests.Services;
using HttpRequests.Views;

DrinkService _drinkService = new DrinkService();
DrinkViews _drinkViews = new DrinkViews();
ValidationService _validationService = new ValidationService();

while (true)
{
	Console.Clear();

	
	List<Drink>? categories = await _drinkService.GetCategoriesAsync();
	_drinkViews.DisplayCategoriesAsTable(categories);
	int input = _validationService.UserInput($"Make your selection, only integer's between 0 & {categories.Count} are acceptable\n", categories.Count());

	if (input == 0)
		Environment.Exit(1);

	string? selectedCategory = categories[(input-1)].Category;
	List<Drink>? drinks = await _drinkService.GetDrinksAsync(selectedCategory);
	string selectedDrink = _drinkViews.displayDrinks(drinks);

	if (selectedDrink == "exit")
		continue;

	Drink? drinkDetails = await _drinkService.GetDrinkDetailsAsync(selectedDrink);
	List<string>? ingredients = _validationService.GetIngredients(drinkDetails);
	List<string>? measure = _validationService.GetMeasures(drinkDetails);
	_drinkViews.DisplayDrinkDetails(drinkDetails, ingredients, measure);
}




