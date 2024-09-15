using System.Security.Cryptography.X509Certificates;
using Spectre.Console;

namespace Drinks_Info.Lawang.Models;

public class UserInput
{
    DrinkService drinkService = new();

    internal async Task GetCategoriesInput()
    {
        bool exit = false;
        while (!exit)
        {

            Console.Clear();
            var categories = await drinkService.GetCategories();
            exit = GetUserInput(categories);
        }
    }

    public bool GetUserInput(List<Category> categories)
    {

        AnsiConsole.MarkupLine("[yellow bold]Choose Category: [/]");
        var category = Console.ReadLine()?.Trim();

        while (!Validator.IsStringValid(category ?? ""))
        {
            if (category == "0") return true;

            AnsiConsole.MarkupLine("[red bold]Invaid Category.[/]");
            category = Console.ReadLine()?.Trim();

        }

        while (!categories.Any(x => x.strCategory == category))
        {
            if (category == "0") return true;
            if (string.IsNullOrEmpty(category))
            {
                AnsiConsole.MarkupLine("[red bold]Invaid Category.[/]");
            }
            else
            {
                AnsiConsole.MarkupLine("[red bold]Category doesn't exists.[/]");
            }
            category = Console.ReadLine()?.Trim();
        }
        if (category != null)
            GetInputCategory(category);

        return false;

    }

    public void GetInputCategory(string category)
    {
        var listOfDrink = drinkService.GetDrinksByCategory(category);
        AnsiConsole.Markup("[yellow bold]Choose a drink or press '0' to go back to category menu: [/]");

        string? input = Console.ReadLine()?.Trim();
        bool exit = false;
        do
        {
            if (input == "0")
            {
                return;
            }
            if (Validator.IsIdValid(input))
            {
                if (!listOfDrink.Any(x => x.idDrink == input))
                {
                    AnsiConsole.MarkupLine("[red bold]Drink Id doesn't exist[/]");
                    input = Console.ReadLine()?.Trim();
                }
                else
                {
                    drinkService.GetDrink(input ?? "");
                    exit = true;
                }
            }
            else
            {
                AnsiConsole.MarkupLine("[red bold]Invalid Category.[/]");
                input = Console.ReadLine()?.Trim();
            }


        } while (!exit);
    }
}
