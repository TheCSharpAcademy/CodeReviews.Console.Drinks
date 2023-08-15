using Drinks.MartinL_no.Controllers;

namespace Drinks.MartinL_no.UserInterface;

internal class UserInput
{
    private readonly DrinksController _controller;

	public UserInput(DrinksController controller)
	{
        _controller = controller;
    }
}

