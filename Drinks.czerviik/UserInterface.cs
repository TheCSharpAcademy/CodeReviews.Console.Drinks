using System.Reflection;
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
        var favorite = drinkDetail.IsFavorite ? "Remove from favorites" : "Add to favorites";
        string[] options = ["Go back", "Return to Main menu", favorite];

        Header("drink details");

        DisplayTable(drinkDetail);

        ChooseOptions(options);
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

        if (drinkDetail.IsFavorite)
        {
            Console.Write($"DRINK: {properties[0].Name} ");
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("*FAVORITE*");
            Console.ResetColor();
        }
        else
            Console.WriteLine($"DRINK: {properties[0].Name}");

        var table = new Table()
        .AddColumns(drinkDetail.Name.ToUpper(), "")
        .Border(TableBorder.Rounded);

        foreach (var property in properties)
        {
            var modifiedPropertyName = Operations.ModifyPropertyName(property).ToString();

            if (property.GetValue(drinkDetail) != null && modifiedPropertyName != "Name")
                table.AddRow(modifiedPropertyName, property.GetValue(drinkDetail).ToString());
        }
        table.Columns[0].RightAligned();
        AnsiConsole.Write(table);
    }

    public static void DisplayMessage(string message = "", string actionMessage = "continue", bool consoleClear = false)
    {
        if (consoleClear) Console.Clear();

        if (message == "")
            Console.WriteLine($"\nPress any key to {actionMessage}...");
        else
            Console.WriteLine($"\n{message} Press any key to {actionMessage}...");

        Console.ReadKey();
    }
}