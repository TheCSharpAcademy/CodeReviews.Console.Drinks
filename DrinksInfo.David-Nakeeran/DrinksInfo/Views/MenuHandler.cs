using Spectre.Console;
using DrinksInfo.Models;

namespace DrinksInfo.Views;

class MenuHandler
{
    internal void ShowCategoryMenu(List<Category> categories)
    {
        var table = new Table();
        table.AddColumn("Categories Menu");

        foreach (var category in categories)
        {
            if (category.Name == null)
            {
                AnsiConsole.WriteLine("No categories");
                return;
            }
            else
            {
                table.AddRow(category.Name);
            }
        }
        AnsiConsole.Write(table);
    }

    internal void ShowDrinksMenu(List<Drink> drinks)
    {
        Console.Clear();
        var table = new Table();
        table.AddColumns("Drink Id", "Drink Name");

        foreach (var drink in drinks)
        {
            if (drink.Name == null || drink.DrinkId == null)
            {
                AnsiConsole.WriteLine("No categories");
                return;
            }
            else
            {
                table.AddRow(drink.DrinkId, drink.Name);
            }
        }
        AnsiConsole.Write(table);
    }

    internal void ShowDrinkDetailMenu(Dictionary<string, string> drinkDetail)
    {
        Console.Clear();
        var table = new Table();
        table.AddColumns("Name", "Details");

        foreach (var drink in drinkDetail)
        {
            if (drink.Value == "null")
            {
                continue;
            }
            else
            {
                table.AddRow(drink.Key, drink.Value);
            }
        }
        AnsiConsole.Write(table);
    }
}