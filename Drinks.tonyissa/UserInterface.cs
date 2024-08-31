using Drinks.tonyissa.Models;
using Drinks.tonyissa.WebHelper;
using Spectre.Console;

namespace Drinks.tonyissa.UI;

internal static class UserInterface
{
    private static int GetInputLoop(int count)
    {
        while (true)
        {
            var input = Console.ReadLine() ?? "";

            if (ValidateInput(input, count))
            {
                return int.Parse(input);
            }

            Console.WriteLine("Invalid input, please try again");
        }
    }

    private static bool ValidateInput(string input, int count)
    {
        if (!int.TryParse(input, out var selection))
        {
            return false;
        }
        if (selection > count || selection < 0)
        {
            return false;
        }

        return true;
    }

    public static async Task PrintMainMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Welcome to my drinks helper!\n");
            var categories = await WebController.GetCategories();

            var table = new Table() { Title = new TableTitle("Categories Menu") };
            table.AddColumns("ID", "Categories");

            for (int i = 0; i < categories.Count; i++)
            {
                table.AddRow($"{i + 1}", categories[i].strCategory);
            }

            AnsiConsole.Write(table);
            Console.WriteLine("\nPlease enter a drink category to get started, or enter 0 to quit:");
            var selection = GetInputLoop(categories.Count);

            if (selection == 0) return;

            await PrintCategory(categories[selection - 1].strCategory);
        }
    }

    public static async Task PrintCategory(string drinkName)
    {
        Console.Clear();
        var category = await WebController.GetSingularCategory(drinkName);

        var table = new Table() { Title = new TableTitle("Category drinks") };
        table.AddColumns("ID", "Drinks");

        for (int i = 0; i < category.Count; i++)
        {
            table.AddRow($"{i + 1}", category[i].strDrink);
        }

        AnsiConsole.Write(table);
        Console.WriteLine("\nPlease select a drink, or enter 0 to go back:");
        var selection = GetInputLoop(category.Count);

        if (selection == 0) return;

        await PrintDrinkInformation(category[selection - 1].idDrink);
    }

    public static async Task PrintDrinkInformation(string id)
    {
        Console.Clear();
        var drinkObject = await WebController.GetDrinkFromId(id);

        var ingredientsTable = new Table() 
        { 
            Title = new TableTitle(drinkObject.strInstructions ?? ""), 
            Caption = new TableTitle($"Serve in: {drinkObject.strGlass ?? "unknown"}") 
        };
        ingredientsTable.AddColumns("Ingredients");

        foreach (var item in drinkObject.strIngredients)
        {
            ingredientsTable.AddRow(item.Measure + item.Ingredient);
        }

        var informationTable = new Table();
        informationTable.AddColumns("Tags", "IBA", "Type");
        informationTable.AddRow(drinkObject.strTags ?? "None", drinkObject.strIBA ?? "unknown", drinkObject.strAlcoholic ?? "Not listed");

        var table = new Table() 
        { 
            Title = new TableTitle(drinkObject.strDrink), 
            Caption = new TableTitle(drinkObject.strCategory) 
        };
        table.AddColumns("How to make", "Information");
        table.AddRow(ingredientsTable, informationTable);

        AnsiConsole.Write(table);
        Console.WriteLine("\nPress any key to go back...");
        Console.ReadKey();
    }
}