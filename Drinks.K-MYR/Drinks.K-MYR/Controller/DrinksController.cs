using System.Text.Json;

namespace Drinks.K_MYR;

internal class DrinksController
{
    private readonly ApiAccess _apiRepo;

    private readonly SqlAcess _sqlRepo;

    public DrinksController(ApiAccess apiRepo, SqlAcess sqlRepo)
    {
        _apiRepo = apiRepo;
        _sqlRepo = sqlRepo;
    }

    public IEnumerable<Drink> GetDrinksByLastSearched()
    {
        var drinks = _sqlRepo.GetDrinksByLastSearched();

        return drinks;
    }

    public IEnumerable<Drink> GetDrinksByFavourite()
    {
        var drinks = _sqlRepo.GetDrinksByFavourite();

        return drinks;
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

    internal async Task<DrinkDetailDto> GetDrinkByIdAsync(int drinkId)
    {
        var drinkDetails = await _apiRepo.GetDrinkById(drinkId);

        if (!_sqlRepo.DrinkRecordExists(drinkId))
        {
            _sqlRepo.InsertDrinkIntoDb(drinkId, drinkDetails.Drink, DateTime.Now);
        }

        else
        {
            _sqlRepo.UpdateDrinkById(drinkId, DateTime.Now.ToString("yyyy/MM/dd hh\\:mm\\:ss"));
        }

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

    internal void SaveDrinkAsFavourite(int drinkId)
    {
        _sqlRepo.UpdateDrinkById(drinkId, "saved = TRUE");
    }
}
