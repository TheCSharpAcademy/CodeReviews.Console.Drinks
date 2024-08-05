using Spectre.Console;

namespace DrinksInfo.Arashi256.Classes
{
    internal class CommonUI
    {
        public static int MenuOption(string question, int min, int max)
        {
            int selectedValue = 0;
            var userInput = AnsiConsole.Ask<int>(question);
            selectedValue = userInput;
            if (selectedValue < min || selectedValue > max)
            {
                AnsiConsole.MarkupLine("[red]Invalid input. Please enter a value within the specified range.[/]");
            }
            return selectedValue;
        }

        public static void Pause(string colour)
        {
            AnsiConsole.Markup($"[{colour}]Press any key to continue...[/]");
            Console.ReadKey(true);
        }
    }
}
