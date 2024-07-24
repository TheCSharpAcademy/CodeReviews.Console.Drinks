using DrinksInfo.ConsoleApp.Views;

namespace DrinksInfo.ConsoleApp;

internal class Program
{
    /// <summary>
    /// Insertion point for the application.
    /// Launches the main menu; catches and displays any errors.
    /// </summary>
    static void Main()
    {
        try
        {
            MainMenuPage.Show();
        }
        catch (Exception exception)
        {
            MessagePage.Show("Error", exception);
        }
        finally
        {
            Environment.Exit(0);
        }
    }
}
