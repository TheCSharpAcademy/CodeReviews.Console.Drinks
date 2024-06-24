using DrinksInfo.Controllers;
using DrinksInfo.Models;
using Spectre.Console;

namespace DrinksInfo.UI;

internal class UserInteface
{
    private IDrinksController _drinksController;

    public UserInteface(IDrinksController drinksController)
    {
        _drinksController = drinksController;
    }

    public async Task Start()
    {
        Task<IEnumerable<Category>> categoriesTask = _drinksController.GetCategories();
        AnsiConsole.Write(new Markup("[underline red]Welcome to Drinks Application[/]").Justify(Justify.Center));
        
        while (true)
        {   
            SelectionPrompt<string> prompt = new SelectionPrompt<string>()
                                               .PageSize(8)
                                               .MoreChoicesText("[grey](Move up and down to reveal more drinks)[/]")
                                               .Title("Choose a category from the list above to see what drinks are included.");

        
            List<Category> categories = (await categoriesTask).ToList();

            foreach (Category category in categories) 
            {
                prompt.AddChoice(category.Name);
            }

            prompt.AddChoice("Exit");

            string chosenCategory = AnsiConsole.Prompt(prompt);

            if (chosenCategory.ToLower() == "exit")
            {
                AnsiConsole.Clear();
                AnsiConsole.WriteLine("Goodbye. Thank you for choosing us!");
                return;
            }

            if (categories.Exists(category => category.Name.ToLower() == chosenCategory.ToLower()))
            {
                Console.Clear();
                await ShowDrinks(chosenCategory);
            }
            else
            {
                AnsiConsole.Write("Invalid Selection, please try again");
            }
        }
    }

    private async Task ShowDrinks(string category)
    {
        IEnumerable<Drink> drinks = await _drinksController.GetDrinksByCategory(category);

        while (true)
        {
            string chosenDrink = DisplayDrinkSelectionPrompt(drinks);

            if (chosenDrink.ToLower() == "back")
            {
                return;
            }

            if (chosenDrink != null)
            {
                int selectedDrinkId = drinks.FirstOrDefault(drink => drink.drinkName.ToLower() == chosenDrink.ToLower()).drinkId;
                await ShowDrinkInfo(selectedDrinkId);
                AnsiConsole.Clear();
                return;
            }
            else
            {
                AnsiConsole.Write("Invalid Selection, please try again");
            }
        }
    }

    private string DisplayDrinkSelectionPrompt(IEnumerable<Drink> drinks)
    {
        var prompt = new SelectionPrompt<string>()
            .PageSize(8)
            .MoreChoicesText("[grey](Move up and down to reveal more drinks)[/]")
            .Title("Select the drink that you want to know more about");

        foreach (Drink drink in drinks)
        {
            prompt.AddChoice(drink.drinkName);
        }

        prompt.AddChoice("Back");

        return AnsiConsole.Prompt(prompt);
    }
    private async Task ShowDrinkInfo(int chosenDrinkId)
    {
        AnsiConsole.Clear();
        DrinkDetailDto selectedDrink = await _drinksController.GetDrinkInfoById(chosenDrinkId);
        var infoTable = CreateInfoTable(selectedDrink);
        var instructionsTable = CreateInstructionsTable(selectedDrink);
        var layout = new Panel(new Rows(infoTable, new Rule("[grey]Instructions[/]").Centered(), new Text(selectedDrink.Instructions).Centered(), instructionsTable))
            .Expand();
        AnsiConsole.Write(layout);

        AnsiConsole.WriteLine("Press any key to return to the main menu");
        Console.ReadLine();
    }

    private Table CreateInfoTable(DrinkDetailDto selectedDrink)
    {
        return new Table()
            .Title($"[blue]{selectedDrink.Drink} Details[/]")
            .AddColumn(new TableColumn("Attribute").Centered())
            .AddColumn(new TableColumn("Value").Centered())
            .AddRow("Category", selectedDrink.Category)
            .AddRow("Glass", selectedDrink.Glass)
            .AddRow("Alcoholic", string.IsNullOrEmpty(selectedDrink.Alcoholic) ? "No" : "Yes")
            .Border(TableBorder.Rounded)
            .BorderColor(Color.DarkSlateGray1)
            .Expand();
    }

    private Table CreateInstructionsTable(DrinkDetailDto selectedDrink)
    {
        var instructionsTable = new Table()
            .Title("\n[grey]Ingredients & Measurements[/]")
            .AddColumn(new TableColumn("Ingredient").Centered())
            .AddColumn(new TableColumn("Measurement").Centered())
            .Border(TableBorder.Rounded)
            .BorderColor(Color.DarkSlateGray1)
            .Expand();

        foreach (var ingredient in selectedDrink.Ingredients)
        {
            string ingredientName = ingredient.Name ?? "N/A";
            string measurement = ingredient.Measurement ?? "N/A";
            instructionsTable.AddRow(ingredientName, measurement);
        }

        return instructionsTable;
    }

}
