using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Drinks.Models;
using Spectre.Console;
namespace Drinks;

internal class VisualizationEngine
{

    internal static void DisplayContinueMessage()
    {
        AnsiConsole.Markup($"Press [blue]Enter[/] to continue\n");
        Console.ReadLine();
    }

    public static Table CreateTable(string title, string footer)
    {
        var table = new Table();
        table.Title(title.ToUpper());
        table.Caption(footer);
        table.Border = TableBorder.Square;
        table.ShowRowSeparators = true;
        return table;
    }

    internal static void DisplayDrinks(IEnumerable<Drink> drinks, [AllowNull] string title)
    {
        if (title == null)
        {
            title = "";
        }
        var table = CreateTable(title, $"Displaying [blue]{drinks.Count()}[/] records");
        table.AddColumns(["Drink Id", "Drink Name"]);
        foreach (var drink in drinks)
        {
            table.AddRow(drink.idDrink, drink.strDrink);
        }
        AnsiConsole.Write(table);
    }

    internal static async Task DisplayDrinkDetailsAsync(DrinkDetail drinkDetail, string title)
    {
        if (title == null)
        {
            title = "";
        }
        var table = CreateTable(title, "");
        string formattedName = "";
        table.AddColumns([$"[green]Description[/]", $"[maroon]Details[/]"]);
        foreach (PropertyInfo prop in drinkDetail.GetType().GetProperties())
        {
            formattedName = prop.Name.Contains("str") ? formattedName = prop.Name.Substring(3) : prop.Name;
            if (!string.IsNullOrEmpty(prop.GetValue(drinkDetail)?.ToString()))
            {
                table.AddRow(
                        new Markup($"[green]{formattedName}[/]"),
                        new Markup($"[maroon]{prop.GetValue(drinkDetail).ToString()}[/]")
                    );
            }
        }
        AnsiConsole.Write(table);
    }
}