using DrinksInfo.Controllers;
using DrinksInfo.Models;
using Spectre.Console;

namespace DrinksInfo.UserInterface;

public class DrinksMenu
{
    private HttpClient? _httpClient;
    private DrinksInCategoryList? _drinksInCategoriesList;
    public string DrinkCategory { get; set; }

    public DrinksMenu(string drinkCategory)
    {
        DrinkCategory = drinkCategory;
        var task = LoadDrinksByCategory();
        task.Wait();
    }

    private async Task LoadDrinksByCategory()
    {
        var filter = "c=" + DrinkCategory;
        var uriRequest = "https://www.thecocktaildb.com/api/json/v1/1/filter.php?" + filter;

        _httpClient = new HttpClient();
        _drinksInCategoriesList = await ProcessApiRequest.ProcessRequestAsync<DrinksInCategoryList>(_httpClient, uriRequest);
    }

    internal void ShowDrinks()
    {
        Console.Clear();

        AnsiConsole.MarkupLine($"[cyan]Current Category: {DrinkCategory}[/]\n");
        AnsiConsole.MarkupLine($"[cyan]Choose a drink to see information about it:[/]");

        var chosenDrink = ListDrinksToSelect();
        if (chosenDrink == -1)
            return;

        DrinkDetailsView drinkDetailsView = new(_drinksInCategoriesList.Drinks[chosenDrink - 1].DrinkId);
        drinkDetailsView.ShowAllDetails();
    }

    private int ListDrinksToSelect()
    {
        if (_drinksInCategoriesList == null)
        {
            Console.WriteLine("There are no available drinks in this category right now!");
            return -1;
        }

        for (int i = 0; i < _drinksInCategoriesList.Drinks.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {_drinksInCategoriesList.Drinks[i].DrinkName}");
        }
        return GetUserInput(1, _drinksInCategoriesList.Drinks.Length);
    }

    private static int GetUserInput(int lowerBound, int upperBound)
    {
        string? readResult;
        AnsiConsole.MarkupLine($"\n[teal]Choose a drink ({lowerBound}-{upperBound}) or 0 to exit:[/]");

        while (true)
        {
            readResult = Console.ReadLine();
            if (string.IsNullOrEmpty(readResult))
            {
                AnsiConsole.MarkupLine($"\n[red]Make sure to enter a non-empty value in the allowed range ({lowerBound}-{upperBound}) or 0 to exit:[/]");
                continue;
            }
            string userEntry = readResult;

            if (!Int32.TryParse(userEntry, out int chosenCategory))
            {
                AnsiConsole.MarkupLine($"\n[red]Make sure to enter a 'Numeric' in the allowed range ({lowerBound}-{upperBound}) or 0 to exit:[/]");
                continue;
            }

            if (chosenCategory == 0)
            {
                return -1;
            }

            if (chosenCategory < lowerBound | chosenCategory > upperBound)
            {
                AnsiConsole.MarkupLine($"\n[red]Make sure to enter a value within the allowed range ({lowerBound}-{upperBound}) or 0 to exit:[/]");
                continue;
            }
            return chosenCategory;
        }
    }
}
