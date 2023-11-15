using Drinks.j_nas.Models;
using Spectre.Console;

namespace Drinks.j_nas
{
    internal static class TableVisualizationEngine
    {
        public static void RenderTable(DrinkDetail data)
        {
            
            var infoTable = new Table();

            infoTable.Title($"[green]{data.StrDrink}[/]");
            infoTable.AddColumn(new TableColumn("Drink Category").Centered());
            infoTable.AddColumn(new TableColumn($"{data.StrCategory}").Centered());
            infoTable.AddRow("Glass", data.StrGlass);
            infoTable.Expand();

            var instructionsTable = new Table();
            
            instructionsTable.Title($"{data.StrInstructions}");
            instructionsTable.AddColumn(new TableColumn("Ingredients").Centered());
            instructionsTable.AddColumn(new TableColumn("Measurements").Centered());
            instructionsTable.Expand();

            for (var i = 1; i < 15; i++)
            {
                var ingredient = $"StrIngredient{i}";
                var measurement = $"StrMeasure{i}";

                if (data.GetType().GetProperty(ingredient).GetValue(data, null) != null && data.GetType().GetProperty(measurement).GetValue(data, null) != null)
                {
                    var ingredientValue = data.GetType().GetProperty(ingredient).GetValue(data, null).ToString();
                    var measurementValue = data.GetType().GetProperty(measurement).GetValue(data, null).ToString();


                    instructionsTable.AddRow(ingredientValue, measurementValue);
                }
            }
            
            var layout = new Panel(new Rows(
                infoTable,
                instructionsTable
            ));
            layout.Expand();

            AnsiConsole.Write(layout);
            
            AnsiConsole.WriteLine("Press enter to return to the main menu");
            Console.ReadLine();
        }
        
    }
}
