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

    private List<CategoryModel> Menu()
    {
        List<CategoryModel> categories = drinksService.GetCategories();

        string[] headers = new string[] { "", "DRINK CATEGORIES" };
        FormatMenu(categories);
        Console.Clear();
        display.DisplayTable(categories, headers);

        return categories;
    }

    private string GetMenuChoice(List<CategoryModel> menuList)
    {
        string choice = Console.ReadLine()!;

        while (Validator.IsValidChoice(choice, menuList) == false)
        {
            display.PromptInvalid();
            choice = Console.ReadLine()!;
        }

        choice = menuList[int.Parse(choice)-1].strCategory!;
        return choice;
    }

    private static void FormatMenu(List<CategoryModel> categories)
    {
        foreach (CategoryModel category in categories)
        {
            category.Number = categories.IndexOf(category) + 1;
        }

        categories.Add(new CategoryModel
        {
            Number = categories.Count + 1,
            strCategory = "QUIT"
        });
    }
}
