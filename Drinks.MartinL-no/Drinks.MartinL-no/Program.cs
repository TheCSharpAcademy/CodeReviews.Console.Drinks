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

        var categories = await repo.GetCategories();
        var drinks = await repo.GetDrinks(categories[0].Name);
        var drinkDetails = await repo.GetDrinkDetails(drinks[0].Id);
        Console.WriteLine();
    }
}
