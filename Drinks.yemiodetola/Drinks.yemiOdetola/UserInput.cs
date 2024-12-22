using Drinks.yemiOdetola.Models;
using Spectre.Console;

namespace Drinks.yemiOdetola;

public class UserInput
{
  private readonly DrinkService drinkService;
  private readonly Visualization visualization;
  private readonly Helper helper;

  public UserInput(DrinkService drinkService, Visualization visualization, Helper helper)
  {
    this.drinkService = drinkService;
    this.visualization = visualization;
    this.helper = helper;
  }

  public async Task MenuHandler()
  {
    AnsiConsole.Clear();

    string choice = AnsiConsole.Prompt(
      new SelectionPrompt<string>()
      .Title("Select an option using the arrow keys, then press enter...")
      .PageSize(30)
      .AddChoices(new string[] { "Drinks Search", "Show a random drink!", "Exit" }));

    switch (choice)
    {
      case "Drinks Search":
        await GetCategoriesInput();
        break;
      case "Show a random drink!":
        await GetRandomDrink();
        break;
      case "Exit":
        Environment.Exit(0);
        break;
    }
  }

  public async Task GetCategoriesInput()
  {
    AnsiConsole.Clear();
    List<Category> categories = await drinkService.GetCategories();

    if (categories == null || !categories.Any())
    {
      AnsiConsole.Markup($"[red]Try again later, an error occurred. Press enter to return to main menu...[/]");
      Console.ReadLine();
      await MenuHandler();
      return;
    }

    visualization.PrintTable(categories);

    string? category = AnsiConsole.Ask<string>("Enter category: ");

    while (!helper.IsStringValid(category) || !categories.Any(c => c.StrCategory.ToLower() == category.ToLower()))
    {
      AnsiConsole.MarkupLine($"[red]{category} is not a valid category![/]");
      category = AnsiConsole.Ask<string>("Enter a valid category: ");
    }

    await GetDrinksInput(category);
  }

  public async Task GetDrinksInput(string category)
  {
    AnsiConsole.Clear();
    List<Drink> drinks = await drinkService.GetDrinksByCategory(category);

    if (drinks == null || !drinks.Any())
    {
      AnsiConsole.Markup($"[red]Please try again, an error occurred. Press enter to return to main menu...[/]");
      Console.ReadLine();
      await MenuHandler();
      return;
    }

    visualization.PrintDrinks(drinks);

    string? drinkSelection = AnsiConsole.Ask<string>("Enter Drink Id: ");

    while (!helper.IsIdValid(drinkSelection) || !drinks.Any(c => c.IdDrink.ToLower() == drinkSelection.ToLower()))
    {
      AnsiConsole.MarkupLine($"[red]{drinkSelection} is not a valid drink![/]");
      drinkSelection = AnsiConsole.Ask<string>("Enter a valid drink Id: ");
    }

    AnsiConsole.Clear();

    var drinkDetail = await drinkService.GetDrinkById(drinkSelection);

    if (drinkDetail == null)
    {
      AnsiConsole.Markup($"[red]An error occurred. Press enter to return to main menu...[/]");
      Console.ReadLine();
      await MenuHandler();
      return;
    }

    visualization.PrintDrinkDetails(drinkDetail);
    AnsiConsole.WriteLine("\nPress enter to return to menu...");
    Console.ReadLine();

    await MenuHandler();
  }

  public async Task GetRandomDrink()
  {
    visualization.PrintDrinkDetails(await drinkService.GetRandomDrink());
    AnsiConsole.WriteLine("\nPress enter to return to menu...");
    Console.ReadLine();
    await MenuHandler();
  }

}
