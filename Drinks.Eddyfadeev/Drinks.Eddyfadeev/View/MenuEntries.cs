using Drinks.Eddyfadeev.Extensions;
using Drinks.Eddyfadeev.Interfaces.View;
using Spectre.Console;

namespace Drinks.Eddyfadeev.View;

/// <summary>
/// Represents a class for retrieving menu entries for a specific menu type.
/// </summary>
/// <typeparam name="TMenu">The type of the menu (enum).</typeparam>
internal class MenuEntries<TMenu> : IMenuEntries<TMenu>
    where TMenu : Enum
{
    /// <summary>
    /// Retrieves the menu entries for a specific menu type.
    /// </summary>
    /// <typeparam name="TMenu">The type of the menu (enum).</typeparam>
    /// <returns>A SelectionPrompt of strings representing the menu entries.</returns>
    public SelectionPrompt<string> GetMenuEntries() =>
        new SelectionPrompt<string>()
            .Title("Select an option:")
            .AddChoices(EnumExtensions.GetDisplayNames<TMenu>());
}