namespace DrinksInfo;
internal class Validator {
    public static bool IsStringValid(string stringInput)
    {
        return !string.IsNullOrEmpty(stringInput) && stringInput.All(c => char.IsLetter(c) && c != '/' && c != ' ');
    }

    public static bool IsIdValid(string stringInput)
    {
        return !string.IsNullOrEmpty(stringInput) && stringInput.All(char.IsDigit);
    }
}
