using Drinks.CoreyJordan.Controllers;

var categoryController = new CategoryController();
var drinksController = new DrinksController();
// Display list of drinks in that category
// Get a choice
// Display that drink
bool quit = false;
while (quit == false)
{
    var categories = categoryController.Menu();
    string category = categoryController.GetMenuChoice(categories);
    if (category == "0")
    {
        quit = true;
        break;
    }
}