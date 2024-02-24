using Spectre.Console;
using System.Text.Json;

namespace DrinksConsoleApp;

public class Application
{
    public async Task run()
    {
        Console.WriteLine("Getting the drink categories, please wait a few minutes.");
        var drinkCategories = await GetDrinkCategoriesAsync();
        var id = GetUserInputCateId(drinkCategories);
    }

    private int GetUserInputCateId(Drinks drinkCategories)
    {
        DisplayDrinksMenu(drinkCategories);

        Console.WriteLine();
        int inputId = AnsiConsole.Ask<int>("Please input the [green]id[/] of the item you wish to order: ");
        while (inputId < 1 || inputId > drinkCategories.Categories.Count)
        {
            inputId = AnsiConsole.Ask<int>("Please input the valid ID: ");
        }
        return inputId;
    }

    private void DisplayDrinksMenu(Drinks drinkCategories)
    {
        Console.Clear();
        var table = new Table();
        table.AddColumn("Id");
        table.AddColumn("Drink Name");
        int id = 0;
        drinkCategories.Categories.ForEach(category =>
        {
            table.AddRow((++id).ToString(), category.Name);
        });
        AnsiConsole.Write(table);
    }

    private async Task<Drinks> GetDrinkCategoriesAsync()
    {
        using HttpClient client = new();
        await using Stream stream = await client.GetStreamAsync(
            "https://www.thecocktaildb.com/api/json/v1/1/list.php?c=list");
        return await JsonSerializer.DeserializeAsync<Drinks>(stream);
    }
}

