using Drinks.MartinL_no.DAL;
using Drinks.MartinL_no.Models;

namespace Drinks.MartinL_no.Controllers;

internal class DrinksController
{
    private DrinksDataAccess _repo;

    public DrinksController(DrinksDataAccess repo)
	{
		_repo = repo;
	}

	public async Task<IEnumerable<string>> GetCategories()
	{
		var categories = await _repo.GetCategories();

        return categories.Select(c => c.Name);
	}

    public async Task<IEnumerable<Drink>> GetDrinks(string category)
    {
        return await _repo.GetDrinks(category);
    }

    public async Task<DrinkDetails> GetDrinkDetails(int drinkId)
    {
        return await _repo.GetDrinkDetails(drinkId);
    }
}
