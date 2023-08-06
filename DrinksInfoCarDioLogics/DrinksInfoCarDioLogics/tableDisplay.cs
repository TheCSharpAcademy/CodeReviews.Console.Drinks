using ConsoleTableExt;
using System.Diagnostics.CodeAnalysis;

namespace DrinksInfoCarDioLogics;

public class TableDisplay
{
    public static void ShowTable<T>(List<T> tableData, [AllowNull] string tableName) where T : class
    {
        Console.Clear();

        if (tableData == null)
            tableName = "";

        Console.WriteLine("\n\n");

        ConsoleTableBuilder
            .From(tableData)
            .WithColumn(tableName)
            .ExportAndWriteLine();
        Console.WriteLine("\n\n");
    }
}


