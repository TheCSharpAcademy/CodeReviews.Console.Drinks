using ConsoleTableExt;
using System.Diagnostics.CodeAnalysis;

namespace DrinksProject.Helpers
{
    public class TableVisualization
    {
        public static void CreateTable<T>(List<T> data, [AllowNull] string tableName) where T : class
        {
            Console.Clear();
            if (tableName == null)
                tableName = "";

            Console.WriteLine("\n\n");

            ConsoleTableBuilder
                .From(data)
                .WithColumn(tableName)
                .WithFormat(ConsoleTableBuilderFormat.Alternative)
                .ExportAndWriteLine(TableAligntment.Center);
            Console.WriteLine("\n\n");
        }

    }

}


// Favourite drinks
// Count the most searched drinks