using Drinks.TwilightSaw.View;
using Drinks.TwilightSaw.Controller;

class Program
{
    static async Task Main(string[] args)
    {
        using HttpClient client = new();

        var controller = new DrinksController(client);
        var menu = new Menu(controller);

        await menu.MainMenu();
    }
}