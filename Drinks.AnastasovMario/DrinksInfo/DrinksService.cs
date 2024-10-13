using DrinksInfo.Models;
using Newtonsoft.Json;
using Spectre.Console;
using System.Net.Http;
using System.Net.Http.Headers;

namespace DrinksInfo
{
  public class DrinksService
  {
    private readonly HttpClient _httpClient;
    private Dictionary<int, string> _categoryTempDb = new Dictionary<int, string>();

    public DrinksService()
    {
      _httpClient = new HttpClient();
      _httpClient.BaseAddress = new Uri("https://thecocktaildb.com/api/json/v1/1/");
      _httpClient.DefaultRequestHeaders.Accept.Clear();
      _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }
    public async Task GetCategories()
    {
      try
      {
        var jsonString
          = await _httpClient.GetStringAsync($"{_httpClient.BaseAddress}list.php?c=list");

        var drinksCategory = JsonConvert.DeserializeObject<Categories>(jsonString);

        if (_categoryTempDb.Count == 0)
        {
          FillCategoryDb(drinksCategory!.CategoriesList);
        }

        UserInterface.ShowCategories(_categoryTempDb);

        var categoryId = AnsiConsole.Ask<int>("Choose a category you want to see: ");

        Console.WriteLine();

        await GetCategory(categoryId);
      }
      catch (Exception ex)
      {
        Helper.ErrorMessage(ex.Message);
        await GetCategories();
      }
    }

    public async Task GetCategory(int categoryId)
    {
      try
      {
        if (categoryId > _categoryTempDb.Count)
        {
          Console.WriteLine("Category with this Id doesn't exist, try again");
          Console.Clear();
          await GetCategories();
        }
        var categoryName = _categoryTempDb[categoryId];

        var jsonString = await _httpClient.GetStringAsync($"{_httpClient.BaseAddress}filter.php?c={categoryName}");

        var drinks = JsonConvert.DeserializeObject<Drinks>(jsonString);

        UserInterface.ShowDrinksByCategory(categoryName, drinks.DrinksList);

        var drinkId = AnsiConsole.Ask<int>("Type the Id of the drink you want to see: ");

        await GetDrink(drinkId);
      }
      catch (Exception ex)
      {
        Helper.ErrorMessage(ex.Message);
        await GetCategories();
      }
    }

    public async Task GetDrink(int drinkId)
    {
      try
      {
        var jsonString = await _httpClient.GetStringAsync($"{_httpClient.BaseAddress}lookup.php?i={drinkId}");

        var drink = JsonConvert.DeserializeObject<DrinksInformation>(jsonString);

        if (drink.ListDrinksInfo == null)
        {
          Console.Clear();
          Console.WriteLine("Drink with this Id doesn't exist");
          await GetCategories();
        }

        UserInterface.ShowDrinkInformation(drink.ListDrinksInfo[0]);

        Helper.ContinueMessage();

        await GetCategories();
      }
      catch (Exception ex)
      {
        Helper.ErrorMessage(ex.Message);
        await GetCategories();
      }
    }

    private void FillCategoryDb(List<Category> categories)
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
