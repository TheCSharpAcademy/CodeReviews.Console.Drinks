using Spectre.Console;

namespace Drinks;

public class UserInput
{
    public async Task MainMenu()
    {
        bool isRunning = true;

        while (isRunning)
        {
            var select = new SelectionPrompt<string>();
            select.AddChoice("Quit the application");
            select.AddChoice("Show the drink categories");
            var selectedCategory = AnsiConsole.Prompt(select);

            switch (selectedCategory)
            {
                case "Quit the application":
                    Environment.Exit(0);
                    isRunning = false;
                    break;

                case "Show the drink categories":
                    await DrinksMenu();
                    break;
            }
        }
    }

    internal async Task DrinksMenu()
    {
        Console.Clear();
        var drinksCategory = await HttpDrinks.GetDrinksCategory();

        var select = new SelectionPrompt<string>()
       .Title(" [bold]Drinks Category Menu[/] ")
       .PageSize(10)
       .AddChoices(drinksCategory.drinks.ConvertAll(drink => drink.strCategory));
        var selectedCategory = AnsiConsole.Prompt(select);

        await ShowDrinks(selectedCategory);
    }

    internal async Task ShowDrinks(string selectedCategory)
    {
        Console.Clear();
        var drinks = await HttpDrinks.ShowDrinkCategory(selectedCategory);

        var select = new SelectionPrompt<string>()
            .PageSize(50)
            .AddChoices(drinks.drinks.ConvertAll(drink => drink.strDrink));
        var selectedDrink = AnsiConsole.Prompt(select);

        await ShowDrinkIngredients(selectedDrink);
    }

    internal async Task ShowDrinkIngredients(string name)
    {
        Console.Clear();

        var drinkIngredients = await HttpDrinks.GetDrinksIngredients(name);

        foreach (var drink in drinkIngredients.drinks)
        {
            var table = new Table();

            table.AddColumn("Name");
            table.AddColumn(new TableColumn("Ingredients").Centered());
            table.AddColumn(new TableColumn("Type of drink").Centered());
            table.AddColumn(new TableColumn("Quantities").Centered());
            table.AddColumn(new TableColumn("How to make it").Centered());
            table.AddColumn(new TableColumn("Type of glass").Centered());

            var ingredients = new List<string?>
            {
            drink.strIngredient1,
            drink.strIngredient2,
            drink.strIngredient3,
            drink.strIngredient4,
            drink.strIngredient5,
            drink.strIngredient6,
            drink.strIngredient7,
            drink.strIngredient8,
            drink.strIngredient9,
            drink.strIngredient10,
            drink.strIngredient11,
            drink.strIngredient12,
            drink.strIngredient13,
            drink.strIngredient14,
            drink.strIngredient15
            };

            var quantities = new List<string>
            {
             drink.strMeasure1,
             drink.strMeasure2,
             drink.strMeasure3,
             drink.strMeasure4,
             drink.strMeasure5,
             drink.strMeasure6,
             drink.strMeasure7,
             drink.strMeasure8,
             drink.strMeasure9,
             drink.strMeasure10,
             drink.strMeasure11,
             drink.strMeasure12,
             drink.strMeasure13,
             drink.strMeasure14,
             drink.strMeasure15,
            };

            var filteredIngredients = ingredients.Where(ingredient => !string.IsNullOrEmpty(ingredient)).ToList();
            var filteredQuantities = quantities.Where(quantity => !string.IsNullOrEmpty(quantity)).ToList();

            table.AddRow($"{drink.strDrink}", string.Join(",", filteredIngredients), drink.strAlcoholic, string.Join(",", filteredQuantities), drink.strInstructions, drink.strGlass);
            AnsiConsole.Write(table);
        }
    }
}