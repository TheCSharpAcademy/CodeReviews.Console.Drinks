using Drinks.CoreyJordan.UI;
using DrinksLibrary.Data;
using DrinksLibrary.Models;

namespace Drinks.CoreyJordan.Controllers;
public class DrinksController
{
    public string Drinks { get; }
    DrinksService drinksService = new();
    ConsoleEngine display = new();

    public DrinksController(string drinks)
    {
        Drinks = drinks;
    }

    public string ManageDrinks()
    {
        var drinks = DrinksMenu();
        return GetMenuChoice(drinks);
    }

    private List<DrinkModel> DrinksMenu()
    {
        List<DrinkModel> drinks = drinksService.GetDrinksByCategory(Drinks);
        List<MenuModel> menu = new();
        foreach (var drink in drinks)
        {
            menu.Add(new MenuModel(drinks.IndexOf(drink) + 1, drink));
        }
        menu.Add(new MenuModel(menu.Count + 1, "RETURN"));

        string[] headers = new string[] {"", Drinks.ToUpper()};
        Console.Clear();
        display.DisplayTable(menu, headers);

        return drinks;
    }

    private string GetMenuChoice(List<DrinkModel> menuList)
    {
        string choice = Console.ReadLine()!;
        
        menuList.Add(new DrinkModel()
        {
            idDrink = "RETURN"
        });
        
        while (Validator.IsValidChoice(choice, menuList) == false)
        {
            display.PromptInvalid();
            choice = Console.ReadLine()!;
        }

        choice = menuList[int.Parse(choice) - 1].idDrink!;
        return choice;
    }
}
