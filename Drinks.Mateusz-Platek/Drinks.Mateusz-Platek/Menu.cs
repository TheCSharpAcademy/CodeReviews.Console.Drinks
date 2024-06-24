using Drinks.Mateusz_Platek.Models;
using Spectre.Console;

namespace Drinks.Mateusz_Platek;

public static class Menu
{
    private static void ContinueInput()
    {
        AnsiConsole.Prompt(
            new TextPrompt<string>("[bold red]Press enter to continue[/]")
                .AllowEmpty()
        );
    }
    
    private static string GetRunOption()
    {
        AnsiConsole.Clear();
        return AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("[bold underline darkorange]Menu[/]")
                .AddChoices(["Exit", "Browse drinks", "View favorite drinks", "View most searched drinks"])
                .UseConverter(choice => $"[bold green]{choice}[/]")
        );
    }
    
    public static async Task Run()
    {
        bool end = false;
        while (!end)
        {
            string option = GetRunOption();
            switch (option)
            {
                case "Exit":
                    end = true;
                    break;
                case "Browse drinks":
                    await SelectCategory();
                    break;
                case "View favorite drinks":
                    await RunFavoriteDrinks();
                    break;
                case "View most searched drinks":
                    DrinkController.DisplayMostSearchedDrinks();
                    ContinueInput();
                    break;
            }
        }
    }

    private static async Task RunFavoriteDrinks()
    {
        bool end = false;
        while (!end)
        {
            Drink drink = DrinkController.SelectFavoriteDrink();
            switch (drink.name)
            {
                case "Move back":
                    end = true;
                    break;
                default:
                    await RunFavoriteDrink(drink);
                    break;
            }
        }
    }

    private static string GetFavoriteDrinkOption(Drink drink)
    {
        AnsiConsole.Clear();
        return AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title($"[bold underline darkorange]{drink.name}[/]")
                .AddChoices(["Move back", "View details", "Remove from favorites"])
                .UseConverter(choice => $"[bold green]{choice}[/]")
        );
    }

    private static async Task RunFavoriteDrink(Drink drink)
    {
        bool end = false;
        while (!end)
        {
            string option = GetFavoriteDrinkOption(drink);
            switch (option)
            {
                case "Move back":
                    end = true;
                    break;
                case "View details":
                    await DrinkController.GetDrinkDetails(drink);
                    ContinueInput();
                    break;
                case "Remove from favorites":
                    DrinkRepository.RemoveFavoriteDrink(drink);
                    end = true;
                    break;
            }
        }
    }

    private static async Task SelectCategory()
    {
        bool end = false;
        while (!end)
        {
            AnsiConsole.Clear();
            Category? category = await DrinkController.SelectCategory();
            if (category == null)
            {
                return;
            }
            
            switch (category.name)
            {
                case "Move back":
                    end = true;
                    break;
                default:
                    await SelectDrink(category);
                    break;
            }
        }
    }

    private static async Task SelectDrink(Category category)
    {
        bool end = false;
        while (!end)
        {
            AnsiConsole.Clear();
            Drink? drink = await DrinkController.SelectDrink(category);
            if (drink == null)
            {
                return;
            }
            
            switch (drink.name)
            {
                case "Move back":
                    end = true;
                    break;
                default:
                    await RunDrink(drink);
                    break;
            }
        }
    }

    private static string GetDrinkOption(Drink drink)
    {
        AnsiConsole.Clear();
        return AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title($"[bold underline darkorange]{drink.name}[/]")
                .AddChoices(["Move back", "View details", "Add to favorites"])
                .UseConverter(choice => $"[bold green]{choice}[/]")
        );
    }

    private static async Task RunDrink(Drink drink)
    {
        bool end = false;
        while (!end)
        {
            string option = GetDrinkOption(drink);
            switch (option)
            {
                case "Move back":
                    end = true;
                    break;
                case "View details":
                    await DrinkController.GetDrinkDetails(drink);
                    ContinueInput();
                    break;
                case "Add to favorites":
                    DrinkController.AddFavoriteDrink(drink);
                    ContinueInput();
                    break;
            }
        }
    }
}