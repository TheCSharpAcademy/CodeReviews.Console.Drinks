using Drinks.iamnikitakostin.Controllers;
using Drinks.iamnikitakostin.Models;
using Drinks.iamnikitakostin.Services;
using Spectre.Console;

namespace Drinks.iamnikitakostin.View;

internal class UserInterface : ConsoleController
{
    private readonly DrinkService _drinkService;

    public UserInterface(DrinkService drinkService)
    {
        _drinkService = drinkService;
    }

    public static string ShowCategoriesMenu(List<string> categories) {
        AnsiConsole.Clear();

        var choice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("Select a category")
            .AddChoices(categories));
        return choice;
    }

    public static string ShowDrinksByCategory(Dictionary<string,string> drinks)
    {
        AnsiConsole.Clear();

        var choice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("Select a drink")
            .AddChoices(drinks.Keys)
            .UseConverter(option => drinks[option]));
        return choice;
    }

    public bool ShowMainMenu()
    {
        AnsiConsole.Clear();
        var menuOptions = EnumToDisplayNames<Enums.MainMenu>();

        var choice = AnsiConsole.Prompt(
            new SelectionPrompt<Enums.MainMenu>()
            .Title("Select an option")
            .AddChoices(menuOptions.Keys)
            .UseConverter(option => menuOptions[option]));

        switch (choice)
        {
            case Enums.MainMenu.ViewCategories:
                ViewByCategory();
                break;
            case Enums.MainMenu.Favorites:
                ShowFavorites();
                break;
            case Enums.MainMenu.History:
                ShowHistory();
                break;
            case Enums.MainMenu.MostSearched:
                ShowMostSearched();
                break;
            default:
                return false;
        }
        return true;
    }

    public void ShowHistory()
    {
        AnsiConsole.Clear();

        List<HistoryItem> history = _drinkService.GetHistory();

        if (history == null || history.Count == 0)
        {
            ErrorMessage("You have no items in the history.");
            return;
        }

        Table table = new Table();

        table.AddColumn("Id of Record");
        table.AddColumn("Drink name");

        for (int i = 0; i < history.Count; i++)
        {
            table.AddRow(history[i].Id.ToString(), history[i].Name);
        }

        AnsiConsole.Write(table);
        AnsiConsole.Console.Input.ReadKey(false);
    }

    public void ShowFavorites()
    {
        AnsiConsole.Clear();

        List<DrinkDetail> list = _drinkService.GetFavorites();

        if (list == null || list.Count == 0)
        {
            ErrorMessage("You do not have any drinks in your favorites.");
            return;
        }

        Dictionary<string, int> drinkChoices = list.ToDictionary(d => d.strDrink, d => d.Id);

        var drinkId = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("Select an option")
            .AddChoices(drinkChoices.Keys));
        int selectedId = drinkChoices[drinkId];

        DrinkDetail drink = list.FirstOrDefault(d => d.Id == selectedId);
        Dictionary<string, string> validatedDrinkInformation = Validation.Drink(drink);

        DrawDrinkInfo(validatedDrinkInformation);

        AnsiConsole.WriteLine("Press any key to exit...");
        AnsiConsole.Console.Input.ReadKey(false);
    }

    public void ShowMostSearched()
    {
        AnsiConsole.Clear();

        Dictionary<string, int> mostSearched = _drinkService.GetMostSearched();

        if (mostSearched == null || mostSearched.Count == 0)
        {
            ErrorMessage("You have no items in the history.");
            return;
        }

        Table mostSearchedTable = new Table();

        mostSearchedTable.AddColumn("Drink Name");
        mostSearchedTable.AddColumn("Times Searched");

        foreach (var item in mostSearched)
        {
            string name = _drinkService.GetNameFromHistory(item.Key);
            mostSearchedTable.AddRow(name, item.Value.ToString());
        }

        AnsiConsole.Write(mostSearchedTable);
        AnsiConsole.Console.Input.ReadKey(false);
    }

    public void ViewByCategory()
    {
        List<string> availableCategories = DrinkService.GetCategories();
        string categoryChoice = UserInterface.ShowCategoriesMenu(availableCategories);
        Dictionary<string, string> availableDrinks = DrinkService.GetDrinksByCategory(categoryChoice);
        string idDrinkChoice = UserInterface.ShowDrinksByCategory(availableDrinks);
        DrinkDetail drink = DrinkService.GetDrinkById(idDrinkChoice);
        Dictionary<string, string> validatedDrinkInformation = Validation.Drink(drink);

        _drinkService.AddDrinkToHistory(validatedDrinkInformation["strDrink"], validatedDrinkInformation["idDrink"]);

        UserInterface.DrawDrinkInfo(validatedDrinkInformation);

        Enums.StandardMenu nextAction = UserInterface.ShowStandardMenu();

        if (nextAction == Enums.StandardMenu.AddToFavorites)
        {
            bool addToFavorites = _drinkService.AddDrinkToFavorites(drink);
        }
    }

    public static Enums.StandardMenu ShowStandardMenu()
    {
        var menuOptions = EnumToDisplayNames<Enums.StandardMenu>();

        var choice = AnsiConsole.Prompt(
            new SelectionPrompt<Enums.StandardMenu>()
            .Title("Select an option")
            .AddChoices(menuOptions.Keys)
            .UseConverter(option => menuOptions[option]));

        return choice;
    }

    public static void DrawDrinkInfo(Dictionary<string,string> drink) {
        AnsiConsole.Clear();

        Table table = new();
        table.AddColumn(new TableColumn("").Centered());
        table.AddColumn(new TableColumn("").Centered());
        table.ShowRowSeparators = true;

        foreach (var item in drink)
        {
            if (item.Key.StartsWith("str"))
            {
                string name = item.Key.Remove(0, 3);
                table.AddRow(name, item.Value);
            }
        }

        AnsiConsole.Write(table);
    }

    static Dictionary<TEnum, string> EnumToDisplayNames<TEnum>() where TEnum : struct, Enum
    {
        return Enum.GetValues(typeof(TEnum))
            .Cast<TEnum>()
            .ToDictionary(
                value => value,
                value => SplitCamelCase(value.ToString())
            );
    }

    internal static string SplitCamelCase(string input)
    {
        return string.Join(" ", System.Text.RegularExpressions.Regex
            .Split(input, @"(?<!^)(?=[A-Z])"));
    }
}
