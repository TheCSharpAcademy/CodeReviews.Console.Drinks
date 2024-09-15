using drinks_info.Models;
using Spectre.Console;

namespace Drinks_Info.Lawang.Models;

public static class Visual
{
    public static void ShowCategoryTable(Categories tableData, string? tableName = "")
    {
        Table table = new Table()
           .AddColumn(new TableColumn($"[green]{tableName}[/]").Centered())
           .ShowRowSeparators().Centered();

        foreach (var category in tableData.CategoriesList)
        {
            table.AddRow(category.strCategory);
        }

        AnsiConsole.Write(table);
        AnsiConsole.MarkupLine("[grey bold](press '0' to exit application.)[/]");
    }

    public static void ShowTitle(string title)
    {
        //To show the project title "Coding Tracker" in figlet text
        var titlePanel = new Panel(new FigletText($"{title}").Color(Color.Red))
                        .BorderColor(Color.Aquamarine3)
                        .PadTop(1)
                        .PadBottom(1)
                        .Header(new PanelHeader("[blue3 bold]APPLICATION[/]"))
                        .Border(BoxBorder.Double)
                        .Expand();


        AnsiConsole.Write(titlePanel);
    }

    public static void ShowDrinksTable(Drinks drinksTable, string? tableName = "")
    {
        Table table = new Table()
           .AddColumns(new TableColumn("[green]ID[/]").Centered(), new TableColumn($"[green]{tableName}[/]").Centered()).Centered()
           .ShowRowSeparators();

        foreach (var category in drinksTable.DrinksList)
        {
            table.AddRow(category.idDrink ?? "" , category.strDrink ?? "");
        }

        AnsiConsole.Write(table);
    }

    public static void ShowDetailTable(List<Detail> detailList)
    {
        Table table = new Table()
            .AddColumns(new TableColumn("[bold]Key[/]").Centered(), new TableColumn("[bold]Value[/]").Centered()).Centered()
            .ShowRowSeparators();

        foreach(var value in detailList)
        {
            table.AddRow(value.Key ?? "", value.Value?.ToString() ?? "");
        }

        AnsiConsole.Write(table);
        AnsiConsole.Markup("[grey bold]Press 'Enter' to continue.[/]");
    }
}
