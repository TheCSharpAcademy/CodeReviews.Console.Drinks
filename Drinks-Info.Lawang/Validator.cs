namespace Drinks_Info.Lawang;

public class Validator
{
    internal static bool IsStringValid(string stringInput)
    {
        if(String.IsNullOrEmpty(stringInput))
        {
            return false;
        }

        foreach(char c in stringInput)
        {
            if(!Char.IsLetter(c) && c != '/' && c != ' ')
            {
                return false;
            }
        }
        return true;
    }

    internal static bool IsIdValid(string? Id)
    {
        if(!string.IsNullOrEmpty(Id))
        {
            foreach(char c in Id)
            {
                if(!Char.IsDigit(c))
                {
                    return false;
                }
            }

            return true;
        }

        return false;
    }
}
