namespace Drinks.K_MYR.UI
{
    internal class Helpers
    {
        internal static void RenderTitle(string title)
        {
            AnsiConsole.Write(new Rule($"[darkorange]{title}[/]"));
        }
    }
}
