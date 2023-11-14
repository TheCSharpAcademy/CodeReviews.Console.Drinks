using DrinksInfo.Controllers;
using Spectre.Console;

namespace DrinksInfo.UI;

public class UserInterface
{
    private readonly DrinksController _drinksController;

    public UserInterface(DrinksController drinksController)
    {
        _drinksController = drinksController;
    }

    public async Task Run()
    {
        AnsiConsole.Write(
        new FigletText("Drinks Menu")
        .LeftJustified()
        .Color(Color.Blue));

        string category = await GetCategoryFromUser();
        Drink drink = await GetDrinkFromUser(category);

        var drinkDetails = await GetDrinkDetails(drink.IdDrink);

        DisplayDrinkDetails(drinkDetails);

    }

    private async Task<string> GetCategoryFromUser()
    {
        var categories = await _drinksController.GetCategoriesAsync();

        var categoriesArray = categories.Select(c => c.CategoryName).ToArray();

        var category = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Select a category from the menu")
                .PageSize(10)
                .MoreChoicesText("[grey](Move up and down to reveal more categories)[/]")
                .AddChoices(categoriesArray));

        return category;
    }

    private async Task<Drink> GetDrinkFromUser(string category)
    {
        var drinks = await _drinksController.GetDrinksByCategoryAsync(category);

        var drink = AnsiConsole.Prompt(
         new SelectionPrompt<Drink>()
             .Title("Select a drink from the menu")
             .PageSize(10)
             .HighlightStyle(Color.Red)
             .WrapAround(shouldWrap: true)
             .MoreChoicesText("[grey](Move up and down to reveal more categories)[/]")
             .UseConverter(d => d.StrDrink)
             .AddChoices(drinks));

        return drink;
    }

    private async Task<Drink> GetDrinkDetails(string id)
    {
        var drinkDetails = await _drinksController.GetDrinkByIdAsync(id);
        if (drinkDetails == null)
        {
            Console.WriteLine("No drink found");
            return null;
        }
        else
        {
            return drinkDetails;
        }
    }

    private void DisplayDrinkDetails(Drink drink)
    {
        string id = drink.IdDrink;
        string name = drink.StrDrink;
        string category = drink.StrCategory;
        string glass = drink.StrGlass;
        string instructions = drink.StrInstructions;
        string ingredients = drink.ConcatenateIngredients();

        var table = new Table();

        table.AddColumns("Id", "Name", "Ingredients", "Category", "Glass", "Instructions");

        table.AddRow(id, name, ingredients, category, glass, instructions);


        AnsiConsole.Write(table);
    }
}

