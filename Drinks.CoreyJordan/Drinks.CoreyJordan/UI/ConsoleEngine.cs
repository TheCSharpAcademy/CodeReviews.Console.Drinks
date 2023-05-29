using ConsoleTableExt;

namespace Drinks.CoreyJordan.UI;

/// <summary>
/// Responsible for displaying data to the user console.
/// </summary>
internal class ConsoleEngine
{
    internal void DisplayTable<T>(List<T> list, string[] headers) where T : class
    {
        if (headers.Length == 0)
        {
            headers = new string[1];
        }

        Console.WriteLine();
        ConsoleTableBuilder
            .From(list)
            .WithColumn(headers)
            .WithFormat(ConsoleTableBuilderFormat.Alternative)
            .ExportAndWriteLine(TableAligntment.Left);
        Console.WriteLine();
    }

    internal void PromptInvalid()
    {
        int prompts = 4;
        Console.WriteLine("\nInvalid selection. Try again.");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();

        Console.SetCursorPosition(0, Console.GetCursorPosition().Top - prompts);
        for (int i = 0; i < prompts; i++)
        {
            Console.WriteLine(new string(' ', Console.WindowWidth));
        }
        Console.Write(new string(' ', Console.WindowWidth));
        Console.SetCursorPosition(0, Console.GetCursorPosition().Top - prompts);
    }
}
