using Spectre.Console;
using Drinks.frockett.Models;

namespace Drinks.frockett;

public class Visualization
{
    public void PrintTable(List<Category> categories)
    {
        Table table = new Table();
        table.Alignment(Justify.Center);
        table.Title("Drink Categories");
        table.AddColumn("Categories");

        foreach (var category in categories)
        {
            table.AddRow(category.StrCategory);
        }

        AnsiConsole.Write(table);
    }

    internal void PrintDrinks(List<Drink> drinks)
    {
        Table table = new Table();
        table.Alignment(Justify.Center);
        table.Title("Drink List");
        table.AddColumns(new[] { "Id", "Name" });

        foreach (var drink in drinks)
        {
            table.AddRow(drink.IdDrink, drink.StrDrink);
        }

        AnsiConsole.Write(table);
    }

    internal void PrintDrinkDetails(DrinkDetail drink)
    {
        string name = drink.StrDrink;
        string category = drink.StrCategory;
        string glass = drink.StrGlass;
        string instructions = drink.StrInstructions;
        string ingredients = drink.ConcatenateIngredients();

        var table = new Table();
        table.Alignment(Justify.Center);
        table.Title("Drink Recipe");
        table.AddColumns("Name", "Ingredients", "Category", "Glass", "Instructions");

        table.AddRow(name, ingredients, category, glass, instructions);

        AnsiConsole.Write(table);
    }
}
