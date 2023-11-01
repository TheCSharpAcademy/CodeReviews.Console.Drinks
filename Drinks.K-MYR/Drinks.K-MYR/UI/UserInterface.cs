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

            var selection = AnsiConsole.Prompt(new SelectionPrompt<string>()
                                                        .Title("[underline paleturquoise1]Main Menu[/]")
                                                        .AddChoices("Browse Drinks", "Favourite Drinks", "Last Searched For", "Exit"));
            try
            {
                switch (selection)
                {
                    case "Browse Drinks":
                        await GetCategoryInputAsync();
                        break;
                    case "Favourite Drinks":
                        await GetDrinksInputFromSqlFavouriteAsync();
                        break;
                    case "Last Searched For":
                        await GetDrinksInputFromSqlLastSearchedAsync();
                        break;
                    case "Exit":
                        Environment.Exit(0);
                        break;
                }
            }
            catch (Exception ex)
            {
                AnsiConsole.Write(new Panel($"{ex.Message} | Press Any Key To Return"));
                Console.ReadKey();
            }
        }
    }

    private async Task GetDrinksInputFromSqlLastSearchedAsync()
    {
        while (true)
        {
            AnsiConsole.Clear();
            Helpers.RenderTitle("[darkorange]Drinks Information Service[/]");

            var drinks = _drinksController.GetDrinksByLastSearched();

            var drinksList = drinks.Select(d => d.Name).ToList();

            var selection = AnsiConsole.Prompt(new SelectionPrompt<string>()
                                                    .Title("[underline paleturquoise1]Choose A Drink:[/]")
                                                    .PageSize(15)
                                                    .AddChoices(drinksList)
                                                    .AddChoices("Exit"));

            if (selection == "Exit")
                break;

            try
            {
                await ShowDrinkDetails(drinks.First(d => d.Name == selection).Id);
            }
            catch (Exception ex)
            {
                AnsiConsole.Write(new Panel($"{ex.Message} | Press Any Key To Return"));
                Console.ReadKey();
            }
        }
    }

    private async Task GetDrinksInputFromSqlFavouriteAsync()
    {
        while (true)
        {
            AnsiConsole.Clear();
            Helpers.RenderTitle("[darkorange]Drinks Information Service[/]");

            var drinks = _drinksController.GetDrinksByFavourite();

            var drinksList = drinks.Select(d => d.Name).ToList();

            var selection = AnsiConsole.Prompt(new SelectionPrompt<string>()
                                                    .Title("[underline paleturquoise1]Choose A Drink:[/]")
                                                    .PageSize(15)
                                                    .AddChoices(drinksList)
                                                    .AddChoices("Exit"));

            if (selection == "Exit")
                break;

            try
            {
                await ShowDrinkDetails(drinks.First(d => d.Name == selection).Id);
            }
            catch (Exception ex)
            {
                AnsiConsole.Write(new Panel($"{ex.Message} | Press Any Key To Return"));
                Console.ReadKey();
            }
        }
    }

    private async Task GetCategoryInputAsync()
    {
        while (true)
        {
            AnsiConsole.Clear();
            Helpers.RenderTitle("[darkorange]Drinks Information Service[/]");

            List<string> categories = (await _drinksController.GetCategories()).ToList();

            var category = AnsiConsole.Prompt(new SelectionPrompt<string>()
                                                    .Title("[underline paleturquoise1]Choose A Category:[/]")
                                                    .PageSize(15)
                                                    .AddChoices(categories)
                                                    .AddChoices("Exit"));

            if (category == "Exit")
                break;

            try
            {
                await GetDrinksInputAsync(category);
            }
            catch (Exception ex)
            {
                AnsiConsole.Write(new Panel($"{ex.Message} | Press Any Key To Return"));
                Console.ReadKey();
            }
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
                                                    .PageSize(15)
                                                    .AddChoices(drinksList)
                                                    .AddChoices("Exit"));

            if (selection == "Exit")
                break;

            try
            {
                await ShowDrinkDetails(drinks.First(d => d.Name == selection).Id);
            }
            catch (Exception ex)
            {
                AnsiConsole.Write(new Panel($"{ex.Message} | Press Any Key To Return"));
                Console.ReadKey();
            }
        }
    }

    private async Task ShowDrinkDetails(int drinkId)
    {
        DrinkDetailDto? drink = await _drinksController.GetDrinkByIdAsync(drinkId);

        if (drink is null)
        {
            AnsiConsole.Write(new Panel("An Error Occured Fetching The Requested Drink. Press Any Key To Return"));
            Console.ReadKey();
            return;
        }

        bool returnToMainMenu = false;

        while (!returnToMainMenu)
        {
            AnsiConsole.Clear();
            Helpers.RenderTitle("[darkorange]Drinks Information Service[/]");

            var drinkInfo = new Table()
                                .Title($"[seagreen2]{drink.Drink}[/]");

            drinkInfo.AddColumn("[darkorange]Category[/]");
            drinkInfo.AddColumn("[darkorange]Alcoholic?[/]");
            drinkInfo.AddColumn("[darkorange]Glass[/]");
            drinkInfo.AddColumn("[darkorange]Tags[/]");
            drinkInfo.AddRow(drink.Category ??= "", drink.Alcohlic ??= "", drink.Glass ??= "", drink.Tags ??= "");
            drinkInfo.Expand();

            var drinkInstructions = new Table();
            drinkInstructions.AddColumn("[darkorange]Measure[/]");
            drinkInstructions.AddColumn("[darkorange]Ingredient[/]");

            foreach (var ingredient in drink.Ingredients)
            {
                drinkInstructions.AddRow(ingredient.Measure, ingredient.Name);
            }

            drinkInstructions.Expand();

            var instructionPanel = new Panel(drink.Instructions ??= "")
                                          .Header("[darkorange]Instructions[/]")
                                          .Expand();


            var panel = new Panel(new Rows(drinkInfo, drinkInstructions, instructionPanel)).Expand();
            AnsiConsole.Write(panel);

            bool drinkIsFavourite = _drinksController.DrinkIsFavourite(drinkId);

            if (drinkIsFavourite)
                AnsiConsole.Write(new Panel("S - Remove Drink From Your Favourites | Esc - Return To The Menu"));
            else
                AnsiConsole.Write(new Panel("S - Add Drink To Your Favourites | Esc - Return To The Menu"));

            _drinksController.InsertOrUpdateDrinkRecord(drinkId, drink.Drink);

            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.S:
                    _drinksController.ToggleDrinkIsFavourite(drinkId, drinkIsFavourite);
                    break;
                case ConsoleKey.Escape:
                    returnToMainMenu = true;
                    break;
            }
        }
    }
}
