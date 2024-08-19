using DataAccess;
using Models;
using Spectre.Console;
using System.Reflection;

namespace DrinksInfo;
internal class View
{
    public static async Task<string> DisplayMainMenu()
    {
        List<Category>? x = (await DrinkService.GetCategory()).drinks;
        Console.WriteLine("Choose a category: ");
        Dictionary<int, string> categories = new Dictionary<int, string>();

        int counter = 0;
        foreach (Category element in x)
        {
            if (!categories.ContainsKey(counter) && element.strCategory != null) 
            { 
                categories.Add(counter, element.strCategory); 
            }
            counter++;
        }
        string choice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .AddChoices(categories.Values)
            .HighlightStyle(Style.Parse("red"))
            );
        return choice;
    }

    public static async Task<string> DisplayDrinkMenu(string value)
    {
        List<Drinks>? x = (await DrinkService.GetDrinkList(value)).drinks;
        Console.WriteLine("Choose a drink: ");
        Dictionary<string, string> drinks = new Dictionary<string, string>();

        foreach (Drinks element in x)
        {
            if (element.strDrink != null && element.idDrink != null) 
            {
                if (!drinks.ContainsKey(element.idDrink))
                {
                    drinks.Add(element.idDrink, element.strDrink);
                }
            }
        }
        string choice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .AddChoices(drinks.Values)
            .HighlightStyle(Style.Parse("red"))
            );
        string key = drinks.FirstOrDefault(x => x.Value == choice).Key;
        return key;
    }
    public static async Task DisplayDrinkDetail(string key)
    {
        List<Drink>? x = await DrinkService.GetDrinkDetail(key);
        Console.WriteLine("Drink Information: ");
        foreach (Drink element in x)
        {
            var properties = element.GetType()
                              .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                              .Where(prop => prop.GetIndexParameters().Length == 0)
                              .Where(prop => prop.GetValue(element) != null)
                              .ToList();

            foreach (var prop in properties)
            {
                var value = prop.GetValue(element);
                Console.WriteLine($"{prop.Name}: {value}");
            }
        }
    }
    public static int Again()
    {
        Dictionary<string, int> YesNo = new Dictionary<string, int>();
        Console.WriteLine("Again?");

        YesNo.Add("Yes", 0);
        YesNo.Add("No", 1);

        string userChoice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .AddChoices(YesNo.Keys)
            .HighlightStyle(Style.Parse("red"))
            );
        return YesNo[userChoice];
    }
}
