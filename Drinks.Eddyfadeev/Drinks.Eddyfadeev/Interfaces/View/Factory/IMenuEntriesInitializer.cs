namespace Drinks.Interfaces.View.Factory;

/// <summary>
/// Represents an interface for initializing menu entries for a specific menu type.
/// </summary>
/// <typeparam name="TMenu">
/// The type of the menu entries, which must be an enum
/// </typeparam> 
internal interface IMenuEntriesInitializer<TMenu> 
    where TMenu : Enum
{
    /// <summary>
    /// Initializes the menu entries for a specified menu.
    /// </summary>
    /// <typeparam name="TMenu">The type of menu.</typeparam>
    /// <param name="menu">The menu to initialize the entries for.</param>
    /// <returns>A dictionary that maps menu entries to their corresponding commands.</returns>
    Dictionary<TMenu, Func<ICommand>> InitializeMenuEntries();
}