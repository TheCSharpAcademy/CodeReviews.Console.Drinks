using Drinks.kwm0304.Models;
using Drinks.kwm0304.Services;
using Drinks.kwm0304.Views;
using Spectre.Console;

namespace Drinks.kwm0304;

public class SessionLoop
{
  private readonly HttpClient _http;
  private readonly DrinkCategorySelection _selection;
  private readonly ExternalService _service;

  public SessionLoop(HttpClient http)
  {
    _selection = new DrinkCategorySelection();
    _http = http;
    _service = new(_http);
  }

  public async Task OnStart()
  {
    Console.Clear();
    List<DrinkCategory> categories = await GetCategories() ?? [];
    DrinkCategory selectedCategory = DrinkCategorySelection.SelectDrinkCategory(categories);
    string catString = selectedCategory.ToString();
    List<Drink> drinks = await GetDrinks(catString) ?? [];
    string selectedDrinkId = DrinkCategorySelection.SelectDrinkFromCategory(drinks);
    List<DrinkDetail> details = await GetDrinkDetails(selectedDrinkId) ?? [];
    DrinkTable.DisplayDrink(details[0]);
  }

  private async Task<List<DrinkDetail>?> GetDrinkDetails(string idStr)
  {
    return await _service.GetExternalContent<DrinkDetail>("drinkById", idStr) ?? [];
  }

  private async Task<List<DrinkCategory>?> GetCategories()
  {
    return await _service.GetExternalContent<DrinkCategory>("categories");
  }

  public async Task<List<Drink>> GetDrinks(string category)
  {
    return await _service.GetExternalContent<Drink>("drinksInCategory", category) ?? [];
  }
}
