using System.Text.Json;

namespace Drinks.K_MYR;

internal class DrinksController
{
    private readonly ApiAccess _apiRepo;

    public DrinksController(ApiAccess apiRepo)
    {
        _apiRepo = apiRepo;
    }

    public async Task<IEnumerable<string>> GetCategories()
    {
        var categories = await _apiRepo.GetCategories();

        return categories.Select(c => c.Name).OrderBy(c => c);
    }

    internal async Task<IEnumerable<Drink>> GetDrinksByCategoryAsync(string category)
    {
        var drinks = await _apiRepo.GetDrinksByCategory(category);

        return drinks;
    }

    internal async Task<DrinkDetailDto> GetDrinkByIdAsync(int drink)
    {
        var drinkDetails = await _apiRepo.GetDrinkById(drink);

        return new DrinkDetailDto()
        {
            Drink = drinkDetails.Drink,
            Category = drinkDetails.Category,
            Alcohlic = drinkDetails.Alcohlic,
            Tags = drinkDetails.Tags,
            Glass = drinkDetails.Glass,
            Instructions = drinkDetails.Instructions,
            Ingredients = GenerateIngredients(drinkDetails.AdditionalInformation)
        };
    }

    private static List<Ingredient> GenerateIngredients(Dictionary<string, JsonElement>? additionalInformation)
    {
        List<Ingredient> ingredients = new();

        foreach (var key in additionalInformation.Keys)
        {
            if (key.StartsWith("strIngredient"))
            {
                if (!string.IsNullOrEmpty(additionalInformation[key].GetString()))
                {
                    string measureString = "strMeasure" + key[13..];
                    string measure = additionalInformation[measureString].GetString() ?? "";
                    string ingredient = additionalInformation[key].GetString();

                    ingredients.Add(new Ingredient(ingredient, measure));
                }
            }
        }

        return ingredients;
    }
}
