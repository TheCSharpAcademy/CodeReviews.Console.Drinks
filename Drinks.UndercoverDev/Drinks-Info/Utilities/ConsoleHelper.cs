using Spectre.Console;

namespace Drinks_Info.Utilities
{
    public static class ConsoleHelper
    {
        static void PrintMessage(string message)
        {
            Thread.Sleep(500);
            AnsiConsole.Write(new Markup($"\n{message}"));
            Thread.Sleep(1000);
        }

        public static void PrintError(string message)
        {
            AnsiConsole.Write(new Markup($"\n{message}"));
        }

        public static void PrintSuccess(string message)
        {
            AnsiConsole.Write(new Markup($"\n{message}"));
        }

        public static void PrintTable(Table table)
        {
            AnsiConsole.Write(table);
        }
    }
}