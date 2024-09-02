using System.ComponentModel.DataAnnotations;

namespace Drinks.Eddyfadeev.Extensions;

internal static class EnumExtensions
{
    /// <summary>
    /// Gets the display names of all the values in an enum.
    /// </summary>
    /// <typeparam name="TEntry">The type of the enum.</typeparam>
    /// <returns>An IEnumerable of strings representing the display names of all the values in the enum.</returns>
    public static IEnumerable<string> GetDisplayNames<TEntry>() where TEntry : Enum =>
        Enum
            .GetValues(typeof(TEntry))
            .Cast<TEntry>()
            .Select(e => e.GetDisplayName());

    /// <summary>
    /// Retrieves the enum value from its display name.
    /// </summary>
    /// <typeparam name="TEntry">The enum type.</typeparam>
    /// <param name="displayName">The display name of the enum value.</param>
    /// <returns>The enum value corresponding to the given display name.</returns>
    /// <exception cref="InvalidOperationException">Thrown if no enum value with the given display name is found.</exception>
    public static TEntry GetValueFromDisplayName<TEntry>(this string displayName) where TEntry : Enum =>
        Enum
            .GetValues(typeof(TEntry))
            .Cast<TEntry>()
            .First(e => e.GetDisplayName() == displayName);
    
    private static string GetDisplayName<TEntry>(this TEntry enumValue) where TEntry : Enum
    {
        var displayName = enumValue
            .GetType()
            .GetMember(enumValue.ToString())
            .FirstOrDefault()?
            .GetCustomAttribute<DisplayAttribute>()?
            .GetName();
        
        return displayName ?? enumValue.ToString();
    }
}