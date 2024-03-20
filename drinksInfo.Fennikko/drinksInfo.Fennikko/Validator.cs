namespace drinksInfo.Fennikko;

public class Validator
{
    public static bool IsStringValid(string stringInput)
    {
        return !string.IsNullOrWhiteSpace(stringInput) && stringInput.All(c => char.IsLetter(c) || c == '/' || c == ' ');
    }

    public static bool IsIdValid(string stringInput)
    {
        return !string.IsNullOrWhiteSpace(stringInput) && stringInput.All(char.IsDigit);
    }
}