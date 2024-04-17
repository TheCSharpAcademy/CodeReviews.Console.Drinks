using DrinksInfo.BBualdo.Models;
using Spectre.Console;

namespace DrinksInfo.BBualdo;

public class ConsoleEngine
{
  public static string GetSelection(string title, List<string> choices)
  {
    string choice = AnsiConsole.Prompt(new SelectionPrompt<string>()
                                       .Title(title)
                                       .AddChoices(choices));

    return choice;
  }

  public static void ShowTitle()
  {
    Rule rule = new Rule("Drinks Info").DoubleBorder().Centered();
    rule.Style = new Style(Color.Aqua);
    AnsiConsole.Write(rule);
  }

  public static void ShowDrinkTable(Drink drink)
  {
    Table table = new();
    table.AddColumn(new TableColumn("[yellow]Name[/]"));
    table.AddColumn(new TableColumn("[yellow]Type[/]"));
    table.AddColumn(new TableColumn("[yellow]Instructions[/]"));

    table.AddRow(drink.Name, drink.Type, drink.Instructions);

    AnsiConsole.Write(table);
  }
}