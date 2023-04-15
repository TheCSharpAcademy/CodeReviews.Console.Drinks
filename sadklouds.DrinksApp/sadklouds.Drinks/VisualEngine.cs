using ConsoleTableExt;
using System.Diagnostics.CodeAnalysis;

namespace sadklouds.Drinks
{
    internal class VisualEngine
    {
        public static void ShowTable<T>(List<T> tableData, [AllowNull] string tableName) where T : class
        {
            Console.Clear();
            if (tableData == null)
            {
                tableName = "";
            }
            Console.WriteLine();

            ConsoleTableBuilder
                .From(tableData)
                .WithColumn(tableName)
                .WithFormat(ConsoleTableBuilderFormat.Alternative)
                .ExportAndWriteLine(TableAligntment.Center);
            Console.WriteLine();
        }
    }
}
