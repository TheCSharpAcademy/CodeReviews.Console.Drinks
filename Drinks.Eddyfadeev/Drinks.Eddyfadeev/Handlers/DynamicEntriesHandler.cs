using Drinks.Eddyfadeev.View;
using Spectre.Console;

namespace Drinks.Eddyfadeev.Handlers;

/// <summary>
/// Class containing a method to handle dynamic entries retrieved from the API call.
/// </summary>
internal static class DynamicEntriesHandler 
{
    /// <summary>
    /// Handles dynamic entries by displaying them as a menu and prompting the user to select an entry.
    /// </summary>
    /// <param name="dynamicEntries">An array of dynamic entries to be displayed in the menu.</param>
    /// <returns>The user's selected entry from the menu.</returns>
    public static string HandleDynamicEntries(string[] dynamicEntries)
    {
        var menuEntries = new SelectionPrompt<string>();
        menuEntries.AddChoices(dynamicEntries);
        menuEntries.AddChoice(Messages.BackOption);
        
        return AnsiConsole.Prompt(menuEntries);
    }
}