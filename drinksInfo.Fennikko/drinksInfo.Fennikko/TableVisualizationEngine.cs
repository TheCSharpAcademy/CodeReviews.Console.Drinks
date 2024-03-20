using ConsoleTableExt;

namespace drinksInfo.Fennikko;

public class TableVisualizationEngine
{
    public static void ShowTable<T>(List<T> tableData, string? tableName) where T : class
    {
        Console.Clear();

        tableName ??= "";

        Console.WriteLine("\n\n");

        ConsoleTableBuilder
            .From(tableData)
            .WithColumn(tableName)
            .ExportAndWriteLine(TableAligntment.Center);
        Console.WriteLine("\n\n");
    }
}