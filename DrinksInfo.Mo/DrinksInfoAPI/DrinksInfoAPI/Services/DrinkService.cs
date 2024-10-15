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
        return categoryResponse.Drinks;
    }


    public async Task<List<Drink>> GetDrinksByCategoryAsync(string category)
    {
        var response = await _httpClient.GetStringAsync($"https://www.thecocktaildb.com/api/json/v1/1/search.php?s={category}");
        var drinkResponse = JsonSerializer.Deserialize<DrinkResponse>(response);

        if (drinkResponse == null || drinkResponse.Drinks == null || drinkResponse.Drinks.Count == 0)
        {
            return null;
        }

        return drinkResponse.Drinks;
    }

    public async Task<DrinkDetails> GetDrinkDetailsAsync(string drinkId)
    {
        var response = await _httpClient.GetStringAsync($"https://www.thecocktaildb.com/api/json/v1/1/lookup.php?i={drinkId}");
        var drinkResponse = JsonSerializer.Deserialize<DrinkResponse>(response);

        var drink = drinkResponse?.Drinks?.FirstOrDefault();
        if (drink == null)
        {
            return null;
        }

        DrinkDetails drinkDetails = new DrinkDetails
        {
            IdDrink = drink.IdDrink,
            StrDrink = drink.StrDrink,
            StrCategory = drink.StrCategory,
            StrInstructions = drink.StrInstructions,
            StrDrinkThumb = drink.StrDrinkThumb,
            StrIngredient1 = drink.StrIngredient1,
            StrIngredient2 = drink.StrIngredient2,
            StrIngredient3 = drink.StrIngredient3,
            StrIngredient4 = drink.StrIngredient4, 
            StrIngredient5 = drink.StrIngredient5, 
            StrMeasure1 = drink.StrMeasure1,
            StrMeasure2 = drink.StrMeasure2,
            StrMeasure3 = drink.StrMeasure3,
            StrMeasure4 = drink.StrMeasure4, 
            StrMeasure5 = drink.StrMeasure5, 
        };

        return drinkDetails;
    }




}
