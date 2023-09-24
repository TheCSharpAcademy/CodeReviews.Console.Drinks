namespace MiroiuDev.DrinksInfo;
internal class Validator
{
    internal static bool IsIdValid(string? id)
    {
        if (string.IsNullOrEmpty(id)) return false;

        foreach (char c in id)
        {
            if (!char.IsDigit(c)) return false;
        }

        return true;
    }

    internal static bool IsStringValid(string? input)
    {
        if (string.IsNullOrEmpty(input)) return false;

        foreach (char c in input)
        {
            if (!char.IsLetter(c) && c != '/' && c != ' ') return false;
        }

        return true;
    }
}
