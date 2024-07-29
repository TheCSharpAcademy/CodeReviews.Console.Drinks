using Drinks.Service;
using Drinks.UI;
using Spectre.Console;

var service = new ApiService("https://www.thecocktaildb.com/api/json/v1/1");
UI.Clear();

while (true)
{
    var drinkCategories = service.GetDrinkCategories();

    var category = UI.SelectCategory(drinkCategories);

    var drinks = service.GetDrinksByCategory(category);

    var drink = UI.SelectDrink(category, drinks);

    var information = service.GetDrinkInfo(drink);

    var drinkInfo = information.Drinks.First();

    UI.ShowDrinkInfo(drinkInfo);

    var continueSearch = AnsiConsole.Prompt(
        new SelectionPrompt<string>()
            .Title("Do you want to search for another drink?")
            .AddChoices("Yes", "No"));

    if (continueSearch == "No")
    {
        break;
    }
    UI.Clear();
}