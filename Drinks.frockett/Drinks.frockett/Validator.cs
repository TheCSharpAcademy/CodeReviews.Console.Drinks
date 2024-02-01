namespace Drinks.frockett;

public class Validator
{
    public bool IsStringValid(string input)
    {
        if (string.IsNullOrEmpty(input)) return false;

        foreach (char c in input)
        {
            if (!Char.IsLetter(c) && c != '/' && c != ' ') return false;
        }

        return true;
    }

    public bool IsIdValid(string drinkSelection)
    {
        if (string.IsNullOrEmpty(drinkSelection)) return false;

        foreach (char c in drinkSelection)
        {
            if (!Char.IsDigit(c)) return false;
        }
        return true;
    }
}
