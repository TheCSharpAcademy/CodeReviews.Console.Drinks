public class Validator
{
    internal static bool IsStringValid(string stringInput)
    {
        if (string.IsNullOrEmpty(stringInput))
        {
            return false;
        }

        foreach (char c in stringInput)
        {
            if (!char.IsLetter(c) && c != '/' && c != ' ')
                return false;
        }

        return true;
    }

    public static bool IsIdValid(string stringInput)
    {

        if (string.IsNullOrEmpty(stringInput))
        {
            return false;
        }

        foreach (char c in stringInput)
        {
            if (!char.IsDigit(c))
                return false;
        }

        return true;
    }
}
