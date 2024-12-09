namespace DrinksProject.Helpers
{
    public class Validator
    {
        public static bool IsCategoryValid(string category)
        {
            if (string.IsNullOrEmpty(category))
                return false;
            foreach (char c in category)
            {
                if (!char.IsLetter(c) && c != '/' && c != ' ')
                    return false;
            }
            return true;
        }
        public static bool IsIdValid(string input)
        {
            if (string.IsNullOrEmpty(input))
                return false;
            foreach (char c in input)
            {
                if (!char.IsDigit(c)) return false;
            }
            return true;
        }

    }

}
