using Spectre.Console;

internal class Display
{
    internal static void PressAnyKeyToContinue()
    {
        AnsiConsole.Status()
            .Start("[yellow]Press any key to continue...[/]", ctx =>
            {
                ctx.Spinner(Spinner.Known.Ascii);
                ctx.SpinnerStyle(Style.Parse("yellow"));
                Console.ReadKey(true);
            });
        Console.Clear();
    }

    internal static void ExceptionInfo(Exception ex)
    {
        AnsiConsole.MarkupLine("[red]An error occurred.[/]");
        AnsiConsole.MarkupLine($"Details: [yellow]{ex.Message}[/]");
        PressAnyKeyToContinue();
    }
}
