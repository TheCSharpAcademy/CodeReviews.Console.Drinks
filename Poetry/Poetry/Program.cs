using Spectre.Console;
using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        while (true)
        {
            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("\nMenu:")
                    .AddChoices(new[]
                    {
                        "1. Choose a Poet",
                        "2. Choose a Poem Title",
                        "3. Get Poem by Excerpt",
                        "4. Get a Random Poem",
                        "5. List Authors",
                        "Exit"
                    }));

            switch (choice)
            {
                case "1. Choose a Poet":
                    var authorInput = AnsiConsole.Ask<string>("\nEnter the poet's name:");
                    await PoetryRequest.GetAuthor(authorInput);
                    break;

                case "2. Choose a Poem Title":
                    var titleInput = AnsiConsole.Ask<string>("\nEnter the poem title:");
                    await PoetryRequest.GetTitle(titleInput);
                    break;

                case "3. Get Poem by Excerpt":
                    var excerptInput = AnsiConsole.Ask<string>("\nEnter the poem excerpt:");
                    await PoetryRequest.GetPoemByExcerpt(excerptInput);
                    break;

                case "4. Get a Random Poem":
                    await PoetryRequest.GetRandomPoem();
                    break;

                case "5. List Authors":
                    await PoetryRequest.ListAuthors();
                    break;

                case "Exit":
                    AnsiConsole.MarkupLine("[green]Exiting...[/]");
                    return;

                default:
                    AnsiConsole.MarkupLine("[red]Invalid choice.[/]");
                    break;
            }
        }
    }
}
