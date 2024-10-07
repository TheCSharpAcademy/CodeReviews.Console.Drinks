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
                        "2. Search a Poem by Title",
                        "3. Search Poem by Excerpt",
                        "4. Get a Random Poem",
                        "5. Search Authors' name",
                        "Exit"
                    }));

            switch (choice)
            {
                case "1. Choose a Poet":
                    await PoetryRequest.ListAuthors();
                    break;

                case "2. Search a Poem by Title":
                    var titleInput = AnsiConsole.Ask<string>("[red]\n\nEnter the poem title: [/]");
                    await PoetryRequest.GetTitle(titleInput);
                    break;

                case "3. Search Poem by Excerpt":
                    var excerptInput = AnsiConsole.Ask<string>("[red]\n\nEnter the poem excerpt: [/]");
                    await PoetryRequest.GetPoemByExcerpt(excerptInput);
                    break;

                case "4. Get a Random Poem":
                    await PoetryRequest.GetRandomPoem();
                    break;

                case "5. Search Authors' name":
                    var authorInput = AnsiConsole.Ask<string>("[red]\n\nEnter the poet's name: [/]");
                    await PoetryRequest.GetAuthor(authorInput);                    break;

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
