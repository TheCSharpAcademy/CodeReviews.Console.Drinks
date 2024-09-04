using DrinksInfoLibrary.Models;
namespace DrinksInfoLibrary.Controllers.Main;

public  class DrinkManager
{
	public void Begin()
	{
		UserInput userInput = new();
		userInput.GetCategoriesInput();
	}
}
