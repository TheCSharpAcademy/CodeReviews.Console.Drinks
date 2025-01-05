using DrinksInfo.Utilities;
using DrinksInfo.Controllers;
using DrinksInfo.Views;
using System.Globalization;
using Spectre.Console;

namespace DrinksInfo.Coordinators;

internal class AppCoordinator
{
    private readonly DrinksService _drinksService;
    private readonly MenuHandler _menuHandler;
    private readonly DrinksControllers _drinksControllers;
    private readonly FindMatching _findMatching;
    private readonly GetObjectPropertyValues _getObjectPropertyValues;

    public AppCoordinator(DrinksService drinksService, MenuHandler menuHandler, DrinksControllers drinksControllers, FindMatching findMatching, GetObjectPropertyValues getObjectPropertyValues)
    {
        _drinksService = drinksService;
        _menuHandler = menuHandler;
        _drinksControllers = drinksControllers;
        _findMatching = findMatching;
        _getObjectPropertyValues = getObjectPropertyValues;
    }
    internal async Task Start()
    {
        bool isAppRunning = true;

        while (isAppRunning)
        {
            // Get list from API
            var categories = await _drinksService.GetDrinksCategoriesAsync();
            // Show list to user
            _menuHandler.ShowCategoryMenu(categories);
            // Get users input and validate
            string? drinkCategorySelected = _drinksControllers.GetCategory();

            if (string.IsNullOrWhiteSpace(drinkCategorySelected)) return;

            // Match users input against category list
            bool isCategoryMatch = _findMatching.FindMatchingCategory(categories, drinkCategorySelected);
            if (isCategoryMatch)
            {
                TextInfo textInfo = new CultureInfo("en-GB", false).TextInfo;
                // Capitalise each word in string
                string drink = textInfo.ToTitleCase(drinkCategorySelected);
                var drinks = await _drinksService.GetDrinksAsync(drink);
                // Display all drinks belonging to particular category
                _menuHandler.ShowDrinksMenu(drinks);


                string? userSelectedDrinkId = _drinksControllers.GetDrinkDetail();
                if (userSelectedDrinkId == "0") continue;
                if (!string.IsNullOrWhiteSpace(userSelectedDrinkId))
                {
                    await ShowDrinkDetails(userSelectedDrinkId);
                    AnsiConsole.WriteLine("Press any key to close app");
                    Console.ReadKey(true);
                    Environment.Exit(0);
                }
            }
            else
            {
                AnsiConsole.WriteLine("Invalid category selected, Press any key to return to Category Menu...");
                Console.ReadKey(true);
            }
        }
    }

    internal async Task ShowDrinkDetails(string userSelectedDrinkId)
    {
        var drinkDetail = await _drinksService.GetDrinkDetailAsync(userSelectedDrinkId);
        object? drinkDetailObj = drinkDetail.FirstOrDefault();
        if (drinkDetailObj == null)
        {
            AnsiConsole.WriteLine($"No details found for drink with id: {userSelectedDrinkId}");
            return;
        }
        var propertyValues = _getObjectPropertyValues.RetrievePropertiesValues(drinkDetailObj);
        _menuHandler.ShowDrinkDetailMenu(propertyValues);
    }
}

