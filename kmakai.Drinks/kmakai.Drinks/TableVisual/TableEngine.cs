using ConsoleTableExt;

namespace kmakai.Drinks.TableVisual;

public class TableEngine
{
    public static void PrintTable<T>(List<T> tableData, string tableName) where T : class
    {
        Console.Clear();
        if (tableName == null) tableName = "Table";
        ConsoleTableBuilder.From(tableData).WithColumn(tableName).WithFormat(ConsoleTableBuilderFormat.Alternative).ExportAndWriteLine(TableAligntment.Center);

    }
}
