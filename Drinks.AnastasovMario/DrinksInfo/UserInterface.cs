using DrinksInfo.Models;
using Spectre.Console;

namespace DrinksInfo
{
  public static class UserInterface
  {
    public static void ShowCategories(Dictionary<int, string> categories)
    {
      var table = new Table().Border(TableBorder.Rounded);
      table.AddColumn("Id").AddColumn("Category");
      foreach (var category in categories)
      {
        table.AddRow(category.Key.ToString(), category.Value);
      }
      AnsiConsole.Write(table);
    }

    public static void ShowDrinksByCategory(string categoryName, List<Drink> drinks)
    {
      AnsiConsole.Clear();
      var table = new Table().Border(TableBorder.Rounded);
      table.Title($"[green]{categoryName}[/]");
      table.AddColumn("Id").AddColumn("Drink");
      foreach (var drink in drinks)
      {
        table.AddRow(drink.DrinkId.ToString(), drink.Name);
      }
      AnsiConsole.Write(table);
    }

    public static void ShowDrinkInformation(DrinkInfo drink)
    {
      AnsiConsole.Clear();
      var panel = new Panel(GetDrinkInfoText(drink))
      {
        Header = new PanelHeader(drink.Name),
        Expand = true,
        Border = BoxBorder.Rounded
      };
      AnsiConsole.Write(panel);
    }

    public static void ShowSearchResults(List<DrinkInfo> drinks)
    {
      var table = new Table().Border(TableBorder.Rounded);
      table.Title("[green]Search Results[/]");
      table.AddColumn("Id").AddColumn("Name").AddColumn("Category");
      foreach (var drink in drinks)
      {
        table.AddRow(drink.DrinkId.ToString(), drink.Name, drink.Category);
      }
      AnsiConsole.Write(table);
    }

    private static string GetDrinkInfoText(DrinkInfo drink)
    {
      return $"[bold]ID:[/] {drink.DrinkId}\n" +
             $"[bold]Name:[/] {drink.Name}\n" +
             $"[bold]Category:[/] {drink.Category}\n" +
             $"[bold]Type:[/] {drink.Type}\n" +
             $"[bold]Glass:[/] {drink.Glass}\n\n" +
             $"[bold]Instructions:[/]\n{drink.Instructions}\n\n" +
             $"[bold]Ingredients:[/]\n{GetIngredientsText(drink)}";
    }

    private static string GetIngredientsText(DrinkInfo drink)
    {
      var ingredients = drink.GetIngredients();
      return string.Join("\n", ingredients.Select(i => $"- {i.Measure} {i.Ingredient}".Trim()));
    }
  }
}