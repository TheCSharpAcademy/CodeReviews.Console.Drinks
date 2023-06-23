namespace Drinks.barakisbrown;

public class UserInput
{
    private static string? CategoryNameInput = "Please Select a category from the list above? |> ";
    private static string? PressAnyKeyInput = "Press any key to return to the main menu.";

    DrinksService _service = new();

	public UserInput()
	{
	}

    public static bool GetYesNo(string? prompt)
    {
        bool retValue = false;
        bool exit = true;
        Console.Write(prompt);
        while(exit)
        {
            ConsoleKeyInfo input = Console.ReadKey(true);
            if (input.Key == ConsoleKey.Y)
            {
                exit = false;
                retValue = true;
                break;
            }
            else if (input.Key == ConsoleKey.N)
            {
                exit = false;
                retValue = false;
            }
        }
        return retValue;
    }

    public static void ReturnMainMenu()
    {
        Console.Write(PressAnyKeyInput);
        Console.ReadKey(true);
        Thread.Sleep(800);
        Console.Clear();
    }

    public static bool IsStringValid(string stringInput)
    {
        if (string.IsNullOrEmpty(stringInput))
        {
            return false;
        }

        foreach (char c in stringInput)
        {
            if (!Char.IsLetter(c) && c != '/' && c != ' ')
                return false;
        }

        return true;
    }
}

