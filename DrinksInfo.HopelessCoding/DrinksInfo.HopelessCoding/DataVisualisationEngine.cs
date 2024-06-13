using DrinksInfo.HopelessCoding.Models;
using Spectre.Console;

namespace DrinksInfo.HopelessCoding;

public class DataVisualisationEngine
{
    public static void GenerateDrinkTable(List<Drink> tableData)
    {
        var drinksTable = new Table();
        drinksTable.Title = new TableTitle($"[aqua]DRINKS[/]");
        drinksTable.Border = TableBorder.Rounded;
        drinksTable.AddColumn("[aqua]Drink ID[/]");
        drinksTable.AddColumn("[aqua]Drink Name[/]");
        drinksTable.Columns[0].Padding(1, 0);

        foreach (var drink in tableData)
        {
            drinksTable.AddRow(drink.idDrink, drink.strDrink);
        }

        AnsiConsole.Write(drinksTable);
    }

    internal static void ShowDrinkDetails(List<(string, string)> tableData)
    {
        Console.Clear();

        if (tableData.Count < 1)
        {
            Console.WriteLine("No drink details available.");
            return;
        }

        var drinkDetailsTable = new Table();
        drinkDetailsTable.Title = new TableTitle($"[aqua]{tableData[0].Item2}[/]");
        drinkDetailsTable.Border = TableBorder.Rounded;
        drinkDetailsTable.AddColumn("[aqua]Property[/]");
        drinkDetailsTable.AddColumn("[aqua]Value[/]");
        drinkDetailsTable.Columns[0].Padding(1, 0);

        for (int i = 1; i < tableData.Count; i++)
        {
            var drinkDetail = tableData[i];
            drinkDetailsTable.AddRow(drinkDetail.Item1, drinkDetail.Item2);
        }

        AnsiConsole.Write(drinkDetailsTable);
    }
}
