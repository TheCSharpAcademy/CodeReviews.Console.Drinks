using Spectre.Console;

namespace DrinksInfo;
public class Validation
{
    public static ValidationResult IsStringValid(string input)
    {
        foreach (var c in input)
        {
            if (!Char.IsLetter(c) && c != '/' && c != ' ')
            {
                return ValidationResult.Error();
            }
        }
        return ValidationResult.Success();
    }

    public static ValidationResult IsIdValid(string input)
    {
        foreach (var c in input)
        {
            if (!Char.IsDigit(c))
            {
                return ValidationResult.Error();
            }
        }
        return ValidationResult.Success();
    }
}
