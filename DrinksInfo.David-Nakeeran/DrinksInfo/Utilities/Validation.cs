using Spectre.Console;

namespace DrinksInfo.Utilities;

class Validation
{
    internal string CheckInputNullOrWhitespace(string message, string input)
    {
        while (string.IsNullOrWhiteSpace(input))
        {
            input = AnsiConsole.Ask<string>(message);
        }
        return input;
    }

    internal bool IsCharValid(string input)
    {
        foreach (char c in input)
        {
            if (!Char.IsLetter(c) && c != '/' && c != ' ' && c != '0') return false;
        }
        return true;
    }

    internal bool IsIdValid(string? input)
    {
        if (int.TryParse(input, out _)) return true;
        return false;
    }

    internal string? ValidateDrinkId(string message, string input)
    {
        input = CheckInputNullOrWhitespace(message, input);
        while (!IsIdValid(input))
        {
            AnsiConsole.WriteLine("Invalid drink id, please press any key to continue.....");
            Console.ReadKey(true);
            input = AnsiConsole.Ask<string>(message);
            input = CheckInputNullOrWhitespace(message, input);
        }
        return input;
    }

    internal string? ValidateString(string message, string input)
    {
        input = CheckInputNullOrWhitespace(message, input);
        while (!IsCharValid(input))
        {
            AnsiConsole.WriteLine("Invalid category, please press any key to continue.....");
            Console.ReadKey(true);
            input = AnsiConsole.Ask<string>(message);
            input = CheckInputNullOrWhitespace(message, input);
        }
        return input;
    }
}