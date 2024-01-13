using DrinksInfo.StevieTV.UI;
using Spectre.Console;

namespace DrinksInfo.StevieTV;

internal static class DrinksMenu
{
    static void Main()
    {
        while (true)
        {
            AnsiConsole.Clear();
            AnsiConsole.Write(new FigletText("Drinks Menu"));
            UserInput userInput = new();
            userInput.GetCategoriesInput();
        }
    }
}
