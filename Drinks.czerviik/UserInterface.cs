using System.Reflection;
using System.Reflection.Metadata;
using Spectre.Console;

namespace drinks_info;

public static class UserInterface
{
    public static string? OptionChoice { get; private set; }
    public static void MainMenu()
    {
        Header("drinks info");

        string[] options = {
                "Pick a category",
                "Exit"};

        ChooseOptions(options);
    }

    public static void CategoryMenu(string[] categoriesArray)
    {
        Header("pick a category");

        ChooseOptions(categoriesArray);
    }

    public static void DrinksMenu(string[] drinksArray)
    {
        Header("pick a drink");

        ChooseOptions(drinksArray);
    }

    public static void DrinkDetailMenu(DrinkDetail drinkDetail)
    {
        Header("drink details");

        DisplayTable(drinkDetail);

        //přidat funkci add to/delete from favourites (chcecknout jeslti už není ve favourites), funkce COunt the most searched drinks
    }

    private static void Header(string headerText)
    {
        Console.Clear();
        Console.WriteLine($"----- {headerText.ToUpper()} -----");
        Console.WriteLine();
    }

    private static void ChooseOptions(string[] options)
    {
        OptionChoice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .HighlightStyle("yellow")
            .AddChoices(options)
            );
    }

    private static void DisplayTable(DrinkDetail drinkDetail)
    {
        var drinkType = drinkDetail.GetType();
        PropertyInfo[] properties = drinkType.GetProperties();

        Console.WriteLine($"DRINK: {properties[0].Name}");

        var table = new Table()
        .AddColumns(drinkDetail.Name.ToUpper(), "")
        .Border(TableBorder.Rounded);


        foreach (var property in properties)
        {
            var modifiedPropertyName = Operations.ModifyPropertyName(property);
            if (property.GetValue(drinkDetail) != null)
                table.AddRow(modifiedPropertyName.ToString(), property.GetValue(drinkDetail).ToString());
        }
        table.Columns[0].RightAligned();
        AnsiConsole.Write(table);

    }

}