using Dtos;
using Spectre.Console;

namespace Menus;

public static class DrinkMenu
{
    public static void DisplayDrinks(DrinkList drinkList)
    {
        var table = new Table();
        table.AddColumn("[lightskyblue1] Id [/]");
        table.AddColumn("[lightskyblue1] ImgUrl [/]");
        table.AddColumn(new TableColumn($"[skyblue1] name [/]").Centered());
        table.Border = TableBorder.Rounded;
        table.BorderColor(Color.DodgerBlue1);
        foreach (var drink in drinkList.drinks)
        {
            table.AddRow($"[lightskyblue1]{drink.idDrink}[/]", $"[skyblue1]{drink.strDrinkThumb}[/]", $"[skyblue1]{drink.strDrink}[/]");
        }
        AnsiConsole.Write(table.Centered());
    }

    public static void RenderLine(string color, string title)
    {
        var rule = new Rule($"[{color}]{title}[/]");
        rule.RuleStyle($"{color} dim");
        AnsiConsole.Write(rule);
    }
}