using DrinksInfo.Models;
using Spectre.Console;

namespace DrinksInfo;

public static class TableVisualizationEngine
{
    public static string SelectCategory(List<Category> categories, string title)
    {
        var categoryNames = categories.Select(x => x.Name);
        
        var prompt = new SelectionPrompt<string>()
            .Title(title)
            .AddChoices(categoryNames)
            .EnableSearch();
        
        return AnsiConsole.Prompt(prompt);
    }

    public static string SelectDrink(List<Drink> drinks, string title)
    {
        var drinkNames = drinks.Select(x => x.Name);
        
        var prompt = new SelectionPrompt<string>()
            .Title(title)
            .AddChoices(drinkNames)
            .EnableSearch();
        
        return AnsiConsole.Prompt(prompt);
    }

    public static void ShowDrinkDetail(Dictionary<string, object?> prepList, string drinkDetailStrDrink)
    {
        var table = new Table();
        table.AddColumn("Key")
            .AddColumn("Value")
            .HideHeaders();

        foreach (var prop in prepList)
        {
            table.AddRow(prop.Key, prop.Value?.ToString() ?? string.Empty);
        }
        
        AnsiConsole.Write(table);
    }

    public static void NotFound()
    {
        AnsiConsole.MarkupLine("[red]Not found.[/]");
    }

    public static bool Continue()
    {
        var prompt = new ConfirmationPrompt("Choose another drink?");
        return AnsiConsole.Prompt(prompt);
    }
}