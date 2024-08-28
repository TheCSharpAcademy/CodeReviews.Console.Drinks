using System.ComponentModel.DataAnnotations;

namespace Drinks.Enums;

/// <summary>
/// Main menu entries for the user to choose from.
/// </summary>
internal enum MainMenuEntries
{
    [Display(Name = "Get a random drink")]
    GetRandom,
    [Display(Name = "Search for a drink")]
    SearchMenu,
    [Display(Name = "Filter drinks")]
    FiltersMenu,
    [Display(Name = "Exit")]
    Exit
}