namespace Drinks.Eddyfadeev.Interfaces.Handlers;

/// <summary>
/// Represents an interface for handling menu entries.
/// </summary>
/// <typeparam name="TMenu">The type of menu entries.</typeparam>
internal interface IMenuEntriesHandler<TMenu>
    where TMenu : Enum
{
    /// <summary>
    /// Handles the menu entries for a specific menu type.
    /// </summary>
    /// <typeparam name="TMenu">The menu type.</typeparam>
    void HandleMenu();
}