using Drinks.barakisbrown;

while (true)
{
    var userInput = new UserInput();
    var Category = userInput.PickCategory();
    var drink = userInput.PickDrink(Category);
    var drinks = DrinksService.GetDrink(drink);
    TableVisualEngine.ShowDrinkInfo(drinks, drink.StrDrink);
}