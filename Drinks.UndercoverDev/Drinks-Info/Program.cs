using Drinks_Info.Controller;
using Drinks_Info.Services;

var apiService = new ApiService();
var controller = new DrinkController(apiService);

await controller.RunAppAsync();