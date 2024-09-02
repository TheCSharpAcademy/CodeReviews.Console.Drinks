using Spectre.Console;

namespace Drinks.Eddyfadeev.Interfaces.View;

/// <summary>
/// Represents an interface for retrieving menu entries.
/// </summary>
/// <typeparam name="TMenu">The type of the menu.</typeparam>
internal interface IMenuEntries<TMenu> 
    where TMenu : Enum
{
    /// <summary>
    /// Retrieves the menu entries as a selection prompt.
    /// </summary>
    /// <typeparam name="TMenu">The type of the menu entries.</typeparam>
    /// <returns>A <see cref="SelectionPrompt{T}"/> of the string type representing the menu entries.</returns>
    SelectionPrompt<string> GetMenuEntries();
}