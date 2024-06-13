using Spectre.Console;

namespace DrinksInfo.HopelessCoding;

internal class GeneralHelpers
{
    public static string MenuSelector(string[] menuItems)
    {
        var selection = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("[aqua]Select a category[/]")
                .MoreChoicesText("[grey]More[/]")
                .HighlightStyle("aquamarine3")
                .AddChoices(menuItems));

        return selection;
    }
}
