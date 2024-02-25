using Newtonsoft.Json.Linq;
using Spectre.Console;

namespace DrinksConsoleApp;

public class Application
{
    public async Task run()
    {
        Console.WriteLine("Getting the drink categories, please wait a few minutes.");
        var drinkCategories = await GetDrinkCategoriesAsync();
        var id = GetUserInputCateId(drinkCategories);

        var drinks = await GetDrinksAsync(drinkCategories[id - 1].Name);
        var drinkId = GetUserInputDrinkId(drinks);
        var drinkDetail = await GetDrinkDetailAsync(drinks[drinkId - 1].Id);
        DisplayDrinDetail(drinkDetail);
    }

    private int GetUserInputDrinkId(List<Drink> drinks)
    {
        DisplaySpecificCateDrinks(drinks);
        Console.WriteLine();

        return GetValidInputId(drinks.Count);
    }


    private int GetUserInputCateId(List<Category> categories)
    {
        DisplayDrinksMenu(categories);
        Console.WriteLine();

        return GetValidInputId(categories.Count);
    }

    private int GetValidInputId(int count)
    {
        int inputId = AnsiConsole.Ask<int>("Please input the [green]id[/] of the item you wish to see: ");
        while (inputId < 1 || inputId > count)
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

    private void DisplayDrinDetail(DrinkDetail detail)
    {
        Console.Clear();
        var table = new Table();
        table.Title(detail.Name);
        table.AddColumns("Category", "Instruction");
        table.AddRow(detail.Category, detail.Instruction);
        AnsiConsole.Write(table);
    }

    private async Task<List<Category>> GetDrinkCategoriesAsync()
    {
        using (HttpClient client = new())
        {
            var json = await client.GetStringAsync(
                "https://www.thecocktaildb.com/api/json/v1/1/list.php?c=list");
            JObject data = JObject.Parse(json);
            var categories = data["drinks"].ToObject<List<Category>>();
            return categories;
        }
    }

    private async Task<List<Drink>> GetDrinksAsync(string cName)
    {
        using (HttpClient client = new())
        {
            var json = await client.GetStringAsync(
                $"https://www.thecocktaildb.com/api/json/v1/1/filter.php?c={cName}");
            JObject data = JObject.Parse(json);
            var drinks = data["drinks"].ToObject<List<Drink>>();
            return drinks;
        }
    }

    private async Task<DrinkDetail> GetDrinkDetailAsync(int id)
    {
        using (HttpClient client = new())
        {
            var json = await client.GetStringAsync(
                $"https://www.thecocktaildb.com/api/json/v1/1/lookup.php?i={id}");
            JObject data = JObject.Parse(json);
            var drinkDetail = data["drinks"].ToObject<List<DrinkDetail>>()[0];
            return drinkDetail;
        }
    }
}

