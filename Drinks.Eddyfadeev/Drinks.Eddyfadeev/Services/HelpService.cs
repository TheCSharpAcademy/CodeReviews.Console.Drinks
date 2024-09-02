using Drinks.Eddyfadeev.View;
using Spectre.Console;

namespace Drinks.Eddyfadeev.Services;

public static class HelpService
{
    public static void WaitForEnter()
    {
        AnsiConsole.MarkupLine(Messages.PressEnterToContinue);
        do
        {
            var keyPress = Console.ReadKey(true);
            if (keyPress.Key == ConsoleKey.Enter)
            {
                break;
            }
        } while (true);
    }
}