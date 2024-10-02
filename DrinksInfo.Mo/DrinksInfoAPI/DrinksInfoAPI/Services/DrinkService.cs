using System.Net.Http;
using System.Text.Json;

public class DrinkService
{
    private readonly HttpClient _httpClient;

    public DrinkService()
    {
        _httpClient = new HttpClient();
    }

    public async Task<List<DrinkCategory>> GetCategoriesAsync()
    {
        var response = await _httpClient.GetStringAsync("https://www.thecocktaildb.com/api/json/v1/1/list.php?c=list");
        var categoryResponse = JsonSerializer.Deserialize<DrinkCategoryResponse>(response);
        return categoryResponse.drinks;
    }


    public async Task<List<Drink>> GetDrinksByCategoryAsync(string category)
    {
        var response = await _httpClient.GetStringAsync($"https://www.thecocktaildb.com/api/json/v1/1/search.php?s={category}");
        var drinkResponse = JsonSerializer.Deserialize<DrinkResponse>(response);

        if (drinkResponse == null || drinkResponse.drinks == null || drinkResponse.drinks.Count == 0)
        {
            return null;
        }

        return drinkResponse.drinks;
    }

    public async Task<DrinkDetails> GetDrinkDetailsAsync(string drinkId)
    {
        var response = await _httpClient.GetStringAsync($"https://www.thecocktaildb.com/api/json/v1/1/lookup.php?i={drinkId}");
        var drinkResponse = JsonSerializer.Deserialize<DrinkResponse>(response);

        var drink = drinkResponse.drinks.FirstOrDefault();
        if (drink == null)
        {
            return null;
        }

       DrinkDetails drinkDetails = new DrinkDetails
        {
            idDrink = drink.idDrink,
            strDrink = drink.strDrink,
            strCategory = drink.strCategory,
            strInstructions = drink.strInstructions,
            strDrinkThumb = drink.strDrinkThumb,
            strIngredient1 = drink.strIngredient1,
            strIngredient2 = drink.strIngredient2,
            strIngredient3 = drink.strIngredient3
        };

        return drinkDetails;
    }



}
