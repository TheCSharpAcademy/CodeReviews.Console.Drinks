using DrinksInfo.Models;
using Spectre.Console;

namespace DrinksInfo;
public class TableVisualization
{
    public static void ShowCategoriesTable(List<Category> tableData)
    {
        var table = new Table();

        table.AddColumn("[blue]Categories[/]");

        foreach (var item in tableData)
        {
            table.AddRow(item.strCategory);
        }

        AnsiConsole.Write(table);
    }

    public static void ShowDrinksTable(List<Drink> tableData)
    {
        var table = new Table();

        table.AddColumns("[blue]Id[/]", "[blue]Name[/]");

        foreach (var item in tableData)
        {
            table.AddRow(item.idDrink, item.strDrink);
        }

        AnsiConsole.Write(table);
    }

    public static void ShowDrinkTable(DrinkDetail drink)
    {
        var table = new Table();

        var props = drink.GetType().GetProperties().ToList();

        table.AddColumns("[blue]Property[/]", "[blue]Value[/]");

        foreach (var item in props)
        {
            if (item.GetValue(drink) != null)
            {
                table.AddRow(item.Name, item.GetValue(drink).ToString());
            }
        }

        AnsiConsole.Write(table);
    }
}

