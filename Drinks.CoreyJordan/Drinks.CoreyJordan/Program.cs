using Drinks.CoreyJordan.Controllers;


// Display list of drinks in that category
// Get a choice
// Display that drink
while (true)
{
    var categoryController = new CategoryController();
    string category = categoryController.ManageCategories();
    if (category == "QUIT") break;

    var drinksController = new DrinksController(category);
    string drink = drinksController.ManageDrinks();
    if (drink == "RETURN") continue;

    Console.WriteLine("hmm");
}