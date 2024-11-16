using System.Collections;
using System.Text.Json;
using Drinks.TwilightSaw.Model.Response;

namespace Drinks.TwilightSaw.Controller;

public class DrinksController(HttpClient client)
{
    public async Task<List<Model.DrinksType>> GetDrinkTypeList()
    {
        var response = await client.GetAsync(
            "https://www.thecocktaildb.com/api/json/v1/1/list.php?c=list");
        if (!response.IsSuccessStatusCode) throw new HttpRequestException("Error");

        var content = await response.Content.ReadAsStringAsync();
        var drinksTypes = JsonSerializer.Deserialize<DrinksTypeResponse>(content).drinks;
        return drinksTypes;
    }

    public async Task<List<Model.DrinksShort>> GetDrinkList(string type)
    {
        var response = await client.GetAsync(
            $"https://www.thecocktaildb.com/api/json/v1/1/filter.php?c={type}");
        if (!response.IsSuccessStatusCode) throw new HttpRequestException("Error");

        var content = await response.Content.ReadAsStringAsync();
        var drinksShorts = JsonSerializer.Deserialize<DrinksShortResponse>(content).drinks;
        return drinksShorts;
    }

    public async Task<List<Model.DrinksFull>> GetDrinkFullList(string drink)
    {
        var response = await client.GetAsync(
            $"https://www.thecocktaildb.com/api/json/v1/1/search.php?s={drink}");
        if (!response.IsSuccessStatusCode) throw new HttpRequestException("Error");

        var content = await response.Content.ReadAsStringAsync();
        var drinksFull = JsonSerializer.Deserialize<DrinksFullResponse>(content).drinks;
        return drinksFull;
    }
    //IEnumerable?
    public async Task<List<Model.DrinksFull>> GetDrinkFullListId(string idDrink)
    {

        var response = await client.GetAsync(
            $"https://www.thecocktaildb.com/api/json/v1/1/lookup.php?i={idDrink}");
        if (!response.IsSuccessStatusCode) throw new HttpRequestException("Error");

        var content = await response.Content.ReadAsStringAsync();
        var drinksFull = JsonSerializer.Deserialize<DrinksFullResponse>(content).drinks;
        return drinksFull;
    }
}