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
            UserInput userInput = new();
            userInput.GetCategoriesInput();
        }
    }
}
