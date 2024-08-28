using Drinks.Eddyfadeev.Interfaces.View;
using Drinks.Eddyfadeev.Models;
using Spectre.Console;

namespace Drinks.Eddyfadeev.View;

/// <summary>
/// Represents a class for constructing tables to display information about drinks.
/// </summary>
internal sealed class TableConstructor : ITableConstructor
{
    private const string EmptyPlaceholder = "";
    /// <summary>
    /// Creates a table to display information about a drink.
    /// </summary>
    /// <param name="drink">The drink object containing the information to be displayed in the table.</param>
    /// <returns>A Table object representing the constructed table.</returns>
    public Table CreateDrinkTable(Drink drink)
    {
        var table = CreateTable();
        table.AddColumn(EmptyPlaceholder);
        ConfigureMainTable(table);
        AddMainTableTitle(table, drink);
        AddSupportInfo(table, drink);
        AddIngredientsAndMeasures(table, drink);
        AddInstructions(table, drink);

        return table;
    }
    
    private static Table CreateTable() => new ();

    private static void ConfigureMainTable(Table table)
    {
        table.Border = TableBorder.Rounded;
        table.HideHeaders();
        table.HideFooters();
        table.Width(60);
    }

    private static void AddMainTableTitle(Table table, Drink drink) => 
        table.Title(drink.DrinkName);
    
    private static Table InitializeSubTable(string title, int columns)
    {
        var table = CreateTable();
        table.Title(title);
        table.HideHeaders();
        table.Border(TableBorder.None);
        table.Centered();
        table.HideFooters();
        
        for (var i = 0; i < columns; i++)
        {
            table.AddColumn(new TableColumn(EmptyPlaceholder));
        }

        return table;
    }
    
    private static void AddSupportInfo(Table table, Drink drink)
    {
        const string supportInfoTitle = "Drink Information";
        const string supportInfoCategory = "Category:";
        const string supportInfoAlcoholic = "Alcoholic:";
        const string supportInfoGlassType = "Glass Type:";
        const int supportInfoColumnsNum = 2;
        
        var supportInfoTable = InitializeSubTable(supportInfoTitle, supportInfoColumnsNum);
        
        supportInfoTable.AddRow(supportInfoCategory, drink.DrinkCategory);
        supportInfoTable.AddRow(supportInfoAlcoholic, drink.IsAlcoholic);
        supportInfoTable.AddRow(supportInfoGlassType, drink.DrinkGlassType);
        
        table.AddRow(supportInfoTable);
    }
    
    private static Table AddIngredients(Drink drink)
    {
        const int ingredientsColumnsNum = 1;
        
        var ingredientsTable = InitializeSubTable(EmptyPlaceholder, ingredientsColumnsNum);
        
        foreach (var ingredient in drink.Ingredients)
        {
            ingredientsTable.AddRow(ingredient);
        }
        
        return ingredientsTable;
    }
    
    private static Table AddMeasures(Drink drink)
    {
        const int measuresColumnsNum = 1;
        
        var measuresTable = InitializeSubTable(EmptyPlaceholder, measuresColumnsNum);
        
        foreach (var measure in drink.Measures)
        {
            measuresTable.AddRow(measure);
        }
        
        return measuresTable;
    }

    private static void AddIngredientsAndMeasures(Table table, Drink drink)
    {
        const string ingredientsTitle = "Ingredients";
        const int ingredientsColumnsNum = 2;
        
        var ingredientsAndMeasuresTable = InitializeSubTable(ingredientsTitle, ingredientsColumnsNum);
        
        var ingredientsTable = AddIngredients(drink);
        var measuresTable = AddMeasures(drink);
        
        ingredientsAndMeasuresTable.AddRow(measuresTable, ingredientsTable);

        table.AddRow(ingredientsAndMeasuresTable);
    }
    
    private static void AddInstructions(Table table, Drink drink)
    {
        const string instructionsTitle = "Instructions";
        const int instructionsColumnsNum = 1;
        
        var instructionsTable = InitializeSubTable(instructionsTitle, instructionsColumnsNum);
        
        instructionsTable.AddRow(drink.DrinkInstructions);
        
        table.AddRow(instructionsTable);
    }
}