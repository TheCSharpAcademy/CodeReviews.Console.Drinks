using Drinks.Eddyfadeev.Models;
using Spectre.Console;

namespace Drinks.Eddyfadeev.Interfaces.View;

/// <summary>
/// Represents an interface for constructing tables to display information about drinks.
/// </summary>
internal interface ITableConstructor
{
    /// <summary>
    /// Creates a table to display information about a drink.
    /// </summary>
    /// <param name="drink">The drink object containing information about the drink.</param>
    /// <returns>A Table object representing the formatted drink information table.</returns>
    Table CreateDrinkTable(Drink drink);
}