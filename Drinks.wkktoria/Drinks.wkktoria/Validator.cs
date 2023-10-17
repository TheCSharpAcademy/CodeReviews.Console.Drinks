namespace Drinks.wkktoria;

internal static class Validator
{
    internal static bool IsStringValid(string? stringInput)
    {
        return !string.IsNullOrEmpty(stringInput) && stringInput.All(c => char.IsLetter(c) || c == '/' || c == ' ');
    }

    internal static bool IsIdValid(string? stringInput)
    {
        return !string.IsNullOrEmpty(stringInput) && stringInput.All(char.IsDigit);
    }
}