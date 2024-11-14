using ConsoleDrinks.AnaClos.Controllers;

var consoleController = new ConsoleController();
string category;
string titleCategory = "Select a categorie";
string color = "green";
string exitOpcion = "Exit";

var serviceController = new ServiceController();
var categoriesController = new CategoriesController(serviceController);
var drinksController = new DrinksController(serviceController);

var listCategories = categoriesController.GetCategories();

if (listCategories != null)
{
    var categoriesNames = categoriesController.GetCategoriesNames(listCategories);
    categoriesNames.Add(exitOpcion);
    category = consoleController.Menu(titleCategory, color, categoriesNames);

    while (category != exitOpcion)
    {
        ShowDrinks(category);

        category = consoleController.Menu(titleCategory, color, categoriesNames);
    }
    return;
}
else
{
    consoleController.ShowMessage("Error, no Drink Categories to select.", "red bold");
}

void ShowDrinks(string category)
{
    int drinkId;
    var listDrinks = drinksController.GetDrinks(category);

    if (listDrinks != null)
    {
        string[] columns = { "DrinkId", "DrinkName" };
        var drinksRecords = drinksController.DrinksToTableRecord(listDrinks);
        consoleController.ShowTable("Drinks", columns, drinksRecords);
        string response = consoleController.GetString("Select a DrinkId, Press 0 to return to Main Menu");
        Console.Clear();

        while (response.Trim() != "0")
        {
            bool ok = int.TryParse(response, out drinkId);
            if (ok)
            {
                ShowDrinkDetails(drinkId);
            }
            else
            {
                consoleController.MessageAndPressKey("You must enter a DrinkId", "red bold");
            }
            consoleController.ShowTable("Drinks", columns, drinksRecords);
            response = consoleController.GetString("Select a DrinkId, Press 0 to return to Main Menu");
            Console.Clear();
        }       
    }
    else
    {
        consoleController.MessageAndPressKey($"There is no Drinks for category {category}", "red bold");
    }
}

void ShowDrinkDetails(int drinkId)
{
    var drink = drinksController.GetDrinkDetails(drinkId);
    if(drink != null)
    {
        var tableRecord = drinksController.DrinkDetailToTableRecord(drink);
        consoleController.ShowTable("Drink", new string[] { "Property", "Value" }, tableRecord);
        consoleController.PressKey("Press a Key to Continue");
        Console.Clear();
    }
    else
    {
        consoleController.MessageAndPressKey("There is no Drink with this Id", "red bold");
    }   
}