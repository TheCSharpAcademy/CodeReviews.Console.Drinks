using System.Text.RegularExpressions;
using Spectre.Console;

namespace Drinks.UgniusFalze;

enum MenuOptions
{ 
    ViewCategories,
    Exit
}

public class Display
{
    private DrinksService Api { get; set; } = new();

    public void Start()
    {
        var exit = false;
        do
        {
            AnsiConsole.Clear();
            var selectionPrompt = new SelectionPrompt<MenuOptions>()
                .Title("What would you like to do?")
                .AddChoices(
                    MenuOptions.ViewCategories,
                    MenuOptions.Exit);
            selectionPrompt.Converter = options => Regex.Replace(options.ToString(), "(\\B[A-Z])",
                " $1");
            
            var option = AnsiConsole.Prompt(selectionPrompt);
            switch (option)
            {
                case MenuOptions.ViewCategories:
                    DisplayCategories();
                    break;
                case MenuOptions.Exit:
                    exit = true;
                    break;
            }
        } while (!exit);

    }
    private void DisplayCategories()
    {
        var categories = Api.GetDrinkCategories();
        
        if (categories.DrinkCategories.Count < 1)
        {
            Console.WriteLine("Drink categories is empty.");
            Console.ReadKey();
            return;
        }

        var selectionPrompt = new SelectionPrompt<Category>()
            .Title("Select which category's drink would you like to choose");
        selectionPrompt.Converter = category => category.StrCategory;
        foreach (var category in categories.DrinkCategories)
        {
            selectionPrompt.AddChoice(category);
        }

        var selectedCategory = AnsiConsole.Prompt(selectionPrompt);
        DisplayDrinks(selectedCategory);
    }

    private void DisplayDrinks(Category category)
    {
        var drinks = Api.GetDrinksRecord(category);
        var table = new Table();
        table.AddColumns("Drink", "Drink Image", "Id");
        foreach (var drinkRecords in drinks.Drinks)
        {
            table.AddRow(drinkRecords.StrDrink, drinkRecords.StrDrinkThumb.ToString(), drinkRecords.IdDrink.ToString());
        }
        AnsiConsole.Write(table);
        Drink drink;
        do
        {
            var input = AnsiConsole.Ask<string>("Please enter which drink (by id or name) details would like to see or 0 to exit: ");

            var isNumeric = int.TryParse(input, out var drinkId);
            if (isNumeric)
            {
                if (drinkId == 0)
                {
                    return;
                }
                drink = drinks.Drinks.Find(x => x.IdDrink == drinkId);
            }
            else
            {
                drink = drinks.Drinks.Find(x => x.StrDrink == input);
            }
            
            if (drink != null)
            {
                break;
            }
            Console.WriteLine("Drink not found.");
        } while (true);

        DisplayDrinkDetails(drink);
    }

    private void DisplayDrinkDetails(Drink drink)
    {
        AnsiConsole.Clear();
        var drinkDetailsRecord = Api.GetDrinkDetailsRecord(drink);
        var drinkDetail = drinkDetailsRecord.DrinkDetailsList.First();
        
        var table = new Table();
        table.AddColumns("Detail", "Value");
        foreach (var drinkRecord in drinkDetail.ConvertToList())
        {
            table.AddRow(drinkRecord[0].ToString(), drinkRecord[1].ToString());
        }

        AnsiConsole.Write(table);
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
}