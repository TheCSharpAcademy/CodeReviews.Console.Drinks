namespace Drinks;

using TheCocktailDb;

class Program
{
    static void Main(string[] args)
    {
        var baseUri = new Uri("https://www.thecocktaildb.com/api/json/v1/1/");
        var apiClient = new ApiClient(baseUri);
        var controller = new MainController(apiClient);
        controller.ShowDrinkCategories();
    }
}