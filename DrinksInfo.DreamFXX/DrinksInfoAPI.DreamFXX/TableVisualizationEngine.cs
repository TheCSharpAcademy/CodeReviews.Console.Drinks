using System.Diagnostics.CodeAnalysis;

namespace DrinksInfo.DreamFXX;

public class TableVisualizationEngine
{
    public static void ShowTable<T>(List<T> tableData, [AllowNull] string tableName) where T : class
    {
        if (tableName == null) 
            tableName = "";

        Console.WriteLine("\n\n");

        
        
    }
}