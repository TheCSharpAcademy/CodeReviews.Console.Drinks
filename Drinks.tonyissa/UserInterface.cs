using Drinks.tonyissa.WebHelper;
using Spectre.Console;

namespace Drinks.tonyissa.UI;

internal static class UserInterface
{
    public static async Task PrintMainMenu()
    {
        Console.Clear();
        Console.WriteLine("Welcome to my drinks helper!");
        Console.WriteLine("Please enter a drink category to get started\n");
        var categories = await WebController.GetCategories();

        var table = new Table() { Title = new TableTitle("Categories Menu") };

        table.AddColumn("ID");
        table.AddColumn("Categories");

        for (int i = 0; i < categories.Count; i++) {
            table.AddRow($"{i + 1}", categories[i].strCategory);
        }

        AnsiConsole.Write(table);
        Console.ReadKey();
    }
}