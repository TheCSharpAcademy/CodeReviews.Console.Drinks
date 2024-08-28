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
            table.AddColumn("ID");
            table.AddColumn("Categories");

            for (int i = 0; i < categories.Count; i++)
            {
                table.AddRow($"{i + 1}", categories[i].strCategory);
            }

            AnsiConsole.Write(table);
            Console.WriteLine("\nPlease enter a drink category to get started, or enter 0 to quit:");

            var selection = GetInputLoop(categories.Count);

            if (selection == 0)
            {
                return;
            }

            Console.ReadKey();
        }
    }
}