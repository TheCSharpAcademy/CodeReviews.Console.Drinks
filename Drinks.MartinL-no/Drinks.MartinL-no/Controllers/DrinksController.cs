using System.Text.Json;
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

    public async Task<DrinkDetailsDto> GetDrinkDetails(int drinkId)
    {
        var details = await _repo.GetDrinkDetails(drinkId);

        return new DrinkDetailsDto()
        {
            Name = details.Name,
            Alcoholic = details.Name == "Alcoholic",
            Category = details.Category,
            Glass = details.Glass,
            Ingredients = ConstructIngredientsList(details.RemainingJsonFields),
            Instructions = details.Instructions
        };
    }

    private List<Ingredient> ConstructIngredientsList(Dictionary<string, JsonElement>? remainingJsonFields)
    {
        var ingredientNames = remainingJsonFields
            .Where(f => f.Value.ValueKind != JsonValueKind.Null)
            .Where(f => f.Key.StartsWith("strIngredient"))
            .Select(f => f.Value.GetString())
            .ToList();
        var measures = remainingJsonFields
            .Where(f => f.Value.ValueKind != JsonValueKind.Null)
            .Where(f => f.Key.StartsWith("strMeasure"))
            .Select(f => f.Value.GetString())
            .ToList();

        var ingredients = new List<Ingredient>();
        for (int i = 0; i < ingredientNames.Count(); i++)
        {
            ingredients.Add(new Ingredient(ingredientNames[i], measures[i]));
        }

        return ingredients;
    }
}
