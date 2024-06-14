using DrinksInfo.Models;

public class DrinksController
{
    private readonly IDrinksService _drinksService;

    public DrinksController(IDrinksService drinksService)
    {
        _drinksService = drinksService;
    }

    public async Task<DrinkCategories> GetCategories()
    {
        return await _drinksService.GetAsync<DrinkCategories>("/list.php?c=list");
    }

    public async Task<DrinksResponse> GetDrinksByCategory(List<DrinksCategory> categories)
    {
        var drinksResponse = new DrinksResponse(new List<Drink>());

        foreach (var category in categories)
        {
            var categoryDrinksResponse = await _drinksService.GetAsync<DrinksResponse>($"filter.php?c={category.Category}");

            if (categoryDrinksResponse?.Drinks != null)
            {
                drinksResponse.Drinks.AddRange(categoryDrinksResponse.Drinks);
            }
        }

        return drinksResponse;
    }
}

