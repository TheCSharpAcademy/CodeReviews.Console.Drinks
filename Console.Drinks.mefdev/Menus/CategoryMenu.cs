using Dtos;
using Spectre.Console;

namespace Menus;

public static class CategoryMenu
{
    public static void DisplayCategories(CategoryList categories)
    {
        var table = new Table();
        table.AddColumn("[lightskyblue1] Category names [/]");
        table.Border = TableBorder.Rounded;
        table.BorderColor(Color.DodgerBlue1);
        table.Width(150);
        foreach (var category in categories.drinks)
        {
            table.AddRow($"[lightskyblue1]{category.strCategory}[/]");
        }
        AnsiConsole.Write(table.Centered());
    }
}