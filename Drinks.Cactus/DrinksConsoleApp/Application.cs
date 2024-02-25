using Newtonsoft.Json.Linq;
using Spectre.Console;

namespace DrinksConsoleApp;

public class Application
{
    public async Task Run()
    {
        await RunDrinkCategoryMenu();
    }

    public async Task RunDrinkCategoryMenu()
    {
        Console.WriteLine("Getting the drink categories, please wait a few minutes.");
        var drinkCategories = await GetDrinkCategoriesAsync();
        var id = GetUserInputCateId(drinkCategories);
        while (id >= 0)
        {
            await RunSpecificCateDrinksMenu(drinkCategories[id].Name);
            id = GetUserInputCateId(drinkCategories);
        }
    }

    public async Task RunSpecificCateDrinksMenu(string cateName)
    {
        var drinks = await GetDrinksAsync(cateName);
        while (true)
        {
            var drinkId = GetUserInputDrinkId(drinks, cateName);
            if (drinkId == -1) return;

            Console.WriteLine($"Fetch the data detail of {drinks[drinkId].Name} drink, please wait a few miniutes.");
            var drinkDetail = await GetDrinkDetailAsync(drinks[drinkId - 1].Id);
            DisplayDrinDetail(drinkDetail);

            Console.WriteLine($"Type any key to return the first page of the category {cateName.ToUpper()}.");
            Console.ReadLine();
        }
    }

    private int GetUserInputDrinkId(List<Drink> drinks, string cateName)
    {
        int pageLimit = 15;
        int pageCnt = (int)Math.Ceiling(drinks.Count / (double)pageLimit);
        int pageIdx = 0;
        DisplaySpecificCateDrinks(drinks, pageIdx, pageLimit, cateName);
        Console.WriteLine();

        while (true)
        {
            string nextPagePromStr = pageIdx + 1 < pageCnt ? "Next Page: n/N, " : "";
            string lastPagePromStr = pageIdx - 1 >= 0 ? "Last Page: l/L, " : "";
            Console.WriteLine($"{lastPagePromStr}{nextPagePromStr}See All Categories: b/B or Input the ID you wish to see.");
            Console.WriteLine();

            string? op = Console.ReadLine();
            switch (op)
            {
                case "n":
                case "N":
                    if (pageIdx + 1 >= pageCnt)
                    {
                        Console.WriteLine("INVALID input.");
                        break;
                    }
                    DisplaySpecificCateDrinks(drinks, ++pageIdx, pageLimit, cateName);
                    break;
                case "l":
                case "L":
                    if (pageIdx - 1 < 0)
                    {
                        Console.WriteLine("INVALID input.");
                        break;
                    }
                    DisplaySpecificCateDrinks(drinks, --pageIdx, pageLimit, cateName);
                    break;
                case "b":
                case "B":
                    return -1;
                default:
                    int inputId;
                    int start = pageIdx * pageLimit;
                    int end = Math.Min((pageIdx + 1) * pageLimit, drinks.Count) - 1;
                    if (int.TryParse(op, out inputId) && inputId >= start && inputId <= end)
                    {
                        return inputId;
                    }
                    Console.WriteLine("INVALID input.");
                    break;
            }
        }
    }

    private int GetUserInputCateId(List<Category> categories)
    {
        DisplayDrinksMenu(categories);
        Console.WriteLine();

        int inputId = AnsiConsole.Ask<int>("Please input the [green]id[/] of the category you wish to see, or -1 to exit: ");
        while (inputId < -1 || inputId >= categories.Count)
        {
            inputId = AnsiConsole.Ask<int>("Please input the valid ID: ");
        }
        return inputId;
    }

    private void DisplaySpecificCateDrinks(List<Drink> drinks, int page, int pageLimit, string cateName)
    {
        Console.Clear();

        var table = new Table();
        table.Title($"{cateName} drinks PAGE {page}");
        table.AddColumn("Id");
        table.AddColumn("Drink Name");
        int id = page * pageLimit; // page index starts from 0
        int cnt = Math.Min(pageLimit, drinks.Count - id);
        drinks.GetRange(id, cnt)
            .ForEach(drink =>
            {
                table.AddRow((id++).ToString(), drink.Name);
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
            table.AddRow((id++).ToString(), category.Name);
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

