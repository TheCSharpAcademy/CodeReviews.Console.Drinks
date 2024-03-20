using Spectre.Console;

namespace drinksInfo.Fennikko;

public class TableVisualizationEngine
{
    public static void ShowTable<T>(List<T> tableData, string? tableName) where T : class
    {

        AnsiConsole.Clear();

        tableName ??= "";

        var table = new Table();

        table.Caption(tableName).Centered();

        foreach (var column in tableData[0].GetType().GetProperties())
        {
            table.AddColumn(column.Name);
        }

        table.HideHeaders();

        foreach (var row in tableData)
        {
            table.AddRow(row.GetType().GetProperties().Select(column => column.GetValue(row)?.ToString() ?? "").ToArray());
        }

        AnsiConsole.Write(table);
    }
}