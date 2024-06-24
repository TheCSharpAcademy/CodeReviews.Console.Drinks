using Drinks_Info.Controller;
using Drinks_Info.Models;
using Drinks_Info.Services;
using Drinks_Info.Utilities;
using Spectre.Console;

namespace Drinks_Info.Views
{
    public class DrinkDetailsView
    {
        private readonly DrinkController? _drinkController;
        private readonly ApiService? _apiService;

        public DrinkDetailsView(DrinkController drinkController,ApiService apiService)
        {
            _drinkController = drinkController;
            _apiService = apiService;
        }

        internal async Task ShowDrinkDetailsAsync(Task<string> drinkSelected)
        {
            ConsoleHelper.PrintMessage("[yellow]Fetching drink details...[/]");

            var drinkDetails = await _apiService.GetDrinkDetailsAsync(drinkSelected.Result);

            if (drinkDetails.StrDrink == null)
            {
                ConsoleHelper.PrintMessage("[red]Drink not found[/]");
            }
            else
            {
                ConsoleHelper.PrintMessage("[green]Drink details fetched successfully![/]\n\n");

                ShowDrinkDetailTable(drinkDetails);

                ConsoleHelper.PrintMessage("[green]Enter 'Y' to go Back or Enter any character to go back to the main menu[/]\n\n");
                var keyPressed = Utils.GetUserResponse();
                if ("y" == keyPressed.ToLower())
                    await _drinkController.DrinksMenuAsync(drinkDetails.StrCategory);
                else
                    await _drinkController.MainMenuViewAsync();
            }
        }

        public static void ShowDrinkDetailTable(DrinkDetails drinkDetails)
        {
            var propList = Utils.FormatPropertyName(drinkDetails);

            var table = new Table { Border = TableBorder.DoubleEdge };
            table.AddColumn("[green3_1]Properties[/]");
            table.AddColumn("[cyan2]Value[/]");

            foreach (var item in propList)
            {
                table.AddRow($"[green1]{item.Key}[/]", $"[cyan2]{item.Value}[/]");
                table.AddEmptyRow();
            }

            ConsoleHelper.PrintTable(table);

            ConsoleHelper.PrintMessage("\n\n");
        }
    }
}