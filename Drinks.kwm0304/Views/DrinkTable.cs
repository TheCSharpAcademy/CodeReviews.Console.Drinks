using Drinks.kwm0304.Models;
using Spectre.Console;

namespace Drinks.kwm0304.Views;

public class DrinkTable
{
  public static void DisplayDrink(DrinkDetail detail)
  {
    DisplayDetailsTable(detail);
    AnsiConsole.WriteLine();
    AnsiConsole.WriteLine();
    DisplayInstructions(detail);
    AnsiConsole.MarkupLine("\n\n[bold orange1]Press any key to return home..[/]\n");
    Console.ReadKey(true);
  }
  public static void DisplayDetailsTable(DrinkDetail details)
  {
    string[] cols = ["[turquoise2]Name[/]", "[turquoise2]Tags[/]", "[turquoise2]Category[/]",
                     "[turquoise2]Alcoholic[/]", "[turquoise2]IBA[/]", "[turquoise2]Type of Glass[/]" ];
    AnsiConsole.MarkupLine($"\n\n[turquoise2]Instructions:[/]\n\n {details.Instructions}\n\n");
    var table = new Table()
        .Title("[bold orange1]Drink Details[/]")
        .Centered()
        .Border(TableBorder.Ascii2)
        .BorderStyle(new Style(foreground: Color.Turquoise2, decoration: Decoration.Bold));

    table.AddColumns(cols);
    table.AddRow(
        details.Name ?? "-",
        details.Tags ?? "-",
        details.Category ?? "-",
        details.Alcoholic ?? "-",
        details.Iba ?? "-",
        details.Glass ?? "-"
    );
    AnsiConsole.Write(table);
  }

  public static void DisplayInstructions(DrinkDetail details)
  {
    string[] cols = ["[turquoise2]Ingredient[/]", "[turquoise2]Amount[/]"];
    var zipped = details.Ingredients.Zip(details.Measures, (ingredient, measure) => (ingredient, measure));
    var table = new Table()
    .Title("[orange1]Ingredients[/]")
    .Centered()
    .Border(TableBorder.Ascii2)
    .BorderStyle(new Style(foreground: Color.Turquoise2, decoration: Decoration.Bold));
    table.AddColumns(cols);
    foreach (var (ingredient, measure) in zipped)
    {
      if (!string.IsNullOrWhiteSpace(ingredient))
      {
        table.AddRow(ingredient, measure).Centered();
      }
    }
    AnsiConsole.Write(table);
  }
}