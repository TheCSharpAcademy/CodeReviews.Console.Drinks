using DrinksInfo.BBualdo.Models;
using Spectre.Console;
using System.Text.Json;

namespace DrinksInfo.BBualdo;

public class CoctailsHttp
{
  public static async Task<List<Category>?> GetCategories(HttpClient client)
  {
    List<Category> categories;

    Stream stream = await client.GetStreamAsync("https://www.thecocktaildb.com/api/json/v1/1/list.php?c=list");
    CategoriesResponse? response = await JsonSerializer.DeserializeAsync<CategoriesResponse>(stream);
    if (response == null)
    {
      AnsiConsole.Markup("[red]Couldn't establish connection to CoctailDB server.[/]");
      return null;
    }

    categories = response.Categories;
    return categories;
  }

  public static async Task<List<Drinks>?> GetDrinks(HttpClient client, string categoryName)
  {
    List<Drinks> drinks;

    Stream stream = await client.GetStreamAsync($"https://www.thecocktaildb.com/api/json/v1/1/filter.php?c={categoryName.Trim()}");
    DrinksResponse? response = await JsonSerializer.DeserializeAsync<DrinksResponse>(stream);
    if (response == null)
    {
      AnsiConsole.Markup("[red]Couldn't establish connection to CoctailDB server.[/]");
      return null;
    }

    drinks = response.Drinks;
    return drinks;
  }

  public static async Task<Drink?> GetDrink(HttpClient client, string drinkId)
  {
    List<Drink>? drinks;
    Stream stream = await client.GetStreamAsync($"https://www.thecocktaildb.com/api/json/v1/1/lookup.php?i={drinkId}");
    DrinkResponse? response = await JsonSerializer.DeserializeAsync<DrinkResponse>(stream);

    if (response == null)
    {
      AnsiConsole.Markup("[red]Couldn't establish connection to CoctailDB server.[/]");
      return null;
    }
    drinks = response.Drinks;

    return drinks.First();
  }
}