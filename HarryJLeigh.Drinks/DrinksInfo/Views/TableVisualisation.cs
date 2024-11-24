using ConsoleTableExt;
using DrinksInfo.Models;
using DrinksInfo.Utilities;

namespace DrinksInfo.Views;

public class TableVisualisation
{
    internal static void ShowTable<T>(List<T> tableData, (string name1, string? name2) tableNames) where T : class
    {
        Console.Clear();
        var columnNames = tableNames.name2 is null 
            ? new[] { tableNames.name1 } 
            : new[] { tableNames.name1, tableNames.name2 };

        ConsoleTableBuilder
            .From(tableData)
            .WithColumn(columnNames)
            .ExportAndWriteLine();
    }
    
    internal static void ShowIngredients(List<string> tableData, string tableName) 
    {
        Console.Clear();
        if (tableName == null)
            tableName = "";
        
        var validData = tableData.Select(item => new Ingredient { IngredientName = item }).ToList();
        ConsoleTableBuilder.From(validData)
            .WithColumn(tableName)
            .ExportAndWriteLine();
    }
}