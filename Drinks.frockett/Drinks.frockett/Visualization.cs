using Spectre.Console;
using Drinks.frockett.Models;
using ConsoleTableExt;
using System.Diagnostics.CodeAnalysis;

namespace Drinks.frockett;

public class Visualization
{
    public void PrintTable(List<Category> categories)
    {
        Table table = new Table();
        table.Title("Drinks Menu");
        table.AddColumn("Categories");

        foreach (var category in categories)
        {
            table.AddRow(category.strCategory);
        }

        AnsiConsole.Write(table);
    }

    internal void PrintDrinks(List<Drink> drinks)
    {
        Table table = new Table();
        table.Title("Drinks Menu");
        table.AddColumns(new[] { "Id", "Name" });

        foreach (var drink in drinks)
        {
            table.AddRow(drink.idDrink, drink.strDrink);
        }

        AnsiConsole.Write(table);
    }

    internal void PrintDrinkDetails(DrinkDetail drink)
    {
        string name = drink.StrDrink;
        string category = drink.StrCategory;
        string glass = drink.StrGlass;
        string instructions = drink.StrInstructions;
        string ingredients = drink.ConcatenateIngredients();

        var table = new Table();

        table.AddColumns("Name", "Ingredients", "Category", "Glass", "Instructions");

        table.AddRow(name, ingredients, category, glass, instructions);


        AnsiConsole.Write(table);
    }

    internal void UseOtherLibraryShowTable<T>(List<T> tableData, [AllowNull] string tableName) where T : class
    {
        Console.Clear();

        if (tableName == null)
            tableName = "";

        Console.WriteLine("\n\n");

        ConsoleTableBuilder
            .From(tableData)
            .WithColumn(tableName)
            .WithFormat(ConsoleTableBuilderFormat.Alternative)
            .ExportAndWriteLine(TableAligntment.Center);
        Console.WriteLine("\n\n");
    }
}
