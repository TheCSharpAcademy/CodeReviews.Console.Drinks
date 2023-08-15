using System.Text.Json;
using Drinks.MartinL_no.Models;

namespace Drinks.MartinL_no.Controllers;

internal class DrinksController
{
    private IDrinksDataAccess _repo;

    public DrinksController(IDrinksDataAccess repo)
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
            Alcoholic = details.Alcoholic,
            Category = details.Category,
            Glass = details.Glass,
            Ingredients = ConstructIngredientsList(details.RemainingJsonFields),
            Instructions = details.Instructions
        };
    }

    private List<Ingredient> ConstructIngredientsList(Dictionary<string, JsonElement>? remainingJsonFields)
    {
        var measures = remainingJsonFields
            .Where(f => f.Key.StartsWith("strMeasure"))
            .Where(f => f.Value.ValueKind != JsonValueKind.Null)
            .Select(f => new string[] { f.Key.Substring(10), f.Value.GetString() });

        var ingredientNamesWithMeasures = remainingJsonFields
            .Where(f => f.Key.StartsWith("strIngredient"))
            .Where(f => f.Value.ValueKind != JsonValueKind.Null)
            .Select(f => new string[] { f.Key.Substring(13), f.Value.GetString() })
            .Union(measures)
            .GroupBy(pair => pair[0])
            .Select(group => new
            {
                Id = group.Key,
                IngredientDetails = group.Select(i => i[1]).ToList()
            })
            .Where(group => group.IngredientDetails[0] != "");

        var ingredients = new List<Ingredient>();

        foreach (var group in ingredientNamesWithMeasures)
        {
            var name = group.IngredientDetails[0];
            var measure = group.IngredientDetails.Count() == 2 ? group.IngredientDetails[1] : "";
            ingredients.Add(new Ingredient(name, measure));
        }
        return ingredients;
    }
}
