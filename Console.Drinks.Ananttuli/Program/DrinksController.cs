using Spectre.Console;
using DrinksApi.Drinks;

namespace Program;

public class DrinksController
{
    public static void PrintDrinkInfo(DrinkDto drink)
    {
        var table = CreateDrinkTableView();

        foreach (var (key, value) in PrepareDrinkInfoRows(drink))
        {
            if (value == null)
            {
                continue;
            }

            table.AddRow([key, value]);
        }

        AnsiConsole.Write(table);
    }

    private static List<(string, string?)> PrepareDrinkInfoRows(DrinkDto drink)
    {
        var sublistPrefix = "-  ";

        var ingredientText = string.Join(
            "\n",
            drink.Ingredients?
                .Where(ingredient => ingredient != null)
                .Select(ingredient => $"{sublistPrefix}{ingredient}") ?? []
        );

        var measurementText = string.Join(
            "\n",
            drink.Measurements?
                .Where(measurement => measurement != null)
                .Select(measurement => $"{sublistPrefix}{measurement}") ?? []
        );

        return [
            ("Name", drink.Name),
            ("Id", drink.Id),
            ("Type", drink.Type),
            ("Glass", drink.Glass),
            ("Ingredients", ingredientText),
            ("Measurements", measurementText),
        ];
    }

    private static Table CreateDrinkTableView()
    {
        var table = new Table();

        table.AddColumns(["", ""]);
        table.Columns[0].Padding(2, 0);
        table.Columns[1].Padding(2, 0);
        table.ShowRowSeparators = true;
        table.Border(TableBorder.Rounded);
        table.HideHeaders();

        return table;
    }
}