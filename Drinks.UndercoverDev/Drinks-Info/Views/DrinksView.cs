using Drinks_Info.Controller;
using Drinks_Info.Models;
using Drinks_Info.Services;
using Drinks_Info.Utilities;
using Spectre.Console;

namespace Drinks_Info.Views
{
    public class DrinksView
    {
        private readonly ApiService? _apiService;
        private readonly DrinkController _drinkController;

        public DrinksView(DrinkController drinkController ,ApiService apiService)
        {
            _drinkController = drinkController;
            _apiService = apiService;
        }

        public async Task ShowDrinksMenuAsync(string categoryName)
        {
            ConsoleHelper.PrintMessage("[yellow]Fetching drinks...[/]");

            var drinks = await _apiService.GetDrinksByCategoryAsync(categoryName);

            if (drinks.Count == 0)
            {
                ConsoleHelper.PrintMessage("[red]No drinks found[/]");
            }
            else
            {
                ConsoleHelper.PrintMessage("[green]Drinks fetched successfully![/]\n\n");

                var drinkName = ShowDrinks(drinks);
                await _drinkController.DrinkDetailsAsync(drinkName);
            }
        }

        public async Task<string> ShowDrinks(List<Drink> drinks)
        {
            drinks.Insert(0, new Drink { StrDrink = "Back" });

            var drinkSelector = new SelectionPrompt<Drink>
            {
                Title = "[bold][blue]Please select a drink[/][/]"
            };
            drinkSelector.AddChoices(drinks);
            drinkSelector.UseConverter(drinks => drinks.StrDrink);
            drinkSelector.PageSize = 25;

            var drinkSelected = AnsiConsole.Prompt(drinkSelector);

            if (drinkSelected.StrDrink == "Back")
                await _drinkController.MainMenuViewAsync();

            return drinkSelected.StrDrink;
        }
    }
}