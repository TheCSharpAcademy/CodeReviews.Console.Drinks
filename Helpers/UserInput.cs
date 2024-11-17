using Spectre.Console;

namespace Drinks.TwilightSaw.Helpers
{
    internal static class UserInput
    {
        public static string CreateChoosingList(List<string> variants)
        {
            var select = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[blue]Please, choose an option from the list below:[/]")
                    .PageSize(10)
                    .MoreChoicesText("[grey](Move up and down to reveal more categories[/]")
                    .AddChoices("Exit")
                    .AddChoices(variants));
            return select;
        }
    }
}
