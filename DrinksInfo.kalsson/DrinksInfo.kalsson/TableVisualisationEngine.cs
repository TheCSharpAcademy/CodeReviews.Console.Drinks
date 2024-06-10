using System.Diagnostics.CodeAnalysis;
using ConsoleTableExt;

namespace DrinksInfo.kalsson;

public class TableVisualisationEngine
{
    /// <summary>
    /// Displays a table with the given table data.
    /// </summary>
    /// <typeparam name="T">The type of the table data.</typeparam>
    /// <param name="tableData">The list of table data to display.</param>
    /// <param name="tableName">The name of the table. If null, an empty string will be used.</param>
    public static void ShowTable<T>(List<T> tableData, [AllowNull] string tableName) where T : class
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