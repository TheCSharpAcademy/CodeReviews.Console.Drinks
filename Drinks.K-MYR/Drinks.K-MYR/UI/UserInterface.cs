namespace Drinks.K_MYR.UI;

internal class UserInterface
{
    private readonly DrinksController _drinksController;

    public UserInterface(DrinksController drinksController)
    {
        _drinksController = drinksController;
    }

    internal async Task RunApp()
    {


        while (true)
        {
            AnsiConsole.Clear();
            Helpers.RenderTitle("[darkorange]Drinks Information Service[/]");

            List<string> categories = (await _drinksController.GetCategories()).ToList();

            var category = AnsiConsole.Prompt(new SelectionPrompt<string>()
                                                    .Title("[underline paleturquoise1]Choose A Category:[/]")
                                                    .PageSize(categories.Count + 1)
                                                    .AddChoices(categories)
                                                    .AddChoices("Exit"));

            if (category == "Exit")
                break;

            await GetDrinksInputAsync(category);
        }
    }

    private async Task GetDrinksInputAsync(string category)
    {
        while (true)
        {
            AnsiConsole.Clear();
            Helpers.RenderTitle("[darkorange]Drinks Information Service[/]");

            List<Drink> drinks = (await _drinksController.GetDrinksByCategoryAsync(category)).ToList();
            List<string> drinksList = drinks.Select(d => d.Name).ToList();

            var selection = AnsiConsole.Prompt(new SelectionPrompt<string>()
                                                    .Title("[underline paleturquoise1]Choose A Drink:[/]")
                                                    .PageSize(drinksList.Count + 1)
                                                    .AddChoices(drinksList)
                                                    .AddChoices("Exit"));

            if (selection == "Exit")
                break;

            await ShowDrinkDetails(drinks.First(d => d.Name == selection).Id);
        }
    }

    private async Task ShowDrinkDetails(int drinkId)
    {
        AnsiConsole.Clear();
        Helpers.RenderTitle("[darkorange]Drinks Information Service[/]");

        DrinkDetailDto drink = await _drinksController.GetDrinkByIdAsync(drinkId);

        var drinkInfo = new Table()
                            .Title($"[seagreen2]{drink.Drink}[/]");

        drinkInfo.AddColumn("[darkorange]Category[/]");
        drinkInfo.AddColumn("[darkorange]Alcoholic?[/]");
        drinkInfo.AddColumn("[darkorange]Glass[/]");
        drinkInfo.AddColumn("[darkorange]Tags[/]");
        drinkInfo.AddRow(drink.Category, drink.Alcohlic, drink.Glass, drink.Tags ??= "");
        drinkInfo.Expand();

        var drinkInstructions = new Table();

        drinkInstructions.AddColumn("[darkorange]Measure[/]");
        drinkInstructions.AddColumn("[darkorange]Ingredient[/]");

        foreach (var ingredient in drink.Ingredients)
        {

            drinkInstructions.AddRow(ingredient.Measure, ingredient.Name);
        }
        drinkInstructions.Expand();

        var instructionPanel = new Panel(drink.Instructions)
                                      .Header("[darkorange]Instructions[/]")
                                      .Expand();


        var panel = new Panel(new Rows(drinkInfo, drinkInstructions, instructionPanel)).Expand();

        AnsiConsole.Write(panel);
        AnsiConsole.Write(new Panel("Press any key to return main menu"));

        Console.ReadLine();
    }
}





























