using Drinks.tonyissa.UI;

bool outBool = true;

while (outBool)
{
    try
    {
        Console.Clear();
        await UserInterface.PrintMainMenu();
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.ToString());
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }
}