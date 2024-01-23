using ConsoleTableExt;

namespace DrinksInfo;

internal class TableVisualizerEngine
{

    internal static void DisplayTable<T>(List<T>table, string tableName = "") where T : class
    {
        Console.Clear();

        ConsoleTableBuilder.From(table).WithColumn(tableName).ExportAndWriteLine(TableAligntment.Center);

    }

}
