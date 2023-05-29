using Drinks.CoreyJordan.UI;
using DrinksLibrary.Data;
using DrinksLibrary.Models;

namespace Drinks.CoreyJordan.Controllers;
public class CategoryController
{
    ConsoleEngine display = new();
    DrinksService drinksService = new();

    public string ManageCategories()
    {
        var categories = Menu();
        return GetMenuChoice(categories);
    }

    private List<DrinkCategoryModel> Menu()
    {
        List<DrinkCategoryModel> categories = drinksService.GetCategories();

        string[] headers = new string[] { "", "DRINK CATEGORIES" };
        FormatMenu(categories);
        display.DisplayTable(categories, headers);

        return categories;
    }

    private string GetMenuChoice(List<DrinkCategoryModel> menuList)
    {
        string choice = Console.ReadLine()!;

        while (Validator.IsValidChoice(choice, menuList) == false)
        {
            display.PromptInvalid();
            choice = Console.ReadLine()!;
        }

        choice = menuList[int.Parse(choice)-1].strCategory;
        return choice;
    }

    private static void FormatMenu(List<DrinkCategoryModel> categories)
    {
        foreach (DrinkCategoryModel category in categories)
        {
            category.Number = categories.IndexOf(category) + 1;
        }

        categories.Add(new DrinkCategoryModel
        {
            Number = categories.Count + 1,
            strCategory = "QUIT"
        });
    }
}
