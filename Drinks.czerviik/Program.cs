// See https://aka.ms/new-console-template for more information
namespace drinks_info;

internal class Program
{
    private static void Main(string[] args)
    {
        var configReader = new ConfigReader();
        try
        {
            var drinksService = new DrinksService();

            var connectionString = configReader.GetConnectionString();
            var drinksDb = new DrinksDb(connectionString);
            var menuManager = new MenuManager(drinksService,drinksDb);

            menuManager.DisplayCurrentMenu();
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Error:{ex.Message}");
            Environment.Exit(1);
        }
    }
}