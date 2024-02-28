using System.Reflection;
using Drinks.Mateusz_Platek.Models;
using Spectre.Console;

namespace Drinks.Mateusz_Platek;

public static class DrinkController
{
    public static async Task<Category?> SelectCategory()
    {
        List<Category>? categories = await DrinkService.GetCategories();
        if (categories == null)
        {
            return null;
        }
        
        categories.Insert(0, new Category("Move back"));
        
        return AnsiConsole.Prompt(new SelectionPrompt<Category>()
            .Title("[bold underline darkorange]Categories:[/]")
            .PageSize(6)
            .AddChoices(categories)
            .UseConverter(category => $"[bold green]{category.name}[/]")
            .MoreChoicesText("[bold yellow]Move up or down to reveal more options[/]"));
    }

    public static async Task<Drink?> SelectDrink(Category category)
    {
        List<Drink>? drinks = await DrinkService.GetDrinksByCategory(category);
        if (drinks == null)
        {
            return null;
        }
        
        drinks.Insert(0, new Drink(0, "Move back"));
        
        return AnsiConsole.Prompt(new SelectionPrompt<Drink>()
            .Title("[bold underline darkorange]Drinks:[/]")
            .PageSize(6)
            .AddChoices(drinks)
            .UseConverter(drink => $"[bold green]{drink.name}[/]")
            .MoreChoicesText("[bold yellow]Move up or down to reveal more options[/]"));
    }

    public static async Task GetDrinkDetails(Drink drink)
    {
        List<DrinkDetails>? drinkDetailsList = await DrinkService.GetDrinkDetails(drink);
        if (drinkDetailsList == null)
        {
            return;
        }
        
        Table table = new Table()
            .AddColumn("[bold darkorange]Property[/]")
            .AddColumn("[bold lime]Value[/]");
        
        DrinkDetails drinkDetails = drinkDetailsList[0];
        PropertyInfo[] properties = drinkDetails.GetType().GetProperties();
        foreach (PropertyInfo property in properties)
        {
            object? value = property.GetValue(drinkDetails);
            if (value == null)
            {
                continue;
            }

            table.AddRow($"[bold darkorange]{property.Name}[/]", $"[bold lime]{value}[/]");
        }
        
        AnsiConsole.Write(table);
        
        DrinkRepository.CountDrink(drink);
    }

    public static Drink SelectFavoriteDrink()
    {
        List<Drink> drinks = DrinkRepository.GetFavoriteDrinks();
        
        drinks.Insert(0, new Drink(0, "Move back"));

        return AnsiConsole.Prompt(
            new SelectionPrompt<Drink>()
                .Title("[bold underline darkorange]Favorite drinks[/]")
                .AddChoices(drinks)
                .UseConverter(drink => $"[bold green]{drink.name}[/]")
                .PageSize(6)
                .MoreChoicesText("[bold yellow]Move up or down to reveal more options[/]")
        );
    }

    public static void DisplayMostSearchedDrinks()
    {
        List<DrinkCountDTO> drinksSearchCount = DrinkRepository.GetDrinksSearchCount();
        
        drinksSearchCount.Sort((o1, o2) => o2.count - o1.count);

        Table table = new Table()
            .Title("[bold red]Most searched drinks[/]")
            .AddColumn("[bold violet]Name[/]")
            .AddColumn("[bold darkorange]Count[/]");

        foreach (DrinkCountDTO drinkCountDTO in drinksSearchCount)
        {
            table.AddRow($"[bold violet]{drinkCountDTO.name}[/]", $"[bold darkorange]{drinkCountDTO.count}[/]");
        }
        
        AnsiConsole.Write(table);
    }

    public static void AddFavoriteDrink(Drink drink)
    {
        List<Drink> favoriteDrinks = DrinkRepository.GetFavoriteDrinks();
        
        foreach (Drink favoriteDrink in favoriteDrinks)
        {
            if (favoriteDrink.id == drink.id)
            {
                AnsiConsole.Write(new Markup($"[bold red]{drink.name} already is in favorites[/]\n"));
                return;
            }
        }
        
        DrinkRepository.AddFavoriteDrink(drink);
        
        AnsiConsole.Write(new Markup($"[bold yellow]{drink.name} added to favorites[/]\n"));
    }
}