using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Linq;
using Spectre.Console;

class PoetryRequest
{
    private static readonly HttpClient client = new HttpClient();
    private static readonly string baseURL = "https://poetrydb.org";

    public static async Task GetAuthor(string name)
    {

        string url = BuildUrlAuthor(name);

        try
        {
            var response = await client.GetAsync(url);
            string responseString = await response.Content.ReadAsStringAsync();
            List<PoemTitle> titles = JsonConvert.DeserializeObject<List<PoemTitle>>(responseString);

            //Choosing Poem
            var Authorchoice = AnsiConsole.Prompt(
                new SelectionPrompt<PoemTitle>()
                    .Title("\n[green]Choose a Poem Title: [/]")
                    .AddChoices(titles)
                    .UseConverter(poem => EscapeMarkup(poem.Title))
            );

            string title = Authorchoice.Title;

            //Displaying Poem
            string url2 = BuildUrlAuthor(name, title);
            var response2 = await client.GetAsync(url2);
            string responseString2 = await response2.Content.ReadAsStringAsync();
            Poem poem = JsonConvert.DeserializeObject<List<Poem>>(responseString2)[0]; // Deserialize as a list and get the first element

            ReadPoem(poem);
        }
        catch
        {
            Console.WriteLine("No such Poet.");
        }
    }

    public static async Task GetTitle(string name)
    {
        string url = BuildUrlTitle(name);
        try
        {
            var response = await client.GetAsync(url);
            string responseString = await response.Content.ReadAsStringAsync();
            List<Poem> poems = JsonConvert.DeserializeObject<List<Poem>>(responseString);

            if (poems == null || poems.Count == 0)
            {
                AnsiConsole.MarkupLine("[red]No poems found.[/]");
            }

            var titleChoice = AnsiConsole.Prompt(
                new SelectionPrompt<Poem>()
                    .Title("\n[green]Choose a Poem Title:[/]")
                    .PageSize(10)
                    .AddChoices(poems)
                    .UseConverter(p => EscapeMarkup($"{p.Author} - {p.Title} ({p.LineCount} lines.)"))
            );

            //Displaying selected Poem
            ReadPoem(titleChoice);
        }
        catch
        {
            Console.WriteLine("No such Title.");
        }
        
    }

    public static async Task GetRandomPoem()
    {
        string url = $"{baseURL}/random";
        var response = await client.GetAsync(url);
        string responseString = await response.Content.ReadAsStringAsync();
        Poem poem = JsonConvert.DeserializeObject<List<Poem>>(responseString)[0];

        ReadPoem(poem);
    }

    public static async Task GetPoemByExcerpt(string excerpt) //Table + prompt might be too much
    {
        string url = $"{baseURL}/lines/{excerpt}";
        try
        {
            var response = await client.GetAsync(url);
            string responseString = await response.Content.ReadAsStringAsync();
            List<Poem> poem = JsonConvert.DeserializeObject<List<Poem>>(responseString);
            int poemCount = 0;

            var selectedPoems = poem
               .Select(p => new PoemExcerpts
               {
                   Poem = p,
                   MatchingLines = p.Lines.Where(line => line.Contains(excerpt, StringComparison.OrdinalIgnoreCase)).ToList()
               })
               .Where(pm => pm.MatchingLines.Any())
               .ToList();

            var table = new Table()
                .AddColumn("Poem")
                .AddColumn("Matching Lines");

            foreach (var pm in selectedPoems)
            {
                table.AddRow(
                    EscapeMarkup($"{pm.Poem.Author} - {pm.Poem.Title} ({pm.Poem.LineCount} lines)"),
                    string.Join(Environment.NewLine, pm.MatchingLines.Select(line => $"- {EscapeMarkup(line)}"))
                );
            }
            AnsiConsole.Write(table);
        }
        catch
        {
            Console.WriteLine("No such excerpt.");
        }
    }

    public static async Task ListAuthors()
    {
        var allAuthors = new Table();
        allAuthors.AddColumn("Author");

        string url = $"{baseURL}/author";
        try
        {
            var response = await client.GetAsync(url);
            string responseString = await response.Content.ReadAsStringAsync();
            Author authors = JsonConvert.DeserializeObject<Author>(responseString);

            Console.WriteLine("Listing Authors...\n");
            foreach (var a in authors.Authors)
            {
                allAuthors.AddRow(a);
            }
            AnsiConsole.Render(allAuthors);
        }
        catch
        {
            Console.WriteLine("No such Author.");
        }
    }
    private static string BuildUrlAuthor(string author, string title = "")
    {
        // setting up url format for api
        if (title == "")
            return $"{baseURL}/author/{author}/title";
        else
            return $"{baseURL}/author,title/{author};{title}";
    }

    private static string BuildUrlTitle(string title)
    {
        return $"{baseURL}/title/{title}";
    }

    private static void ReadPoem(Poem p)
    {
        Console.WriteLine($"\n{p.Author} - {p.Title} ({p.LineCount} Lines)\n");
        int linecounter = 0;
        foreach (var line in p.Lines)
        {
            Console.WriteLine(line);
            linecounter++;

            if (linecounter >= 19)
            {
                Console.WriteLine("\nPress any key to continue reading...");
                Console.ReadKey();
                Console.Clear();
                linecounter = 0;
            }
        }
    }
    static string EscapeMarkup(string text) //fixes rare annoying bug when fetching data 
    {
        return text.Replace("[", "[[").Replace("]", "]]");
    }
}

//add exiting functionality from prompt