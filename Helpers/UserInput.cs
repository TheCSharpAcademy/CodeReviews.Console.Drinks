using Spectre.Console;
using System;

using System.Text.RegularExpressions;


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
                    .AddChoices("Return")
                    .AddChoices(variants));
            return select;
        }
        public static string CreateRegex(string regexString, string messageStart, string messageError)
        {
            Regex regex = new Regex(regexString);
            var input = AnsiConsole.Prompt(
                new TextPrompt<string>($"[green]{messageStart}[/]")
                    .Validate(value => regex.IsMatch(value)
                        ? ValidationResult.Success()
                        : ValidationResult.Error(messageError)));

            return input;
        }
        public static string Create(string messageStart)
        {
            var input = AnsiConsole.Prompt(
                new TextPrompt<string>($"[green]{messageStart} or 0 to exit: [/]"));
            Console.Clear();
            return input;
        }
    }
}
