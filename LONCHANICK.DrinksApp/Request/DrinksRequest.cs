using LONCHANICK.DrinksApp.Models;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace LONCHANICK.DrinksApp.Request;

public static class DrinksRequest
{
    static public async Task<ListOfDrinkCategories> GetDrinkCategories()
    {
        string drinkCategoriesUrl = "https://www.thecocktaildb.com/api/json/v1/1/list.php?c=list";
        
        using HttpClient client = new HttpClient();

        using var drinkCategoriesStream = await client.GetStreamAsync(drinkCategoriesUrl);
        
        var drinkCategories = await JsonSerializer
            .DeserializeAsync<ListOfDrinkCategories>(drinkCategoriesStream);

        return drinkCategories;
    }

    public static async Task<Drinks> GetDrinksByCategory(string category)
    {
        string drinkCategoryUrl =
            "https://www.thecocktaildb.com/api/json/v1/1/filter.php?c=" + category;

        using HttpClient client = new HttpClient();

        using var steamDrinksByCategory = await client.GetStreamAsync(drinkCategoryUrl);

        Drinks drinkByCategories = new();
        drinkByCategories = await JsonSerializer
            .DeserializeAsync<Drinks>(steamDrinksByCategory);

        return drinkByCategories;
    }

}
