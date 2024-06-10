namespace DrinksInfo.kalsson;

/// <summary>
/// The Validator class provides methods for validating user input.
/// </summary>
public class Validator
{
    /// <summary>
    /// Determines whether a given string is valid based on specific criteria.
    /// </summary>
    /// <param name="stringInput">The string to be validated.</param>
    /// <returns><c>true</c> if the string is valid; otherwise, <c>false</c>.</returns>
    internal static bool IsStringValid(string stringInput)
    {
        if (String.IsNullOrEmpty(stringInput))
        {
            return false;
        }

        foreach (char c in stringInput)
        {
            if (!Char.IsLetter(c) && c != '/' && c != ' ')
                return false;
        }

        return true;
    }

    /// <summary>
    /// Determines whether the given string represents a valid identifier.
    /// </summary>
    /// <param name="stringInput">The string to validate.</param>
    /// <returns>
    /// <see langword="true"/> if the string is a valid identifier; otherwise, <see langword="false"/>.
    /// </returns>
    public static bool IsIdValid(string stringInput)
    {
        if (String.IsNullOrEmpty(stringInput))
        {
            return false;
        }

        foreach (char c in stringInput)
        {
            if (!Char.IsDigit(c))
                return false;
        }

        return true;
    }
}