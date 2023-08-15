using Drinks.MartinL_no.Controllers;

namespace Drinks.MartinL_no.UserInterface;

internal class UserInput
{
    private readonly DrinksController _controller;

	public UserInput(DrinksController controller)
	{
        _controller = controller;
    }

    public async Task Run()
    {
        var categories = (await _controller.GetCategories()).ToList();

        while (true)
        {
            Console.Clear();

            TableVisualizationEngine.ShowCategories(categories);

            var category = Helpers.Ask("Choose category (0 to exit): ");
            if (category == "0")
            {
                Helpers.ShowMessage("Program ended");
                return;
            }

            if (categories.Exists(c => c.ToLower() == category.ToLower()))
            {
                await ShowDrinksMenu(category);
            }

            else Helpers.ShowMessage("Invalid input, please try again");
        }
    }

    private async Task ShowDrinksMenu(string category)
    {
        var drinks = (await _controller.GetDrinks(category)).ToList();

        while (true)
        {
            Console.Clear();

            TableVisualizationEngine.ShowDrinks(drinks);

            Console.Write("Choose drink: ");
            var drinkName = Console.ReadLine();
            var drink = drinks.FirstOrDefault(d => d.Name.ToLower() == drinkName.ToLower());

            if (drink != null)
            {
                await ShowDrinkDetails(drink.Id);
                break;
            }

            else Helpers.ShowMessage("Invalid input, please try again");
        }
    }

    private async Task ShowDrinkDetails(int drinkId)
    {
        var drink = await _controller.GetDrinkDetails(drinkId);

        Console.Clear();
        Console.WriteLine($"""
            Name:           {drink.Name} ({drink.Alcoholic})
            Category:       {drink.Category}

            Glass:          {drink.Glass}

            """);
        TableVisualizationEngine.ShowIngredientsTable(drink.Ingredients);
        Console.WriteLine($"""
            Instructions:   {drink.Instructions}

            """);

        Helpers.Ask("Press any key to return to main menu");
    }
}
