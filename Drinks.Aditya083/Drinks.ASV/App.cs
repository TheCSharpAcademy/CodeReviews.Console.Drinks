using System.Net.Http.Headers;
using System.Text.Json;
using Drinks.ASV.View;
using Drinks.ASV.Model;
using Drinks.ASV.Helper;

namespace Drinks.ASV.RestaurantDrinkMenu;

internal class App
{
    public async Task InitializeClientAsync()
    {
        using var client = new HttpClient();
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        await GetCategoriesAsync(client);
    }

    private async Task GetCategoriesAsync(HttpClient client)
    {
        string json = await client.GetStringAsync("https://www.thecocktaildb.com/api/json/v1/1/list.php?c=list");
        DrinkCategoriesList? drinksCategories = JsonSerializer.Deserialize<DrinkCategoriesList>(json);
        string categorySelected = Display.GetSelection("Please select a Category to choose a drink from", drinksCategories);
        while(categorySelected!= "Exit Application")
        {
            await GetDrinksFromCategorySelectedAsync(client, categorySelected);
            Console.Clear();
            categorySelected = Display.GetSelection("Please select a Category to choose a drink from", drinksCategories);
        }
    }

    private async Task GetDrinksFromCategorySelectedAsync(HttpClient client, string categorySelected)
    {
        string json = await client.GetStringAsync($"https://www.thecocktaildb.com/api/json/v1/1/filter.php?c={categorySelected}");
        SelectedDrinkCategoryDrinks? drinks = JsonSerializer.Deserialize<SelectedDrinkCategoryDrinks>(json);
        Display.ShowDrinks("Following drinks are present for the given category. Please enter a valid DrinkId to view more info about the drink. Press -1 to exit", new string[] { "DrinkId", "DrinkName"}, drinks);
        string drinkId;
        do{
            do
            {
                Console.Write("Input valid drink id or -1 to exit:");
                drinkId = Console.ReadLine();
            } while (!Validation.IsGivenInputInteger(drinkId));
            if (drinkId != "-1")
            {
                await GetDrinkDetailsAsync(client, drinkId);
                Console.Clear();
                Display.ShowDrinks("Following drinks are present for the given category. Please enter a valid DrinkId to view more info about the drink. Press -1 to exit", new string[] { "DrinkId", "DrinkName" }, drinks);
            }
        } while (drinkId != "-1");
    }

    private async Task GetDrinkDetailsAsync(HttpClient client, string drinkId)
    {
        Console.Clear();
        Console.WriteLine("--------------Drink Information---------------");
        string json = await client.GetStringAsync($"https://www.thecocktaildb.com/api/json/v1/1/lookup.php?i={drinkId}");
        if(json== "{\"drinks\":null}")
        {
            Console.WriteLine("Invalid DrinkId was specified. Pls enter valid DrinkId. Press any key to continue...");
            Console.ReadLine();
        }
        else
        {
            DrinkDetails ?drink = JsonSerializer.Deserialize<DrinkDetails>(json);
            Display.ShowDrinkDetails("Drink Details", drink);
            Console.ReadLine();
        }
        
    }
}