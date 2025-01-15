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
    private readonly Dictionary<int, string> _categoryCache = new Dictionary<int, string>();

    public DrinksService(HttpClient httpClient)
    {
      _httpClient = httpClient;
      _httpClient.BaseAddress = new Uri("https://thecocktaildb.com/api/json/v1/1/");
      _httpClient.DefaultRequestHeaders.Accept.Clear();
      _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }

    public async Task RunAsync()
    {
      while (true)
      {
        await ShowMainMenuAsync();
      }
    }

    private async Task ShowMainMenuAsync()
    {
      Console.Clear();
      var choice = AnsiConsole.Prompt(
          new SelectionPrompt<string>()
              .Title("Welcome to the Drinks Info App!")
              .PageSize(10)
              .AddChoices(new[] {
                        "Browse Categories",
                        "Search for a Drink",
                        "Exit"
              }));

      switch (choice)
      {
        case "Browse Categories":
          await GetCategoriesAsync();
          break;
        case "Search for a Drink":
          await SearchDrinkAsync();
          break;
        case "Exit":
          Console.Clear();
          Console.WriteLine("Goodbye!");
          Environment.Exit(0);
          break;
      }
    }

    private async Task GetCategoriesAsync()
    {
      try
      {
        if (_categoryCache.Count == 0)
        {
          var jsonString = await _httpClient.GetStringAsync("list.php?c=list");
          var drinksCategory = JsonConvert.DeserializeObject<Categories>(jsonString);
          FillCategoryCache(drinksCategory!.CategoriesList);
        }

        UserInterface.ShowCategories(_categoryCache);
        var categoryId = AnsiConsole.Prompt(
            new TextPrompt<int>("Choose a category you want to see:")
                .Validate(id =>
                    _categoryCache.ContainsKey(id)
                        ? ValidationResult.Success()
                        : ValidationResult.Error("Invalid category ID. Please try again.")));

        await GetCategoryAsync(categoryId);
      }
      catch (Exception ex)
      {
        Helper.HandleException(ex);
      }
    }

    private async Task GetCategoryAsync(int categoryId)
    {
      try
      {
        var categoryName = _categoryCache[categoryId];
        var jsonString = await _httpClient.GetStringAsync($"filter.php?c={Uri.EscapeDataString(categoryName)}");
        var drinks = JsonConvert.DeserializeObject<Drinks>(jsonString);

        UserInterface.ShowDrinksByCategory(categoryName, drinks.DrinksList);
        var drinkId = AnsiConsole.Prompt(
            new TextPrompt<int>("Type the ID of the drink you want to see:")
                .Validate(id =>
                    drinks.DrinksList.Any(d => d.DrinkId == id)
                        ? ValidationResult.Success()
                        : ValidationResult.Error("Invalid drink ID. Please try again.")));

        await GetDrinkAsync(drinkId);
      }
      catch (Exception ex)
      {
        Helper.HandleException(ex);
      }
    }

    private async Task GetDrinkAsync(int drinkId)
    {
      try
      {
        var jsonString = await _httpClient.GetStringAsync($"lookup.php?i={drinkId}");
        var drink = JsonConvert.DeserializeObject<DrinksInformation>(jsonString);

        if (drink?.ListDrinksInfo?.FirstOrDefault() is DrinkInfo drinkInfo)
        {
          UserInterface.ShowDrinkInformation(drinkInfo);
        }
        else
        {
          AnsiConsole.MarkupLine("[red]Drink not found.[/]");
        }

        Helper.ContinueMessage();
      }
      catch (Exception ex)
      {
        Helper.HandleException(ex);
      }
    }

    private async Task SearchDrinkAsync()
    {
      var searchTerm = AnsiConsole.Ask<string>("Enter the name of the drink you want to search for:");
      try
      {
        var jsonString = await _httpClient.GetStringAsync($"search.php?s={Uri.EscapeDataString(searchTerm)}");
        var searchResults = JsonConvert.DeserializeObject<DrinksInformation>(jsonString);

        if (searchResults?.ListDrinksInfo?.Any() == true)
        {
          UserInterface.ShowSearchResults(searchResults.ListDrinksInfo);
          var drinkId = AnsiConsole.Prompt(
              new TextPrompt<int>("Type the ID of the drink you want to see:")
                  .Validate(id =>
                      searchResults.ListDrinksInfo.Any(d => d.DrinkId == id.ToString())
                          ? ValidationResult.Success()
                          : ValidationResult.Error("Invalid drink ID. Please try again.")));

          await GetDrinkAsync(drinkId);
        }
        else
        {
          AnsiConsole.MarkupLine("[yellow]No drinks found matching your search term.[/]");
          Helper.ContinueMessage();
        }
      }
      catch (Exception ex)
      {
        Helper.HandleException(ex);
      }
    }

    private void FillCategoryCache(List<Category> categories)
    {
      int id = 1;
      foreach (var category in categories)
      {
        _categoryCache.Add(id++, category.Name);
      }
    }
  }
}