using Drinks_Info.Models;
using Spectre.Console;

namespace Drinks_Info.Utilities
{
    public static class ConsoleHelper
    {
        public static void PrintMessage(string message)
        {
            Thread.Sleep(500);
            AnsiConsole.Write(new Markup($"\n[bold]{message}[/]"));
            Thread.Sleep(1000);
        }
    }
}