using Drinks.Models;

namespace Drinks.Extensions;

/// <summary>
/// Provides extension methods for the Drinks class.
/// </summary>
internal static class DrinksExtensions
{
    /// <summary>
    /// Retrieves an array of property values from a collection of drinks.
    /// </summary>
    /// <param name="drinks">The collection of drinks.</param>
    /// <param name="selector">The function used to select the property value.</param>
    /// <returns>An array of property values.</returns>
    public static string[] GetPropertyArray(this Models.Drinks drinks, Func<Drink, string> selector)
    {
        return drinks?.DrinksList == null ? 
            Array.Empty<string>() : 
            drinks.DrinksList.Select(selector).ToArray();
    }
}