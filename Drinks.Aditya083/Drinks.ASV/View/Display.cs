using Drinks.ASV.Model;
using Spectre.Console;

namespace Drinks.ASV.View;

internal class Display
{
    public static string GetSelection(string title, DrinkCategoriesList drinksCategories)
    {
        
        var choices = drinksCategories.DrinkTypes.Select(category => category.strCategory).ToList();
        choices.Add("Exit Application");
        var selectedCategory = AnsiConsole.Prompt(
            new SelectionPrompt<string>().Title(title).PageSize(12).AddChoices(choices).HighlightStyle(new Style(foreground: Color.White))
        );
        return selectedCategory;
    }
    
    public static void ShowDrinks(string title, string[] columns, SelectedDrinkCategoryDrinks drinks)
    {
        var table = new Table();
        table.Caption(title);
        foreach (var column in columns)
        {
            table.AddColumn(column);
        }
        foreach (var drink in drinks.Drinks)
        {
            table.AddRow(drink.DrinkId, drink.DrinkName);
        }
        AnsiConsole.Render(table);
    }

}

