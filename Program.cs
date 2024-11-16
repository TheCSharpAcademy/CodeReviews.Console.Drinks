using Drinks.TwilightSaw.View;
using System.Net.Http.Headers;
using System.Text.Json;
using Drinks.TwilightSaw.Controller;
using Drinks.TwilightSaw.Model;
using Spectre.Console;

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