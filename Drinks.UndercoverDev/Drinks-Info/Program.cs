using Drinks_Info.Controller;
using Drinks_Info.Services;
using Drinks_Info.Views;

var apiService = new ApiService();
var drinkService = new DrinkService();
var menuView = new MenuView(apiService, drinkService);
var controller = new DrinkController(menuView);

await controller.RunAppAsync();