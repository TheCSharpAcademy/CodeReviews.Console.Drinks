public class PoemTitle
{
    public string Title { get; set; }
}

public class Author
{
    public List<string> Authors { get; set; }

}

public class Poem
{
    public string Title { get; set; }
    public string Author { get; set; }
    public List<string> Lines { get; set; }
    public string LineCount { get; set; }
}

public class PoemExcerpts
{
    public Poem Poem { get; set; }
    public List<string> MatchingLines { get; set; }
}