using ConsoleTableExt;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Drinks.maccer989
{
    public class TableVisualisation
    {

        public static void ShowTable<T>(List<T> tableData, [AllowNull] string tableName) where T : class
        {
            Console.Clear();

            if (tableName == null)
                tableName = "";

            Console.WriteLine("\n\n");

            ConsoleTableBuilder
                .From(tableData)
                .WithTitle("Categories")
                .ExportAndWriteLine();
            Console.WriteLine("\n\n");
        }
    }
}
