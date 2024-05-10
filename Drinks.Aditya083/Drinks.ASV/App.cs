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
                Console.Write("Input valid integer drink id:");
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
        Console.WriteLine(json);
        Console.ReadLine();
    }
}


//deserializattion data required 

//when invalid id specified 
//{
//    "drinks": null
//}

//"strDrink": "3 Wise Men",
//"strAlcoholic": "Non alcoholic",
// "strGlass": "Coffee mug",
//"strInstructions": "Mix together until coffe...",
//"strIngredient1": "Coffee",
//            "strIngredient2": "Sugar",
//            "strIngredient3": "Water",
//            "strIngredient4": "Milk",
//            "strIngredient5": null,
//            "strIngredient6": null,
//            "strIngredient7": null,
//            "strIngredient8": null,
//            "strIngredient9": null,
//            "strIngredient10": null,
//            "strIngredient11": null,
//            "strIngredient12": null,
//            "strIngredient13": null,
//            "strIngredient14": null,
//            "strIngredient15": null,
//            "strMeasure1": "1/4 cup instant ",
//            "strMeasure2": "1/4 cup ",
//            "strMeasure3": "1/4 cup hot ",
//            "strMeasure4": "4 cups cold ",
//            "strMeasure5": null,
//            "strMeasure6": null,
//            "strMeasure7": null,
//            "strMeasure8": null,
//            "strMeasure9": null,
//            "strMeasure10": null,
//            "strMeasure11": null,
//            "strMeasure12": null,
//            "strMeasure13": null,
//            "strMeasure14": null,
//            "strMeasure15": null,