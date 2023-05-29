using Drinks.CoreyJordan.UI;
using DrinksLibrary.Data;
using DrinksLibrary.Models;

namespace Drinks.CoreyJordan.Controllers;
public class CategoryController
{
    ConsoleEngine display = new();
    DrinksService drinksService = new();

    public List<DrinkCategory> Menu()
    {
        List<DrinkCategory> categories = drinksService .GetCategories();

        string[] headers = new string[] { "", "DRINK CATEGORIES" };
        FormatMenu(categories);
        display.DisplayTable(categories, headers);

        return categories;
    }

    public string GetMenuChoice<T>(List<T> menuList) where T : class
    {
        string choice = Console.ReadLine()!;

        while (Validator.IsValidChoice(choice, menuList) == false)
        {
            display.PromptInvalid();
            choice = Console.ReadLine()!;
        }

        return choice;
    }

    private static void FormatMenu(List<DrinkCategory> categories)
    {
        foreach (DrinkCategory category in categories)
        {
            category.Number = categories.IndexOf(category) + 1;
        }

        categories.Add(new DrinkCategory
        {
            Number = 0,
            strCategory = "QUIT"
        });
    }
}
