using System.Runtime.CompilerServices;
using Spectre.Console;

namespace DrinksInfo;

public class UserInput
{
    public int GetMenuChoice(int start, int end, string text)
    {
        int menuChoice = AnsiConsole.Prompt(
        new TextPrompt<int>(text)
        .Validate((n) =>
        {
            if (start <= n && n <= end)
                return ValidationResult.Success();
            else
                return ValidationResult.Error($"[red]Pick a valid option[/]");
        }));
        return menuChoice;
    }

    public void WaitToContinue()
    {
        Console.WriteLine($"Press enter to continue...");
        Console.Read();
    }

    // public void PressToExit()
    // {
    //     // Console.WriteLine("\nPress 0 to exit.");
    //     ConsoleKeyInfo button = Console.ReadKey(true);
    //     if (button.Key == ConsoleKey.NumPad0 || button.Key == ConsoleKey.D0)
    //     {
    //         Environment.Exit(0);
    //     }
    // }

    // public void ReturnToMainMenu()
    // {
    //     ConsoleKeyInfo button = Console.ReadKey(true);
    //     if (button.Key == ConsoleKey.NumPad0 || button.Key == ConsoleKey.D0)
    //     {

    //     }
    // }
}

