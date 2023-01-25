namespace DrinksInfo;

internal class Validator
{
    internal static bool IsIdValid(string? drinkId)
    {
        if (String.IsNullOrEmpty(drinkId))
        {
            return false;
        }

        foreach (char c in drinkId)
        {
            if (!Char.IsDigit(c))
            {
                return false;
            }
        }
        return true;
    }

    internal static bool IsStringValid(string? category)
    {
        if (String.IsNullOrEmpty(category))
        {
            return false;
        }

        foreach (char c in category)
        {
            if (!Char.IsLetter(c) && c != '/' && c != ' ')
            {
                return false;
            }
        }
        return true;
    }

    internal static bool IsValidOption(string? option)
    {
        return option == "0" || option == "1";
    }
}
