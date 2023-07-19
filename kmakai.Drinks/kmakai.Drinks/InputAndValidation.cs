
namespace kmakai.Drinks;

public class InputAndValidation
{
    public static string GetCategoryInput()
    {
        Console.WriteLine("Please enter a category name or x to exit: ");
        string? input = Console.ReadLine();

        while (!IsValidCategoryInput(input) && input != "x")
        {
            
            Console.WriteLine("Please enter a valid category name or x to exit: ");
            input = Console.ReadLine();
        }



        return input;
    }

    public static string GetDrinkInput()
    {
        Console.WriteLine("Please enter a drink Id or x to return: ");
        string? input = Console.ReadLine();



        while (!IsValidDrinkInput(input) && input != "x")
        {
            Console.WriteLine("Please enter a valid drink Id or x to return: ");
            input = Console.ReadLine();
        }


        return input;
    }

    private static bool IsValidDrinkInput(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return false;
        }
        foreach (char c in input)
        {
            if (!char.IsDigit(c))
            {
                return false;
            }
        }
        return true;
    }

    public static bool IsValidCategoryInput(string categoryInput)
    {
        if (string.IsNullOrEmpty(categoryInput))
        {
            return false;
        }
        foreach (char c in categoryInput)
        {
            if (!char.IsLetter(c) && c != '/')
            {
                return false;
            }
        }

        return true;
    }

    internal static bool GetContinue()
    {
        Console.WriteLine("Would you like to continue? (y/n)\n\n");
        string? input = Console.ReadLine();
        while (!IsValidContinueInput(input))
        {
            Console.WriteLine("Please enter a valid input: \n\n");
            input = Console.ReadLine();
        }

        return input == "y";
    }

    private static bool IsValidContinueInput(string? input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return false;
        }
        if (input != "y" && input != "n")
        {
            return false;
        }
        return true;
    }
}
