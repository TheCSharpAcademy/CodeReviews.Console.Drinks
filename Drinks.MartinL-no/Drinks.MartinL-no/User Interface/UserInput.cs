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
                ShowDrinksMenu(category);
            }

            else Helpers.ShowMessage("Invalid input, please try again");
        }
    }

    private void ShowDrinksMenu(string category)
    {
        throw new NotImplementedException();
    }
}

