using System.Diagnostics.CodeAnalysis;
using ConsoleTableExt;

namespace DrinksInfo.kalsson;

public class TableVisualisationEngine
{
    /// Displays a table visualisation of the provided data.
    /// @param <T> The type of data in the table.
    /// @param tableData The list of data to be displayed in the table.
    /// @param tableName The name of the table (optional). If not provided, an empty string will be used.
    /// /
    public static void ShowTable<T>(List<T> tableData, [AllowNull] string tableName) where T : class
    {
        ConsoleColor originalBackground = Console.BackgroundColor;
        ConsoleColor originalForeground = Console.ForegroundColor;

        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.White;

        Console.Clear();

        if (tableName == null)
            tableName = "";

        Console.WriteLine("\n\n");

        ConsoleTableBuilder
            .From(tableData)
            .WithColumn(tableName)
            .ExportAndWrite();

        Console.WriteLine("\n\n");

        Console.BackgroundColor = originalBackground;
        Console.ForegroundColor = originalForeground;
    }
}