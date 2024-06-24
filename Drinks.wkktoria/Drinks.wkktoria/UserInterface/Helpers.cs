using Spectre.Console;

namespace Drinks.wkktoria.UserInterface;

internal static class Helpers
{
    internal static T SelectionPrompt<T>(List<T> choices, string? title = null) where T : class
    {
        if (title == null)
            return AnsiConsole.Prompt(
                new SelectionPrompt<T>()
                    .AddChoices(choices));

        return AnsiConsole.Prompt(
            new SelectionPrompt<T>()
                .Title(title)
                .AddChoices(choices));
    }

    internal static void PressAnyKeyToContinue()
    {
        Console.WriteLine("Press any key to return to menu...");
        Console.ReadKey();
    }
}