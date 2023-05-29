namespace DrinksLibrary.Data;

public static class Validator
{
    public static bool IsValidChoice<T>(string choice, List<T> menu) where T : class
    {
        if (string.IsNullOrEmpty(choice))
        {
            return false;
        }

        if (choice.Any(x => char.IsNumber(x)) == false)
        {
            return false;
        }

        if (int.Parse(choice) <= 0 || int.Parse(choice) > menu.Count)
        {
            return false;
        }

        return true;
    }
}