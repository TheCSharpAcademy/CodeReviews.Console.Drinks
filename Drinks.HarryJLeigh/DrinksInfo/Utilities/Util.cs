using ConsoleTableExt;
using DrinksInfo.Models;

namespace DrinksInfo.Utilities;

public static class Util
{
    internal static bool ReturnToMenu()
    {
        Console.WriteLine("Press any key to to return to menu or '0' to exit the program");
        string input = Console.ReadLine();
        if (input == "0")
        {
            return true;
        }
        return false;
    }
}