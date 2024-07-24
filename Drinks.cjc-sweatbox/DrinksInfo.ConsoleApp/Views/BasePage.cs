using System.Text;
using Spectre.Console;

namespace DrinksInfo.ConsoleApp.Views;

internal abstract class BasePage
{
    #region Constants

    protected static readonly string ApplicationTitle = "Drinks Info";

    protected static readonly string PromptTitle = "Select an [blue]option[/]...";

    private static readonly string DividerLine = "[cyan2]----------------------------------------[/]";

    #endregion
    #region Methods - Protected

    protected static void WriteFooter()
    {
        AnsiConsole.Write(new Rule().RuleStyle("grey").LeftJustified());
        AnsiConsole.Markup($"{Environment.NewLine}Press any [blue]key[/] to continue...");
        Console.ReadKey();
    }

    protected static void WriteHeader(string title)
    {
        AnsiConsole.Clear();
        AnsiConsole.Markup(GetHeaderText(title));
    }

    #endregion
    #region Methods - Private

    private static string GetHeaderText(string pageTitle)
    {
        var sb = new StringBuilder();
        sb.AppendLine(DividerLine);
        sb.AppendLine($"[bold cyan2]{ApplicationTitle}[/]: [honeydew2]{pageTitle}[/]");
        sb.AppendLine(DividerLine);
        sb.AppendLine();
        return sb.ToString();
    }

    #endregion
}
