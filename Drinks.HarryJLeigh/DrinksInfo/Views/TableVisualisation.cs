using ConsoleTableExt;
using DrinksInfo.Models;
using DrinksInfo.Utilities;
using Spectre.Console;

namespace DrinksInfo.Views;

public class TableVisualisation
{
    internal static void ShowDrinks(List<Drink> drinks)
    {
        Console.Clear();
        var table = new Table().AddColumns("ID", "Drink");
        
        foreach (Drink drink in drinks)
        {
            table.AddRow(
                drink.IdDrink.ToString(),
                drink.StrDrink
            );
        }
       
        AnsiConsole.Write(table);
    }

    internal static void ShowDrinkData(List<string> ingredients, List<string> measures)
    {
        Console.Clear();
        var table = new Table().AddColumns("Ingredients", "Measures");

        for (int i = 0; i < measures.Count; i++)
        {
            table.AddRow(ingredients[i], measures[i]);
        }
        AnsiConsole.Write(table);
    }
}