using System.Text.Json;
using Drinks.TwilightSaw.Model.Response;

namespace Drinks.TwilightSaw.Controller;

public class DrinksController(HttpClient client)
{
    public async Task<List<Model.DrinksType>> GetDrinkTypeList()
    {
        var url = $"https://www.thecocktaildb.com/api/json/v1/1/list.php?c=list";
     
        return await FetchDrinkData<Model.DrinksType, DrinksTypeResponse>(url, response => response.drinks);
    }

    public async Task<List<Model.DrinksShort>> GetDrinkList(string type)
    {
        var url = $"https://www.thecocktaildb.com/api/json/v1/1/filter.php?c={type}";

        return await FetchDrinkData<Model.DrinksShort, DrinksShortResponse>(url, response => response.drinks);
    }

    public async Task<List<Model.DrinksFull>> GetDrinkFullList(string drink)
    {
        var url = $"https://www.thecocktaildb.com/api/json/v1/1/search.php?s={drink}";
       
        return await FetchDrinkData<Model.DrinksFull, DrinksFullResponse>(url, response => response.drinks);
    }
    public async Task<List<Model.DrinksFull>> GetDrinkFullListId(string idDrink)
    {
        var url = $"https://www.thecocktaildb.com/api/json/v1/1/lookup.php?i={idDrink}";

        return await FetchDrinkData<Model.DrinksFull, DrinksFullResponse>(url,
            response => response.drinks);
    }

    public async Task<List<T>> FetchDrinkData<T, TResponse>(string url, Func<TResponse, List<T>> getDrinks)
    {
        var response = await client.GetAsync(url);

        if (!response.IsSuccessStatusCode)
            throw new HttpRequestException("Error: " + response.StatusCode);

        var content = await response.Content.ReadAsStringAsync();

        var result = JsonSerializer.Deserialize<TResponse>(content);

        return getDrinks(result);
    }
}