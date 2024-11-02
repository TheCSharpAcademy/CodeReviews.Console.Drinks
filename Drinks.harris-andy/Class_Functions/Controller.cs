using DrinksInfo.Class_Objects;
using System.Data;

namespace DrinksInfo;

public class Controller
{
    DrinksService drinksService = new();
    UserInput userInput = new();
    DisplayData display = new();

    internal void ShowCategories()
    {
        List<Category> categoryList = drinksService.GetCategories();
        display.ShowTable(categoryList, "Drink Categories",
            cat => cat.ID.ToString(),
            cat => cat.StrCategory);
        GetCategory(categoryList);
    }

    internal void GetCategory(List<Category> categoryList)
    {
        int high = categoryList.Count();
        int menuChoice = userInput.GetMenuChoice(0, high, "Select a category by ID or Press 0 to Exit:");
        if (menuChoice == 0)
            Environment.Exit(0);
        string category = categoryList
            .Where(cat => cat.ID == menuChoice)
            .Select(cat => cat.StrCategory)
            .First();
        List<Drink> drinksList = drinksService.GetDrinksByCategory(category);
        ShowDrinks(drinksList);
    }

    internal void ShowDrinks(List<Drink> drinksList)
    {
        display.ShowTable(drinksList, "Drinks",
            drink => drink.ID.ToString(),
            drink => drink.StrDrink);

        GetDrinkInfo(drinksList);
    }

    internal void GetDrinkInfo(List<Drink> drinksList)
    {
        int menuChoice = userInput.GetMenuChoice(1, drinksList.Count(), "Select a drink by ID:");
        (int idDrink, string drinkName) = drinksList
            .Where(drink => drink.ID == menuChoice)
            .Select(drink => (drink.DrinkID, drink.StrDrink))
            .First();

        Drink drinkInfo = drinksService.GetDrink(idDrink) switch
        {
            null => throw new InvalidOperationException($"{drinkName} was not found"),
            Drink drink => drink
        };

        if (drinkInfo != null)
        {
            drinkInfo.CombineIngredientsMeasures();
            ShowDrinkInfo(drinkInfo);
        }
    }

    internal void ShowDrinkInfo(Drink drink)
    {
        display.ShowDrinkRecipe(drink);
        userInput.WaitToContinue();
        ShowCategories();
    }
}