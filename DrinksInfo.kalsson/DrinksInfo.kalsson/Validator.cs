namespace DrinksInfo.kalsson;

public class Validator
{
    internal static bool IsStringValid(string stringInput)
    {
        if (string.IsNullOrEmpty(stringInput))
        {
            return false;
        }

        foreach (var c in stringInput)
        {
            if (!Char.IsLetter(c) && c != '/' && c != ' ')
            {
                return false;
            }
        }

        return true;
    }
}