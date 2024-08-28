using Drinks.tonyissa.UI;

await StartLoop();
async static Task StartLoop()
{
    try
    {
        await UserInterface.PrintMainMenu();
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.ToString());
        Console.WriteLine("\nUnhandled exception. Press any key to continue...");
        Console.ReadKey();
        await StartLoop();
    }
}