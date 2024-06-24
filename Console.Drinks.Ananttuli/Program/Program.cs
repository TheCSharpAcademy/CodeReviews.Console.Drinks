﻿using DrinksApi;
using DrinksApi.Categories;
using DrinksApi.Drinks;
using Program.Utils;
using Spectre.Console;

namespace Program;

// List categories 
// https://www.thecocktaildb.com/api/json/v1/1/list.php?c=list

// Filter drinks by category name
// https://www.thecocktaildb.com/api/json/v1/1/filter.php?c=Shake

// Fetch drink details
// www.thecocktaildb.com/api/json/v1/1/lookup.php?i=14588

public class Program
{
    static DrinksApi.Api Api = new(new DrinksApi.Client());

    public static void Main()
    {
        StartApp().GetAwaiter().GetResult();
    }

    public static async Task StartApp()
    {
        string response = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("DRINKS MENU")
                .AddChoices([MainMenuOption.OpenMenu, MainMenuOption.Exit])
        );

        switch (response)
        {
            case MainMenuOption.OpenMenu:
                await OpenMenu();
                break;
            case MainMenuOption.Exit:
                break;
        }
    }

    public static async Task OpenMenu()
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

        var selectedCategory = AnsiConsole.Prompt(
            new SelectionPrompt<CategoryDto>()
                .Title("CATEGORIES")
                .AddChoices([
                    new CategoryDto(Utils.ConsoleUtil.MenuBackButtonText),
                    ..categories
                ])
                .EnableSearch()
        );

        if (selectedCategory == null ||
            selectedCategory.StrCategory.Equals(Utils.ConsoleUtil.MenuBackButtonText)
        )
        {
            return;
        }

        await ShowDrinksInCategory(selectedCategory);
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

        var selectedDrink = AnsiConsole.Prompt(
            new SelectionPrompt<DrinkFilterListItemDto>()
                .Title($"{category.StrCategory}\nDRINKS\n")
                .AddChoices([
                    new DrinkFilterListItemDto("", Utils.ConsoleUtil.MenuBackButtonText, ""),
                    ..drinksInCategory
                ])
                .EnableSearch()
        );

        if (selectedDrink == null || selectedDrink.IdDrink.Equals("-1"))
        {
            return;
        }

        await ShowDrinkInfo(selectedDrink);
    }

    public static async Task ShowDrinkInfo(DrinkFilterListItemDto drink)
    {
        var (success, drinkInfo) = await Api.FetchDrinkInfo(drink.IdDrink);

        if (drinkInfo == null || !success)
        {
            return;
        }

        PrintDrinkInfo(drinkInfo);

        Utils.ConsoleUtil.PressAnyKeyToClear();
    }

    public static void PrintDrinkInfo(DrinkDto drink)
    {
        var panel = new Panel("");
        panel.Header = new PanelHeader(drink.Name ?? "");
    }
}

class MainMenuOption
{
    public const string OpenMenu = "Open Menu";
    public const string Exit = "[red]Exit[/]";
}
