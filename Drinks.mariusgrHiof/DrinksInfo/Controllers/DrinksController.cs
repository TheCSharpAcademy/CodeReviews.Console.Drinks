using DrinksInfo.Api;

namespace DrinksInfo.Controllers;

public class DrinksController
{
    private readonly IApiClient _apiClient;

    public DrinksController(IApiClient apiClient)
    {
        _apiClient = apiClient;
    }

    public async Task<IEnumerable<Category>> GetCategoriesAsync()
    {
        var categroies = await _apiClient.GetCategories();

        return categroies;
    }

    public async Task<Drink> GetDrinkByIdAsync(string id)
    {
        var drink = await _apiClient.GetDrinkDetailById(id);
        if (drink == null) return null;

        return drink;
    }

    public async Task<IEnumerable<Drink>> GetDrinksByCategoryAsync(string category)
    {
        string modifiedStringCategory = category.Replace(' ', '_');
        try
        {
            var drinks = await _apiClient.GetDrinksByCategory(modifiedStringCategory);
            if (drinks == null)
            {
                return Enumerable.Empty<Drink>();
            }
            return drinks;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);

            return Enumerable.Empty<Drink>();
        }


    }
}

