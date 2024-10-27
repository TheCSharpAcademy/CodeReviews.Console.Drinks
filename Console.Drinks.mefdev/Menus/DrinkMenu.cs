using Dtos;
using Spectre.Console;
using Services;

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

    public static async Task DisplayDrinkDetails(dynamic drinkDetails)
    {
        var table = new Table();
        table.AddColumn(new TableColumn("[lightskyblue1] Details [/]").Centered());
        table.AddColumn(new TableColumn("[lightskyblue1] Image [/]").Centered());
        table.BorderColor(Color.DodgerBlue1);
        
        var detailsTable = new Table();
        detailsTable.AddColumn("[skyblue1] Properties [/]");
        detailsTable.AddColumn("[skyblue1] Values [/]");
        detailsTable.BorderColor(Color.DodgerBlue3);
        string imagePath = null;
        var drinkDict = (IDictionary<string, object>)drinkDetails;

        foreach (var kvp in drinkDict)
        {
            if (kvp.Key.Equals("strDrinkThumb", StringComparison.OrdinalIgnoreCase))
            {
                var imgUrl = kvp.Value?.ToString();
                detailsTable.AddRow(kvp.Key, imgUrl ?? "N/A");

                // Download and prepare the image for rendering
                imagePath = await ImageRenderer.RenderImageFromUrl(imgUrl);
            }
            else
            {
                detailsTable.AddRow(kvp.Key, kvp.Value?.ToString() ?? "null");
            }
        }

        // Render image as ANSI markup or show a placeholder
        var imageMarkup = imagePath != null
            ? ImageRenderer.RenderImageAsMarkup(imagePath)
            : new Markup("[red]Image not available[/]");

        // Add the inner details table and image to the main table
        table.AddRow(detailsTable, imageMarkup);

        // Render the main table
        AnsiConsole.Write(table);
    }

    public static void RenderLine(string color, string title)
    {
        var rule = new Rule($"[{color}]{title}[/]");
        rule.RuleStyle($"{color} dim");
        AnsiConsole.Write(rule);
    }
}