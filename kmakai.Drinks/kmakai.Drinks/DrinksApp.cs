using kmakai.Drinks.Models;
using kmakai.Drinks.TableVisual;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace kmakai.Drinks;

public class DrinksApp
{
    private HttpClient Client = new();
    private List<Category> Categories = new();
    private List<Drink> Drinks = new();
    public bool isRunning = true;

    public DrinksApp()
    {
        Client.DefaultRequestHeaders.Accept.Clear();
        Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        Client.DefaultRequestHeaders.Add("User-Agent", "C# App");
    }

    public void Run()
    {
        while (isRunning)
        {
            Task.Run(async () => Categories = await GetCategoriesAsync()).Wait();
            TableEngine.PrintTable(Categories, "Categories");
            string categoryInput = InputAndValidation.GetCategoryInput();
            while(Categories.Find(c => c.Name.ToLower() == categoryInput.ToLower()) == null && categoryInput != "x")
            {
                Console.WriteLine("Please enter a valid category name or x to exit: ");
                categoryInput = Console.ReadLine();
            }

            if(categoryInput == "x")
            {
                isRunning = false;
                break;
            }

            Task.Run(async () => Drinks = await GetDrinksByCategory(categoryInput)).Wait();
            Console.Clear();
            TableEngine.PrintTable(Drinks, "Drinks");
            string drinkInput = InputAndValidation.GetDrinkInput();

            while(Drinks.Find(d => d.IdDrink == drinkInput) == null && drinkInput != "x")
            {
                Console.WriteLine("Please enter a valid drink Id or x to return: ");
                drinkInput = Console.ReadLine();
            }

            if(drinkInput == "x")
            {
               continue;
            }

            Console.Clear();
            Task.Run(async () => await GetDrinkDetail(drinkInput)).Wait();
            isRunning = InputAndValidation.GetContinue();
        }
    }

    public async Task<List<Category>> GetCategoriesAsync()
    {
        var response = await Client.GetStringAsync("https://www.thecocktaildb.com/api/json/v1/1/list.php?c=list");
        var categories = JsonConvert.DeserializeObject<DrinksCategoryList>(response);
        return categories.Categories;
    }

    public async Task<List<Drink>> GetDrinksByCategory(string category)
    {
        var response = await Client.GetStringAsync($"https://www.thecocktaildb.com/api/json/v1/1/filter.php?c={category}");
        var drinks = JsonConvert.DeserializeObject<DrinksList>(response)?.Drinks;
        return drinks;
    }

    public async Task GetDrinkDetail(string drinkId)
    {
        var response = await Client.GetStringAsync($"https://www.thecocktaildb.com/api/json/v1/1/lookup.php?i={drinkId}");
        var detailList = JsonConvert.DeserializeObject<DrinkDetailObject>(response)?.DrinkDetailList;
        DrinkDetail drinkDetailUnformatted = detailList[0];

        var drinkDetail = Helpers.FormatDrinkDetails(drinkDetailUnformatted);

        TableEngine.PrintTable(drinkDetail, "Drink Details");
    }


}






