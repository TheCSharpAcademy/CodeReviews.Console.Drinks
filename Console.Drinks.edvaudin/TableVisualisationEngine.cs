using ConsoleTableExt;
using System.Diagnostics.CodeAnalysis;

namespace DrinksInfo;

internal class TableVisualisationEngine
{
    public static void ShowTable<T>(List<T> tableData, [AllowNull] string tableName) where T : class
    {
        Console.Clear();
        if (tableData == null)
        {
            tableName = string.Empty;
        }
        Console.WriteLine("\n\n");
        ConsoleTableBuilder.From(tableData)
                           .WithColumn(tableName)
                           .WithFormat(ConsoleTableBuilderFormat.Alternative)
                           .ExportAndWriteLine(TableAligntment.Center);
        Console.Write("\n\n");
    }
}
