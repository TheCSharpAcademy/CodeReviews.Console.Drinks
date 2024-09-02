using System.ComponentModel.DataAnnotations;

namespace Drinks.Eddyfadeev.Enums;

/// <summary>
/// Search menu entries for the user to choose from.
/// </summary>
internal enum SearchMenuEntries
{
    [Display(Name = "Search by name")]
    SearchByName,
    [Display(Name = "Search by ingredient")]
    SearchByIngredient,
    [Display(Name = "Back")]
    Back
}