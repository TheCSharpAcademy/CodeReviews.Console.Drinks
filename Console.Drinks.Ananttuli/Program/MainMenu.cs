using Spectre.Console;

namespace Program;

public class MainMenu
{
    public const string OpenMenu = "Open Menu";
    public const string Exit = "[red]Exit[/]";

    public static string Prompt()
    {
        return AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("\nDRINKS MENU")
                .AddChoices([OpenMenu, Exit])
        );

    }
}