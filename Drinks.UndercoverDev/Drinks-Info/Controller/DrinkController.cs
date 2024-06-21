using Drinks_Info.Services;
using Drinks_Info.Utilities;
using Drinks_Info.Views;

namespace Drinks_Info.Controller
{
    public class DrinkController
    {
        private readonly ApiService _apiService;

        public DrinkController(ApiService apiService)
        {
            _apiService = apiService;
        }
        
        public async Task RunAppAsync()
        {
            ConsoleHelper.ClearScreen();
            ConsoleHelper.PrintMessage("Welcome to the [blue]Drink Menu[/] Application");

            await MainMenuViewAsync();
        }

        public async Task MainMenuViewAsync()
        {
            var menuView = new MenuView(this, _apiService);
            await menuView.ShowMainMenuAsync();
        }

        public async Task DrinksMenuAsync(string categoryName)
        {
            ConsoleHelper.ClearScreen();
            var drinksView = new DrinksView(this, _apiService);
            await drinksView.ShowDrinksMenuAsync(categoryName);
        }

        internal async Task DrinkDetailsAsync(Task<string> drinkSelected)
        {
            ConsoleHelper.ClearScreen();
            var drinkDetailsView = new DrinkDetailsView(this, _apiService);
            await drinkDetailsView.ShowDrinkDetailsAsync(drinkSelected);
        }
    }
}