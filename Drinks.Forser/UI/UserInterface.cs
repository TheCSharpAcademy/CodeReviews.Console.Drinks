internal class UserInterface
{
    private DrinksController _controller;

    public UserInterface(DrinksController controller)
    {
        _controller = controller;
    }

    public async Task Run()
    {
        List<string> categories = (await _controller.GetCategories()).ToList();

        while (true)
        {
            AnsiConsole.Clear();
            Helpers.RenderTitle("Drinks Info");

            SelectionPrompt<string> categoryPrompt = new SelectionPrompt<string>();
            categoryPrompt.PageSize(10);
            categoryPrompt.MoreChoicesText("[grey](Move up and down to reveal more categories)[/]");
            categoryPrompt.Title("Select the drink category you want!");

            foreach (string category in categories)
            {
                categoryPrompt.AddChoice(category);
            }
            categoryPrompt.AddChoice("Exit");

            string chosenCategory = AnsiConsole.Prompt(categoryPrompt);

            if (chosenCategory.ToLower() == "exit")
            {
                Helpers.ShowMessage("Program ended");
                return;
            }

            if(categories.Exists(c => c.ToLower() == chosenCategory.ToLower()))
            {
                await ShowDrinksMenu(chosenCategory);
            }
            else
            {
                Helpers.ShowMessage("Invalid Selection, please try again");
            }
        }
    }

    private async Task ShowDrinksMenu(string choosenCategory)
    {
        List<Drink> drinks = (await _controller.GetDrinksByCategory(choosenCategory)).ToList();

        while (true)
        {
            AnsiConsole.Clear();
            Helpers.RenderTitle("Drinks Info");

            var drinkList = drinks.Select(c => c.Name).ToList();
            drinkList.Add("Exit");

            var chosenDrink = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .PageSize(10)
                    .MoreChoicesText("[grey](Move up and down to reveal more drinks)[/]")
                    .Title("Select the drink you want more details for!")
                    .AddChoices(drinkList));

            if (chosenDrink.ToLower() == "exit")
            {
                Helpers.ShowMessage("Program ended");
                return;
            }

            if (chosenDrink != null && drinks.Any())
            {
                var drinkId = drinks.FirstOrDefault(c => c.Name == chosenDrink).Id;

                await ShowDrinkDetails(drinkId);
                break;
            }
            else
            {
                Helpers.ShowMessage("Invalid Selection, please try again");
            }
        }
    }
    private async Task ShowDrinkDetails(int drinkId)
    {
        DrinkDetailsDto selectedDrink = await _controller.GetDrinkById(drinkId);

        AnsiConsole.Clear();

        var infoTable = new Table();

        infoTable.Title($"[blue]{selectedDrink.Name}[/]");
        infoTable.AddColumn(new TableColumn("Drink Category").Centered());
        infoTable.AddColumn(new TableColumn($"{selectedDrink.Category}").Centered());
        infoTable.AddRow("Glass", selectedDrink.Glass);
        infoTable.Expand();

        var instructionsTable = new Table();

        instructionsTable.Title($"{selectedDrink.Instructions}");
        instructionsTable.AddColumn(new TableColumn("Ingredients").Centered());
        instructionsTable.AddColumn(new TableColumn("Measurements").Centered());
        instructionsTable.Expand();

        foreach(var ingredient in selectedDrink.Ingredients)
        {
            var ingredientName = ingredient.Name;
            var measurement = ingredient.Measure;

            instructionsTable.AddRow(ingredientName, measurement);
        }

        var layout = new Panel(new Rows(
            infoTable,
            instructionsTable
            ));
        layout.Expand();

        AnsiConsole.Write(layout);

        AnsiConsole.WriteLine("Press any key to return main menu");
        Console.ReadLine();
    }
}