using DrinksInfo.Models;
using Newtonsoft.Json;
using Spectre.Console;

namespace DrinksInfo
{
  public class DrinksApiClient(HttpClient httpClient)
  {
    private Dictionary<int, string> _categoryTempDb = new Dictionary<int, string>();
    public async Task GetCategories()
    {
      var jsonString
        = await httpClient.GetStringAsync($"{httpClient.BaseAddress}list.php?c=list");
      var drinksCategory = JsonConvert.DeserializeObject<Categories>(jsonString);
      if (_categoryTempDb.Count == 0)
      {
        FillCategoryDb(drinksCategory!.CategoriesList);
      }
      UserInterface.ShowCategories(_categoryTempDb);

      var categoryId = AnsiConsole.Ask<int>("Choose a category you want to see");

      Console.WriteLine();

      await GetCategory(categoryId);
    }

    public async Task GetCategory(int categoryId)
    {
      var categoryName = _categoryTempDb[categoryId];
      var jsonString = await httpClient.GetStringAsync($"{httpClient.BaseAddress}filter.php?c={categoryName}");

      var drinks = JsonConvert.DeserializeObject<Drinks>(jsonString);

      UserInterface.ShowDrinksByCategory(categoryName, drinks.DrinksList);

      var drinkId = AnsiConsole.Ask<int>("Type the Id of the drink you want to see");

      await GetDrink(drinkId);
    }

    public async Task GetDrink(int drinkId)
    {
      var jsonString = await httpClient.GetStringAsync($"{httpClient.BaseAddress}lookup.php?i={drinkId}");

      var drink = JsonConvert.DeserializeObject<DrinksInformation>(jsonString);

      UserInterface.ShowDrinkInformation(drink!.ListDrinksInfo[0]);

      await GetCategories();
    }

    public void FillCategoryDb(List<Category> categories)
    {
      int id = 1;
      foreach (var category in categories)
      {
        _categoryTempDb.Add(id, category.Name);

        id++;
      }
    }
  }
}
