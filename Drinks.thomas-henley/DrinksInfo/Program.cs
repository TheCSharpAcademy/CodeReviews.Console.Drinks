using DrinksInfo;

UserInput userInput = new();

do
{
    var category = userInput.GetCategoriesInput();

    var drink = userInput.GetDrinksInput(category);

    userInput.ShowDrinkDetail(drink);
} while (userInput.Continue());