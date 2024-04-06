// See https://aka.ms/new-console-template for more information
namespace drinks_info;

internal class Program
{
    private static void Main(string[] args)
    {
        var drinksService = new DrinksService();
        var menuManager = new MenuManager(drinksService);

        menuManager.DisplayCurrentMenu();
    }
}