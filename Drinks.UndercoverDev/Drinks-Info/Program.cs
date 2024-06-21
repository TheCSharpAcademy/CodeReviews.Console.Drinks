using Drinks_Info.Controller;
using Drinks_Info.Services;
using Drinks_Info.Views;

var apiService = new ApiService();
var controller = new DrinkController(apiService);

await controller.RunAppAsync();