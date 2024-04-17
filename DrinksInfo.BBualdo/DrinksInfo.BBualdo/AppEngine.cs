using DrinksInfo.BBualdo.Models;
using Spectre.Console;

namespace DrinksInfo.BBualdo;

public class AppEngine
{
  public bool IsRunning { get; set; }
  public HttpClient Client { get; set; }

  public AppEngine()
  {
    IsRunning = true;
    Client = new HttpClient();
    Client.DefaultRequestHeaders.Clear();
    Client.DefaultRequestHeaders.Add("Accept", "application/json");
  }

  public async Task CategoriesMenu()
  {
    AnsiConsole.Clear();
    ConsoleEngine.ShowTitle();

    List<Category>? categories = await CoctailsHttp.GetCategories(Client);
    if (categories == null || categories.Count == 0)
    {
      PressAnyKey();
      IsRunning = false;
      Environment.Exit(0);
    }

    List<string> choices = new List<string>();

    foreach (Category category in categories)
    {
      choices.Add(category.Name);
    }

    choices.Add("Close App");

    string choosenCategory = ConsoleEngine.GetSelection("[yellow]Select Category[/]", choices);

    if (choosenCategory == "Close App")
    {
      AnsiConsole.Markup("[blue]Have a nice drink![/]");
      IsRunning = false;
      Environment.Exit(0);
    }

    await DrinksMenu(choosenCategory);
  }

  public async Task DrinksMenu(string choosenCategory)
  {
    AnsiConsole.Clear();
    ConsoleEngine.ShowTitle();

    List<Drinks>? drinks = await CoctailsHttp.GetDrinks(Client, choosenCategory);
    if (drinks == null || drinks.Count == 0)
    {
      PressAnyKey();
      return;
    }

    List<string> choices = new List<string>() {
      "Back"
    };

    foreach (Drinks drink in drinks)
    {
      choices.Add(drink.Name);
    }

    string userChoice = ConsoleEngine.GetSelection("[yellow]Select drink to reveal more info[/]", choices);

    if (userChoice == "Back") return;

    string selectedDrinksId = drinks.Where(drink => drink.Name == userChoice).First().Id;

    await ShowDrinkInfo(selectedDrinksId);

    await DrinksMenu(choosenCategory);
  }

  public async Task ShowDrinkInfo(string selectedDrinksId)
  {
    AnsiConsole.Clear();
    ConsoleEngine.ShowTitle();

    Drink? drink = await CoctailsHttp.GetDrink(Client, selectedDrinksId);

    if (drink == null)
    {
      AnsiConsole.Markup("[red]Drink not found[/]\n");
      return;
    }

    ConsoleEngine.ShowDrinkTable(drink);

    PressAnyKey();
    return;
  }

  private void PressAnyKey()
  {
    AnsiConsole.Markup("[blue]Press any key to continue. [/]");
    Console.ReadKey();
  }
}