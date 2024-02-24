namespace DrinksConsoleApp;
public class Entrance
{
    static async Task Main(string[] args)
    {
        Application app = new Application();
        await app.run();
    }
}