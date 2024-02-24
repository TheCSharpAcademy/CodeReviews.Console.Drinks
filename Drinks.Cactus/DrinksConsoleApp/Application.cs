using Spectre.Console;
using System.Text.Json;

namespace DrinksConsoleApp;

public class Application
{
    public async Task run()
    {
        Console.WriteLine("Getting the drink categories, please wait a few minutes.");
        var drinkCategories = await GetDrinkCategoriesAsync();
        var id = GetUserInputCateId(drinkCategories.Categories);

        var drinks = await GetDrinksAsync(drinkCategories.Categories[id - 1].Name);
        var drinkId = GetUserInputDrinkId(drinks.DrinkDetails);
    }

    private int GetUserInputDrinkId(List<Drink> drinks)
    {
        DisplaySpecificCateDrinks(drinks);

        Console.WriteLine();
        int inputId = AnsiConsole.Ask<int>("Please input the [green]id[/] of the drink you wish to see: ");
        while (inputId < 1 || inputId > drinks.Count)
        {
            inputId = AnsiConsole.Ask<int>("Please input the valid ID: ");
        }
        return inputId;
    }


    private int GetUserInputCateId(List<Category> categories)
    {
        DisplayDrinksMenu(categories);

        Console.WriteLine();
        int inputId = AnsiConsole.Ask<int>("Please input the [green]id[/] of the category you wish to see: ");
        while (inputId < 1 || inputId > categories.Count)
        {
            inputId = AnsiConsole.Ask<int>("Please input the valid ID: ");
        }
        return inputId;
    }

    private void DisplaySpecificCateDrinks(List<Drink> drinks)
    {
        Console.Clear();

        var table = new Table();
        table.AddColumn("Id");
        table.AddColumn("Drink Name");
        int id = 0;
        drinks.ForEach(drink =>
        {
            table.AddRow((++id).ToString(), drink.Name);
        });
        AnsiConsole.Write(table);
    }

    private void DisplayDrinksMenu(List<Category> drinkCategories)
    {
        Console.Clear();
        var table = new Table();
        table.AddColumn("Id");
        table.AddColumn("Categoroy Name");
        int id = 0;
        drinkCategories.ForEach(category =>
        {
            table.AddRow((++id).ToString(), category.Name);
        });
        AnsiConsole.Write(table);
    }

    private async Task<DrinkCategories> GetDrinkCategoriesAsync()
    {
        using (HttpClient client = new())
        {
            await using Stream stream = await client.GetStreamAsync(
                "https://www.thecocktaildb.com/api/json/v1/1/list.php?c=list");
            return await JsonSerializer.DeserializeAsync<DrinkCategories>(stream);
        }
    }

    private async Task<Drinks> GetDrinksAsync(string cName)
    {
        using (HttpClient client = new())
        {
            await using Stream stream = await client.GetStreamAsync(
                $"https://www.thecocktaildb.com/api/json/v1/1/filter.php?c={cName}");
            return await JsonSerializer.DeserializeAsync<Drinks>(stream);
        }
    }
}

