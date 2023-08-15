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

            // Table to be added

            var category = Helpers.Ask("Choose category: ");

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

            // Add table

            Console.Write("Choose drink: ");
            var drink = Console.ReadLine();
            var exists = drinks.Exists(d => d.Name.ToLower() == drink.ToLower());

            if (drinks.Exists(d => d.Name.ToLower() == drink.ToLower()))
            {
                ShowDrinkDetails(drink);
            }

            else Helpers.ShowMessage("Invalid input, please try again");
        }
    }

    private void ShowDrinkDetails(string drink)
    {
        throw new NotImplementedException();
    }
}

