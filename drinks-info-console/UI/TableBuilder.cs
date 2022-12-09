using System.ComponentModel.DataAnnotations;
using ConsoleTableExt;

namespace drinks_info_console.UI;

public class TableBuilder
{
    public void DisplayTable<T>(List<T> listOfObjectsToBuildTable, [Required] string columnName) where T : class
    {
        Console.Clear();

        ConsoleTableBuilder
            .From(listOfObjectsToBuildTable)
            .WithColumn(columnName)
            .ExportAndWriteLine();

        Console.WriteLine();
    }
}
