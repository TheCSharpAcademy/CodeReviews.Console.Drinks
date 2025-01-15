using Spectre.Console;

internal class MainMenu
{
    internal static void ShowMainMenu()
    {
        while (true)
        {
            var categories = ResponseHandlers.GetCategories();

            var category = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Select a drink category:")
                    .PageSize(10)
                    .AddChoices(categories)
                    .AddChoices("Exit the app"));

            if (category == "Exit the app")
            {
                Console.Clear();
                AnsiConsole.MarkupLine("[yellow]Goodbye![/]");
                Environment.Exit(0);
            }

            Console.Clear();
            var drinkId = ResponseHandlers.GetDrinkId(category);
            if (string.IsNullOrEmpty(drinkId)) continue;
            ResponseHandlers.ShowDrinkInfo(drinkId);
        }
    }
}
