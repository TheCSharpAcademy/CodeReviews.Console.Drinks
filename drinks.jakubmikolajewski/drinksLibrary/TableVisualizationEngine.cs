using Spectre.Console;
using System.Reflection;

namespace drinksLibrary;

public class TableVisualizationEngine
{
    public static void ShowTable<T>(List<T> inputList, string drinkChoice) where T : class
    {
        var table = new Table();
        table.Title = new TableTitle(drinkChoice, style: "underline yellow");
        table.AddColumns("Property", "Value");

        foreach (PropertyInfo property in inputList.ElementAt(0).GetType().GetProperties())
        {
            string? value = Convert.ToString(property.GetValue(inputList.ElementAt(0), null));

            if (!string.IsNullOrWhiteSpace(value))
            {
                table.AddRow(property.Name, value);
            }              
        }
        AnsiConsole.Write(table);
    }

    public static string ShowChoicesMenu(List<string> choicesList, string title)
    {
        return AnsiConsole.Prompt(new SelectionPrompt<string>()
            .Title(title)
            .AddChoices(choicesList));
    }
}
