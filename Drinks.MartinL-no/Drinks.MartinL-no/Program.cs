using Drinks.MartinL_no.DAL;
using Drinks.MartinL_no.Controllers;
using Drinks.MartinL_no.UserInterface;

namespace Drinks.MartinL_no;

class Program
{
    private static HttpClient sharedClient = new()
    {
        BaseAddress = new Uri("http://www.thecocktaildb.com/api/json/v1/1/")
    };

    static async Task Main()
    {
        var repo = new DrinksDataAccess(sharedClient);
        var controller = new DrinksController(repo);
        var app = new UserInput(controller);

        await app.Run();
    }
}
