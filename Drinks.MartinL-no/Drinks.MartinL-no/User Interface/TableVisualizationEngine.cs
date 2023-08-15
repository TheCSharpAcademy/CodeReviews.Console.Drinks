using ConsoleTableExt;
using Drinks.MartinL_no.Models;

namespace Drinks.MartinL_no.UserInterface;

internal static class TableVisualizationEngine
{
    public static void ShowCategories(List<string> categories)
    {
        var tableData = FormatCategoriesTableData(categories);
        BuildTable(tableData, new string[] { "Categories Menu" });
    }

    public static void ShowDrinks(List<Drink> drinks)
    {
        var tableData = FormatDrinksTableData(drinks);
        BuildTable(tableData, new string[] { "Drinks Menu" });
    }

    private static List<List<object>> FormatCategoriesTableData(List<string> categories)
    {
        return categories.Select(category => new List<object>
            {
                category
            }).ToList();
    }

    private static List<List<object>> FormatDrinksTableData(List<Drink> drinks)
    {
        return drinks.Select(drink => new List<object>
            {
                drink.Name
            }).ToList();
    }

    private static void BuildTable(List<List<object>> tableData, params string[] columnNames)
    {
        ConsoleTableBuilder
            .From(tableData)
            .WithFormat(ConsoleTableBuilderFormat.Alternative)
            .WithColumn(columnNames)
            .ExportAndWriteLine();
        Console.WriteLine();
    }
}
