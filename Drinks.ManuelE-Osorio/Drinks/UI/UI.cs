namespace DrinksProgram;

public class UI
{
    public static void WelcomeMessage()
    {
        Helpers.ClearConsole();
        Console.WriteLine("Welcome to the Drinks Menu App!\n");
        Thread.Sleep(2000);
    }

    public static void MainMenu()
    {
        Console.WriteLine(
            "Use the up and down arrows to select a Category.\n"+
            "Press enter to see the drinks in the selected Category.\n"+
            "Press backspace or ESC to exit the application");
    }

    public static void DrinksByCategory()
    {
            Console.WriteLine(
            "Use the up and down arrows to select a Drink.\n"+
            "use the left and right arrows to see more Drinks.\n"+
            "Press enter to see the Drink Details for the selected Drink.\n"+
            "Press backspace or ESC to return");
    }
    public static void ExitMessage(string? errorMessage)
    {
        Helpers.ClearConsole();
        if(errorMessage != null)
            Console.WriteLine("Error: " + errorMessage);

        Console.WriteLine("Thank you for using the Drinks Menu App!\n");
        Thread.Sleep(2000);
    }

    public static void DrinkDetail()
    {
        Console.WriteLine("Press any key to return. \n");
    }
}