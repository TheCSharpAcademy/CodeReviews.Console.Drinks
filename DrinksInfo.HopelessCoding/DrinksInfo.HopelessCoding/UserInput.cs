using DrinksInfo.HopelessCoding.Models;
using Spectre.Console;

namespace DrinksInfo.HopelessCoding;

public class UserInput
{
    DrinksService drinksService = new();

    internal void GetCategoriesInput()
    {
        var categoryList = drinksService.GetCategories();
        var category = CategorySelection(categoryList);

        GetDrinksInput(category);
    }

    internal void GetDrinksInput(string category)
    {
        var drinkList = drinksService.GetDrinks(category);
        var drinkId = DrinkSelection(drinkList);
        drinksService.GetDrinkDetailsData(drinkId);
    }

    public static string CategorySelection(List<Category> categoriesList)
    {
        var selection = SelectorGenerator(categoriesList);
        if (selection == "Exit")
        {
            Console.WriteLine("Exiting...");
            Environment.Exit(0);
        }
        return selection;
    }

    internal string DrinkSelection(List<Drink> drinkList)
    {
        while (true)
        {
            Console.Clear();
            DataVisualisationEngine.GenerateDrinkTable(drinkList);
            Console.Write($"Write the Id of the drink (or 'exit' to return to menu): ");
            var drinkSelection = Console.ReadLine().Trim();

            if (drinkSelection.ToLower() == "exit")
            {
                GetCategoriesInput();
            }
            else if (!drinkList.Any(x => x.idDrink == drinkSelection))
            {
                Console.Write($"\nNo drink with the ID: {drinkSelection} found.\nPress any key to try again...");
                Console.ReadKey(true);
            }
            else
            {
                return drinkSelection;
            }
        }
    }

    public static string SelectorGenerator(List<Category> categoriesList)
    {
        Console.Clear();

        var choices = categoriesList.Select(c => c.strCategory).ToList();
        choices.Add("Exit");

        var selection = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("[aqua]SELECT A CATEGORY[/]")
                .MoreChoicesText("[grey]More[/]")
                .HighlightStyle("aquamarine3")
                .PageSize(15)
                .AddChoices(choices));

        return selection;
    }
}
