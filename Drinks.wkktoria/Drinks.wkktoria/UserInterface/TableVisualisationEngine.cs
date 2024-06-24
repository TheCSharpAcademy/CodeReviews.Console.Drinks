using ConsoleTableExt;

namespace Drinks.wkktoria.UserInterface;

internal static class TableVisualisationEngine
{
    internal static void ShowTable<T>(List<T> tableData, string? tableName) where T : class
    {
        Console.Clear();

        tableName ??= string.Empty;

        ConsoleTableBuilder
            .From(tableData)
            .WithColumn(tableName)
            .ExportAndWriteLine();
    }
}