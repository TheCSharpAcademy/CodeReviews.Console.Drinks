using DrinksApi;
using DrinksApi.Categories;
using DrinksApi.Drinks;
using Spectre.Console;

namespace Program;

public class Program
{
    static readonly DrinksApi.Api Api = new(new DrinksApi.Client());

    public static void Main()
    {
        StartApp().GetAwaiter().GetResult();
    }

    public static async Task StartApp()
    {
        var shouldExit = false;
        do
        {
            string response = MainMenu.Prompt();

            switch (response)
            {
                case MainMenu.OpenMenu:
                    await OpenDrinksMenu();
                    break;
                case MainMenu.Exit:
                    shouldExit = true;
                    break;
            }
        }
        while (shouldExit == false);

    }

    public static async Task OpenDrinksMenu()
    {
        var (success, categories) = await Api.FetchCategories();

        if (!success)
        {
            Utils.Text.Error("Could not fetch categories");
            Utils.ConsoleUtil.PressAnyKeyToClear(
                "Press any key to go back"
            );
            return;
        }

        while (true)
        {
            var selectedCategory = CategoriesController.SelectCategory(categories);

            if (selectedCategory == null)
            {
                break;
            }

            await ShowDrinksInCategory(selectedCategory);
        }
    }

    public static async Task ShowDrinksInCategory(CategoryDto category)
    {
        var (success, drinksInCategory) = await Api.FetchDrinksInCategory(category);

        if (!success)
        {
            Utils.Text.Error($"Could not fetch drinks for category {category.StrCategory}");
            Utils.ConsoleUtil.PressAnyKeyToClear(
                "Press any key to go back"
            );
            return;
        }

        while (true)
        {
            var selectedDrink = CategoriesController.SelectDrinkFromCategory(category, drinksInCategory);

            if (selectedDrink == null)
            {
                break;
            }

            await OpenDrinkInfo(selectedDrink);
        }

    }

    public static async Task OpenDrinkInfo(DrinkFilterListItemDto drink)
    {
        var (success, drinkInfo) = await Api.FetchDrinkInfo(drink.IdDrink);

        if (drinkInfo == null || !success)
        {
            Utils.Text.Error($"Could not load info for drink ID {drink.IdDrink}");
            return;
        }

        DrinksController.PrintDrinkInfo(drinkInfo);

        Utils.ConsoleUtil.PressAnyKeyToClear();
    }
}
