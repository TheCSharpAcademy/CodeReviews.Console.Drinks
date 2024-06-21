using Drinks_Info.Services;
using Drinks_Info.Utilities;
using Drinks_Info.Views;

namespace Drinks_Info.Controller
{
    public class DrinkController
    {
        private readonly MenuView _menuView;
        bool endApp = false;

        public DrinkController(MenuView menuView)
        {
            _menuView = menuView;
        }

        public async Task RunAppAsync()
        {
            // while (!endApp)
            // {
            //     _menuView.ShowMainMenuAsync();
            // }
            ConsoleHelper.PrintMessage("Welcome to the [blue]Drink Menu[/] Application");
            await _menuView.ShowMainMenuAsync();
        }
    }
}