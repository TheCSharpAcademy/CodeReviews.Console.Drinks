namespace Drinks.Forser.UI
{
    public class Helpers
    {
        internal static Style HighLightStyle => new(
            Color.LightGreen,
            Color.Black,
            Decoration.None
            );

        internal static void RenderTitle(string title)
        {
            AnsiConsole.Write(new Rule($"[green]{title}[/]"));
        }

        public static void ShowMessage(string message)
        {
            AnsiConsole.WriteLine(message);
        }
    }
}
