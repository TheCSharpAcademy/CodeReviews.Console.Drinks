using Drinks.K_MYR;

class Program
{
    private static readonly HttpClient apiClient = new()
    {
        BaseAddress = new Uri("http://www.thecocktaildb.com/api/json/v1/1/")
    };

    static async Task Main()
    {
        var apiRepo = new ApiAccess(apiClient);
        var sqlRepo = new SqlAcess();
        var controller = new DrinksController(apiRepo, sqlRepo);
        var userInterface = new UserInterface(controller);
        await userInterface.RunApp();
    }
}
