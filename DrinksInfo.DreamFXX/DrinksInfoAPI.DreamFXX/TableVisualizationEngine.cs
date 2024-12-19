using ConsoleTableExt;

namespace DrinksInfo.DreamFXX;

public class TableVisualizationEngine
{
    public static void ShowTable<T>(List<T> tableData, string? tableName) where T : class
    {
        Console.Clear();

        
        if (tableName == null)
            tableName = "";

        Console.WriteLine("\n\n");
        ConsoleTableBuilder.From(tableData).WithTitle(tableName).ExportAndWriteLine();
        Console.WriteLine("\n\n");
    }
}