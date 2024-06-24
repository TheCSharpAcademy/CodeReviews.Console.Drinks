using Drinks_Info.Controller;
using Drinks_Info.Models;
using Drinks_Info.Services;
using Drinks_Info.Utilities;
using Spectre.Console;

namespace Drinks_Info.Views
{
    public class MenuView
    {
        private readonly ApiService? _apiService;
        private readonly DrinkController _drinkController;

        public MenuView(DrinkController drinkController,ApiService apiService)
        {
            _drinkController = drinkController;
            _apiService = apiService;
        }

        public async Task ShowMainMenuAsync()
        {
            ConsoleHelper.PrintMessage("[yellow]Fetching drink categories...[/]\n");

            var categories = await _apiService.GetCategoriesAsync();

            if (categories.Count == 0)
            {
                ConsoleHelper.PrintMessage("[red]No Categories found[/]\n\n");
            }
            else
            {

                ConsoleHelper.PrintMessage("[green]Categories of drinks fetched successfully![/]\n\n");

                var categorySelected = ShowDrinksByCategory(categories);
                await _drinkController.DrinksMenuAsync(categorySelected.StrCategory);
            }
        }

        public static Category ShowDrinksByCategory(List<Category> categories)
        {
            categories.Insert(0, new Category { StrCategory = "Exit" });

            var categorySelector = new SelectionPrompt<Category>
            {
                Title = "[bold][blue]Please select a category[/][/]"
            };
            categorySelector.AddChoices(categories);
            categorySelector.UseConverter(categories => categories.StrCategory);
            categorySelector.PageSize = 25;

            var categorySelected = AnsiConsole.Prompt(categorySelector);

            if (categorySelected.StrCategory == "Exit")
                Exit();

            return categorySelected;
        }

        public static void Exit()
        {
            ConsoleHelper.PrintMessage("[red]Exiting...[/]\n\n");
            Environment.Exit(0);
        }
    }
}