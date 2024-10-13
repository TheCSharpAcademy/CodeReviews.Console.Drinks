using DrinksInfo.Models;
using Spectre.Console;

namespace DrinksInfo
{
  public static class UserInterface
  {
    public static void ShowCategories(Dictionary<int, string> _categoryTempDb)
    {
      var table = new Table();
      table.AddColumn("Id");
      table.AddColumn("Category");

      for (int i = 1; i <= _categoryTempDb.Count; i++)
      {
        table.AddRow(i.ToString(), _categoryTempDb[i]);
      }

      AnsiConsole.Write(table);
    }

    public static void ShowDrinksByCategory(string categoryName, List<Drink> drinks)
    {
      var table = new Table();
      table.Title(categoryName);
      table.AddColumn("Id");
      table.AddColumn("Drink");

      foreach (var drink in drinks)
      {
        table.AddRow(drink.DrinkId.ToString(), drink.Name);
      }

      AnsiConsole.Write(table);
    }

    public static void ShowDrinkInformation(DrinkInfo drink)
    {
      var table = new Table();
      table.Title(drink.Name);
      table.AddColumn("Id");
      table.AddColumn("Name");
      table.AddColumn("Type");
      table.AddColumn("Glass");
      table.AddColumn("Instuctions");

      table.AddRow(drink.DrinkId.ToString(), drink.Name, drink.Type, drink.Glass, drink.Instructions);


      AnsiConsole.Write(table);
    }
  }
}
