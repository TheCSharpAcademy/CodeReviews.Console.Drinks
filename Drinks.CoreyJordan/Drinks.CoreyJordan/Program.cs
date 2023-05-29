using Drinks.CoreyJordan.Controllers;

// Display that drink
while (true)
{
    var categoryController = new CategoryController();
    string category = categoryController.ManageCategories();
    if (category == "QUIT") break;

    var drinksController = new DrinksController(category);
    string drink = drinksController.ManageDrinks();
    if (drink == "RETURN") continue;

    var drinkInfoController = new DrinkInfoController(drink);
    drinkInfoController.ShowDrink();
}