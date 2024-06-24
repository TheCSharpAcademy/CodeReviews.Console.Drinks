using Spectre.Console;

namespace DrinksInfo.StevieTV.Helpers;

public class TableVisualisation
{
    public static Table ShowTable<T>(List<T> tableData) where T : class
    {
        var table = new Table();
        var props = tableData.First().GetType().GetProperties().ToList();
        
        foreach (var prop in props)
        {
            table.AddColumn(prop.Name);
        }

        foreach (var tableRow in tableData)
        {
            var tableRowValues = new List<string>();
            foreach (var prop in props)
            {
                tableRowValues.Add(prop.GetValue(tableRow).ToString());
            }

            table.AddRow(tableRowValues.ToArray());
        }
        
        return table;
    }
}