using DrinksInfo.Controllers;
using DrinksInfo.Models;
using Spectre.Console;

namespace DrinksInfo.UserInterface;

internal class MainMenu
{
    private HttpClient? _httpClient;
    private CategoriesList? _categoriesList;

    public  void ShowMenu()
    {
        Console.WriteLine("+-----------------------+");
        AnsiConsole.MarkupLine("| [teal]Categories Menu[/]\t|");
        Console.WriteLine("+-----------------------+\n");

        var task = LoadCategories();
        task.Wait(); // Makes sure to run this method in sync to avoid threads trying to acess categories list before its full of items

        var  chosenCategory = ShowCategories();
        if (chosenCategory == -1)
            return;

        DrinksMenu drinksMenu = new(_categoriesList.Drinks[chosenCategory - 1].DrinkCategoryName);
        drinksMenu.ShowDrinks();
    }

    private int ShowCategories()
    {
        if (_categoriesList == null)
        {
            Console.WriteLine("There are no available categories right now!");
            return -1;
        }
           
        for (int i = 0; i < _categoriesList.Drinks.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {_categoriesList.Drinks[i].DrinkCategoryName}");

        }
        return GetUserInput(1, _categoriesList.Drinks.Length);
    }

    private  async Task LoadCategories()
    {
        _httpClient = new();
        _categoriesList = await ProcessApiRequest.ProcessRequestAsync<CategoriesList>(_httpClient, "https://www.thecocktaildb.com/api/json/v1/1/list.php?c=list");
    }

    private static int GetUserInput(int lowerBound, int upperBound)
    {
        string? readResult;
        AnsiConsole.MarkupLine($"\n[teal]Choose a category ({lowerBound}-{upperBound}) or 0 to exit:[/]");

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
