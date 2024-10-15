using ConsoleTableExt;
using DrinksInfo.Models;
using Spectre.Console;

namespace DrinksInfo
{
    public class TableVisualisationEngine
    {
        public static void ShowTable<T>(List<T> tableData, string tableName) where T : class
        {
            
            if (tableName == null)
                tableName = " ";

            Console.WriteLine("\n");

        

            ConsoleTableBuilder
              .From(tableData)
              .WithColumn(tableName) 
              .WithFormat(ConsoleTableBuilderFormat.Alternative)
              .ExportAndWriteLine(TableAligntment.Center);
             Console.WriteLine("\n"); 
        }

        public static void ShowDrinksInfo(List<object> tableData, string tableName)
        {
            string key = "", value = "";
            Table table = new Table();
            table.AddColumn("Stats");
            table.AddColumn("Information");

            foreach (object obj in tableData)
            {
                var keyProperty = obj.GetType().GetProperty("Key");
                var valueProperty = obj.GetType().GetProperty("Value");
                if (keyProperty != null && valueProperty != null)
                {
                    key = keyProperty.GetValue(obj)?.ToString();
                    value = valueProperty.GetValue(obj)?.ToString(); 
                    table.AddRow(key, value);
                    table.AddEmptyRow();
                }   
            }

            AnsiConsole.Write(table);
            Console.WriteLine("\n");
        }

        internal static string ShowCategory(List<Category> categories, string v)
        {
            List<string> categoryList = new();
            foreach(var category in categories)
            {
                categoryList.Add($"[springgreen2]{category.StrCategory}[/]");
            }

            categoryList.Add("[yellow1]View Favorite Drink[/]");
            categoryList.Add("[yellow1]View Most Searched Drink[/]");
            categoryList.Add("[red bold]Exit[/]");

            string choice = AnsiConsole.Prompt(new SelectionPrompt<string>()
                                .Title("Category Menu")
                                .PageSize(categories.Count + 3)
                                .AddChoices(categoryList.ToArray()));
            int first = choice.IndexOf(']') + 1;
            int last = choice.LastIndexOf('[');


            return choice.Substring(first, last - first);
        }
    }
}
