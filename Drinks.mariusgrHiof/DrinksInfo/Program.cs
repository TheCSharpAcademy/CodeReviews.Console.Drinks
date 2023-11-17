using DrinksInfo.Api;
using DrinksInfo.Controllers;
using DrinksInfo.UI;

HttpClient client = new HttpClient()
{
    BaseAddress = new Uri("https://www.thecocktaildb.com/api/json/v1/1/")
};
ApiClient apiClient = new ApiClient(client);

DrinksController drinksController = new DrinksController(apiClient);

UserInterface ui = new UserInterface(drinksController);

await ui.Run();
