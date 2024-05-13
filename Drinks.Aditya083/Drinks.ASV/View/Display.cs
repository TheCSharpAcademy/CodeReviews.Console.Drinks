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

    public static void ShowDrinkDetails(string column, DrinkDetails? drink)
    {
        var mainTable = new Table();
        mainTable.AddColumn(column).Centered();
        foreach (var detail in drink.Drink)
        {
            mainTable.AddRow("Name: " + detail.DrinkName);
            mainTable.AddRow("Is Alcoholic: " + detail.IsAlcoholic);
            mainTable.AddRow("Glass: " + detail.Glass);
            mainTable.AddRow("Instructions: " + detail.Instructions);
            var ingredientsTable = new Table();
            ingredientsTable.AddColumn(new TableColumn("Ingredient").Centered());
            ingredientsTable.AddColumn(new TableColumn("Quantity").Centered());
            AddIngredientRow(ingredientsTable, detail.StrIngredient1, detail.StrMeasure1);
            AddIngredientRow(ingredientsTable, detail.StrIngredient2, detail.StrMeasure2);
            AddIngredientRow(ingredientsTable, detail.StrIngredient3, detail.StrMeasure3);
            AddIngredientRow(ingredientsTable, detail.StrIngredient4, detail.StrMeasure4);
            AddIngredientRow(ingredientsTable, detail.StrIngredient5, detail.StrMeasure5);
            AddIngredientRow(ingredientsTable, detail.StrIngredient6, detail.StrMeasure6);
            AddIngredientRow(ingredientsTable, detail.StrIngredient7, detail.StrMeasure7);
            AddIngredientRow(ingredientsTable, detail.StrIngredient8, detail.StrMeasure8);
            AddIngredientRow(ingredientsTable, detail.StrIngredient9, detail.StrMeasure9);
            AddIngredientRow(ingredientsTable, detail.StrIngredient10, detail.StrMeasure10);
            AddIngredientRow(ingredientsTable, detail.StrIngredient11, detail.StrMeasure11);
            AddIngredientRow(ingredientsTable, detail.StrIngredient12, detail.StrMeasure12);
            AddIngredientRow(ingredientsTable, detail.StrIngredient13, detail.StrMeasure13);
            AddIngredientRow(ingredientsTable, detail.StrIngredient14, detail.StrMeasure14);
            AddIngredientRow(ingredientsTable, detail.StrIngredient15, detail.StrMeasure15);
            mainTable.AddRow(ingredientsTable);
        }
        AnsiConsole.Render(mainTable);
    }

    private static void AddIngredientRow(Table table, string ingredient, string quantity)
    {
        if (!string.IsNullOrEmpty(ingredient) && !string.IsNullOrEmpty(quantity))
        {
            table.AddRow(ingredient, quantity);
        }
    }
}