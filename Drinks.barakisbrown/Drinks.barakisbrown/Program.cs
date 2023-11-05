using Drinks.barakisbrown;
using Drinks.barakisbrown.Models;

var userInput = new UserInput();
var Category = userInput.PickCategory();
var drink = userInput.PickDrink(Category);
var drinks = DrinksService.GetDrink(drink);
TableVisualEngine.ShowDrinkInfo(drinks.ToList(),drink.StrDrink);