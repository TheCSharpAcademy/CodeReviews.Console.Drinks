namespace Drinks;

using System.Reflection;
using TheCocktailDb;

class Program
{
    static void Main(string[] args)
    {
        var config = new Configuration();
        var apiClient = new ApiClient(config);
        var controller = new MainController(apiClient);
        controller.ShowDrinkCategories();
    }
}