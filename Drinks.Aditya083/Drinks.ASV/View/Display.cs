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
            AddIngredientRow(ingredientsTable, detail.strIngredient1, detail.strMeasure1);
            AddIngredientRow(ingredientsTable, detail.strIngredient2, detail.strMeasure2);
            AddIngredientRow(ingredientsTable, detail.strIngredient3, detail.strMeasure3);
            AddIngredientRow(ingredientsTable, detail.strIngredient4, detail.strMeasure4);
            AddIngredientRow(ingredientsTable, detail.strIngredient5, detail.strMeasure5);
            AddIngredientRow(ingredientsTable, detail.strIngredient6, detail.strMeasure6);
            AddIngredientRow(ingredientsTable, detail.strIngredient7, detail.strMeasure7);
            AddIngredientRow(ingredientsTable, detail.strIngredient8, detail.strMeasure8);
            AddIngredientRow(ingredientsTable, detail.strIngredient9, detail.strMeasure9);
            AddIngredientRow(ingredientsTable, detail.strIngredient10, detail.strMeasure10);
            AddIngredientRow(ingredientsTable, detail.strIngredient11, detail.strMeasure11);
            AddIngredientRow(ingredientsTable, detail.strIngredient12, detail.strMeasure12);
            AddIngredientRow(ingredientsTable, detail.strIngredient13, detail.strMeasure13);
            AddIngredientRow(ingredientsTable, detail.strIngredient14, detail.strMeasure14);
            AddIngredientRow(ingredientsTable, detail.strIngredient15, detail.strMeasure15);
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