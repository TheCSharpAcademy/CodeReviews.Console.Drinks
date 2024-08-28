using System.ComponentModel.DataAnnotations;

namespace Drinks.Eddyfadeev.Enums;

/// <summary>
/// Filter menu entries for the user to choose from.
/// </summary>
internal enum FilterMenuEntries
{
    [Display(Name = "Filter by category")]
    FilterByCategory,
    [Display(Name = "Filter by alcoholic")]
    FilterByAlcoNonAlco,
    [Display(Name = "Filter by glass type")]
    FilterByGlass,
    [Display(Name = "Filter by ingredient")]
    FilterByIngredient,
    [Display(Name = "Back")]
    Back
}