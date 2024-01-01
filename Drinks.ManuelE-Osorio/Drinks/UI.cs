namespace DrinksProgram;

public class UI
{
    public static void WelcomeMessage()
    {
        Helpers.ClearConsole();
        Console.WriteLine("Welcome to the Drinks Menu App!\n");
        Thread.Sleep(2000);
    }

    public static void MainMenu(string? errorMessage)
    {
        // Helpers.ClearConsole();
        
        if (errorMessage != null)
        {
            Console.WriteLine("Error: " + errorMessage+"\n");
        }

        Console.WriteLine(
            "Please write the name of the category:"); //make it fancier
    }

    public static void DrinksByCategory(string? errorMessage)
    {
        if (errorMessage != null)
            Console.WriteLine("Error:" + errorMessage + "\n");

        Console.WriteLine("Enter a drink ID to see the details or 0 to return:\n");
    }
    public static void ExitMessage()
    {
        Helpers.ClearConsole();
        Console.WriteLine("Thank you for using the Drinks Menu App!\n");
        Thread.Sleep(2000);
    }
}