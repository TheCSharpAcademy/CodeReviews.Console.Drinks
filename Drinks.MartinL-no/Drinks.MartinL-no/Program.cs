using Drinks.MartinL_no.Controllers;
using Drinks.MartinL_no.DAL;

namespace Drinks.MartinL_no;

class Program
{
    private static HttpClient sharedClient = new()
    {
        BaseAddress = new Uri("http://www.thecocktaildb.com/api/json/v1/1/")
    };

    static async Task Main(string[] args)
    {
        var repo = new DrinksDataAccess(sharedClient);
        var controller = new DrinksController(repo);
        var app = new UserInput(controller);

        app.Run()
    }
}
