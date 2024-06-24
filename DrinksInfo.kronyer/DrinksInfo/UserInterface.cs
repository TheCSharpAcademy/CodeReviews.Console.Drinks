using DrinksInfo.Models;
using Spectre.Console;
using static DrinksInfo.Models.Enums;

namespace DrinksInfo;

internal class UserInterface
{
    public static void RunMenu()
    {
        bool isRunning = true;
        while (isRunning)
        {
            Console.Clear();
            var uChoice = AnsiConsole.Prompt(new SelectionPrompt<MenuChoices>().Title("Pick your choice").AddChoices(MenuChoices.DrinksCategories, MenuChoices.SearchDrinkByName, MenuChoices.RandomDrink, MenuChoices.Quit));

            switch (uChoice)
            {
                case MenuChoices.DrinksCategories:
                    DrinksCategories();
                    break;
                case MenuChoices.SearchDrinkByName:
                    SearchByNameUI();
                    break;
                case MenuChoices.RandomDrink:
                    DataAccess.RandomDrink();
                    break;
                case MenuChoices.Quit:
                    isRunning = false;
                    Console.WriteLine("Bye");
                    break;
            }
        }
    }

    private static void DrinksCategories()
    {
        var uChoice = AnsiConsole.Prompt(new SelectionPrompt<DrinkCategories>().Title("Pick your choice").AddChoices(DrinkCategories.OrdinaryDrink, DrinkCategories.Cocktail, DrinkCategories.Shake, DrinkCategories.Cocoa, DrinkCategories.Shot, DrinkCategories.CoffeOrTea, DrinkCategories.HomemadeLiqueur, DrinkCategories.Punch, DrinkCategories.Beer, DrinkCategories.SoftDrink, DrinkCategories.Other));

        switch (uChoice)
        {
            case DrinkCategories.OrdinaryDrink:
                DataAccess.SearchByCategories("Ordinary_drink");
                break;
            case DrinkCategories.Cocktail:
                DataAccess.SearchByCategories("Cocktail");
                break;
            case DrinkCategories.Shake:
                DataAccess.SearchByCategories("Shake");
                break;
            case DrinkCategories.Cocoa:
                DataAccess.SearchByCategories("Cocoa");
                break;
            case DrinkCategories.Shot:
                DataAccess.SearchByCategories("Shot");
                break;
            case DrinkCategories.CoffeOrTea:
                DataAccess.SearchByCategories("Coffee_/_Tea");
                break;
            case DrinkCategories.HomemadeLiqueur:
                DataAccess.SearchByCategories("Homemade_Liqueur");
                break;
            case DrinkCategories.Punch:
                DataAccess.SearchByCategories("Punch_/_Party Drink");
                break;
            case DrinkCategories.Beer:
                DataAccess.SearchByCategories("Beer");
                break;
            case DrinkCategories.SoftDrink:
                DataAccess.SearchByCategories("Soft_Drink");
                break;
            case DrinkCategories.Other:
                DataAccess.SearchByCategories("Other_/_Unknown");
                break;
        }
    }

    public static void SearchByNameUI()
    {
        string drinksName = AnsiConsole.Ask<string>("Type the drink you want to search for: ");
        Console.Clear();
        while (string.IsNullOrEmpty(drinksName))
            drinksName = AnsiConsole.Ask<string>("Name can't be empty\n");
        

        DataAccess.SearchByName(drinksName);
    }

    internal static void PrintDrink(Drinks? selectedDrink)
    {
        Console.WriteLine($@"Name: {selectedDrink.Name}

Category: {selectedDrink.Category}

Ingredients:
{selectedDrink.Ingredient1}
{selectedDrink.Ingredient2}
{selectedDrink.Ingredient3}
{selectedDrink.Ingredient4}
{selectedDrink.Ingredient5}

Instructions:
{selectedDrink.Instructions}");
        Console.ReadKey();
    }
}
