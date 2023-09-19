using ConsoleTableExt;

namespace MiroiuDev.DrinksInfo;
internal static class TableVisualisationEngine
{
    public static void ShowTable<T>(List<T> tableData, string tableName = "") where T : class
    {
        Console.WriteLine("\n\n");

        ConsoleTableBuilder.From(tableData).WithFormat(ConsoleTableBuilderFormat.Alternative).ExportAndWriteLine();

        Console.WriteLine("\n\n");
    }
}
