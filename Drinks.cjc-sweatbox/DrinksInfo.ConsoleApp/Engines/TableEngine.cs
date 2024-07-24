using System.Reflection;
using ConsoleTableExt;
using DrinksInfo.Contracts.V1;
using Spectre.Console;

namespace DrinksInfo.ConsoleApp.Engines;

/// <summary>
/// Engine for Spectre.Table generation.
/// </summary>
internal class TableEngine
{
    #region Methods

    internal static Table GetCategoriesTable(IReadOnlyList<Category> categories)
    {
        Table table = new Table();

        table.AddColumn("Category");
        foreach (var category in categories)
        {
            table.AddRow(category.Name!);
        }

        return table;
    }

    internal static Table GetDrinksTable(IReadOnlyList<Drink> drinks)
    {
        Table table = new Table();

        table.AddColumn("ID");
        table.AddColumn("Name");
        foreach (var drink in drinks)
        {
            table.AddRow(drink.Id!, drink.Name!);
        }

        return table;
    }

    /// <summary>
    /// Generates the drink table.
    /// NOTE: Transposes the table and removes any null values.
    /// </summary>
    /// <param name="drink">The drink object to generate the properties into a table.</param>
    /// <returns>The generated spectre table object.</returns>
    internal static Table GetDrinkTable(Drink drink)
    {
        Table table = new Table();

        // Use reflection to get a list of non-null property values.
        var tableData = new List<KeyValuePair<string, string>>();
        foreach (PropertyInfo property in drink.GetType().GetProperties())
        {
            string? value = property.GetValue(drink)?.ToString();
            if (!string.IsNullOrWhiteSpace(value))
            {
                tableData.Add(new(property.Name, value));
            }
        }

        // Add columns although these will be hidden from the view.
        table.AddColumn("Key");
        table.AddColumn("Value");
        table.HideHeaders();

        // Add each key value pair to a row.
        foreach (var kvp in tableData)
        {
            table.AddRow(kvp.Key, kvp.Value);
        }

        // Expand the table to take up the full width of the console.
        table.Expand();

        return table;
    }

    #endregion
}
