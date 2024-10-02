namespace DrinksInfo
{
    public class Validation
    {
        internal static bool IsIdValid(string? drink)
        {
            if (string.IsNullOrEmpty(drink)) return false;

            foreach (char c in drink)
            {
                if(!char.IsDigit(c)) return false;
            }
            return true;
        }

        internal static bool IsString(string stringInput)
        {
            if (String.IsNullOrEmpty(stringInput)) {  return false; }

            foreach (char c in stringInput)
            {
                if (!Char.IsWhiteSpace(c) && !Char.IsLetter(c) && c != '/')
                {
                    return false;
                }
            }
            return true;
        }
    }
}
