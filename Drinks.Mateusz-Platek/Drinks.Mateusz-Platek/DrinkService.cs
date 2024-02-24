using System.Net;
using Drinks.Mateusz_Platek.Models;
using Newtonsoft.Json;
using RestSharp;

namespace Drinks.Mateusz_Platek;

public static class DrinkService
{
    public static async Task<List<Category>?> GetCategories()
    {
        RestClient restClient = new RestClient("https://www.thecocktaildb.com/api/json/v1/1/");
        RestRequest restRequest = new RestRequest("list.php?c=list");
        RestResponse response = await restClient.ExecuteAsync(restRequest);

        if (response.StatusCode != HttpStatusCode.OK)
        {
            return null;
        }

        if (response.Content == null)
        {
            return null;
        }
        
        Categories? categories = JsonConvert.DeserializeObject<Categories>(response.Content);
        if (categories == null)
        {
            return null;
        }
        
        return categories.list;
    }

    public static async Task<List<Drink>?> GetDrinksByCategory(Category category)
    {
        RestClient restClient = new RestClient("https://www.thecocktaildb.com/api/json/v1/1/");
        RestRequest restRequest = new RestRequest($"filter.php?c={category.name}");
        RestResponse response = await restClient.ExecuteAsync(restRequest);
        
        if (response.StatusCode != HttpStatusCode.OK)
        {
            return null;
        }

        if (response.Content == null)
        {
            return null;
        }

        Drinks.Mateusz_Platek.Models.Drinks? drinks = JsonConvert.DeserializeObject<Drinks.Mateusz_Platek.Models.Drinks>(response.Content);
        if (drinks == null)
        {
            return null;
        }

        return drinks.list;
    }

    public static async Task<List<DrinkDetails>?> GetDrinkDetails(Drink drink)
    {
        RestClient restClient = new RestClient("https://www.thecocktaildb.com/api/json/v1/1/");
        RestRequest restRequest = new RestRequest($"lookup.php?i={drink.id}");
        RestResponse response = await restClient.ExecuteAsync(restRequest);
        
        if (response.StatusCode != HttpStatusCode.OK)
        {
            return null;
        }
        
        if (response.Content == null)
        {
            return null;
        }

        DrinkDetailsObject? drinkDetailsObject = JsonConvert.DeserializeObject<DrinkDetailsObject>(response.Content);
        if (drinkDetailsObject == null)
        {
            return null;
        }
        
        return drinkDetailsObject.list;
    }
}