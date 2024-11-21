public class Validator {
    
    internal static bool IsStringValid(string stringInput) {
        if (String.IsNullOrEmpty(stringInput)) {
            return false;
        }

        foreach (char c in stringInput) {
            if (!Char.IsLetter(c) && c != '/' && c != ' ') {
                return false;
            }
        }

        return true;
    }
}