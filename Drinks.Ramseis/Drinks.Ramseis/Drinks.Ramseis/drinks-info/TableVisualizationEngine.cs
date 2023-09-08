using ConsoleTableExt;
using System.Diagnostics.CodeAnalysis;

namespace Drinks.Ramseis
{
    internal class TableVisualizationEngine
    {
        public static void ShowTable<T>(List<T> tableData, [AllowNull] string tableName) where T: class
        {
            Console.Clear();

            tableName = tableName ?? "";

            Console.WriteLine("\n\n");
            ConsoleTableBuilder
                .From(tableData)
                .WithColumn(tableName)
                .WithFormat(ConsoleTableBuilderFormat.Alternative)
                .ExportAndWriteLine(TableAligntment.Center);
            Console.WriteLine("\n\n");
        }
    }
}
