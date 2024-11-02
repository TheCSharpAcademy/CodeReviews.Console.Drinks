using DrinksInfo.Class_Objects;
using Spectre.Console;

namespace DrinksInfo;

public class DisplayData
{
    public void ShowTable<T>(List<T> items, string title, Func<T, string> getID, Func<T, string> getName)
    {
        var table = new Table();
        bool isAlternateRow = false;
        table.Title(title);
        table.BorderColor(Color.DarkSlateGray1);
        table.Border(TableBorder.Rounded);
        table.AddColumn(new TableColumn("[cyan1]ID[/]").LeftAligned());
        table.AddColumn(new TableColumn($"[green1]{title}[/]").RightAligned());

        foreach (T item in items)
        {
            var color = isAlternateRow ? "grey" : "blue";
            table.AddRow(
                $"[{color}]{getID(item)}[/]",
                $"[{color}]{getName(item)}[/]"
            );
            isAlternateRow = !isAlternateRow;
        }
        Console.Clear();
        AnsiConsole.Write(table);
    }

    public void ShowDrinkRecipe(Drink drinkInfo)
    {
        var table = new Table();
        string ingredientList = string.Join("\n", drinkInfo.CombinedIngMsrList.Select(pair => $"• {pair}"));
        string formattedInstructions = string.Join("\n• ",
                drinkInfo.Instructions.Split(". ")
                .Select(sentence => sentence.Trim()));
        formattedInstructions = "• " + formattedInstructions;

        table.Title($"{drinkInfo.StrDrink} Recipe");
        table.BorderColor(Color.DarkSlateGray1);
        table.Border(TableBorder.Rounded);
        table.AddColumn(new TableColumn("[cyan1]Name[/]").LeftAligned());
        table.AddColumn(new TableColumn("[green1]Instructions[/]").LeftAligned());
        table.AddColumn(new TableColumn("[blue1]Ingredients[/]").LeftAligned());
        table.AddColumn(new TableColumn("[yellow1]Glass[/]").RightAligned());

        table.AddRow(
            $"[grey]{drinkInfo.StrDrink}[/]",
            $"[blue]{formattedInstructions}[/]",
            $"[grey]{ingredientList}[/]",
            $"[blue]{drinkInfo.Glass}[/]"
        );
        Console.Clear();
        AnsiConsole.Write(table);
    }
}
