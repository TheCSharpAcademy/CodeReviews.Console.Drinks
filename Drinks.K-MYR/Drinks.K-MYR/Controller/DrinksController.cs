using Drinks.K_MYR.Models;
using System.Text.Json;

namespace Drinks.K_MYR;

internal class DrinksController
{
    private readonly ApiAccess _apiRepo;

    private readonly SqlAcess _sqlRepo;

    internal DrinksController(ApiAccess apiRepo, SqlAcess sqlRepo)
    {
        _apiRepo = apiRepo;
        _sqlRepo = sqlRepo;
    }

    internal IEnumerable<Drink> GetDrinksByLastSearched()
    {
        var drinks = _sqlRepo.GetDrinksByLastSearched();

        return drinks;
    }

   internal IEnumerable<Drink> GetDrinksByFavourite()
    {
        var drinks = _sqlRepo.GetDrinksByFavourite();

        return drinks;
    }

    public async Task<IEnumerable<string>> GetCategories()
    {
        var categories = await _apiRepo.GetCategories();

        if(categories is null)
            return Enumerable.Empty<string>();

        return categories.Select(c => c.Name).OrderBy(c => c);
    }

    internal async Task<IEnumerable<Drink>> GetDrinksByCategoryAsync(string category)
    {
        var drinks = await _apiRepo.GetDrinksByCategory(category);

        if (drinks is null)
            return Enumerable.Empty<Drink>();

        return drinks;
    }

    internal async Task<DrinkDetailDto?> GetDrinkByIdAsync(int drinkId)
    {
        var drinkDetails = await _apiRepo.GetDrinkById(drinkId);

        if (drinkDetails is null)
            return null;

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

    private static List<Ingredient> GenerateIngredients(Dictionary<string, JsonElement> additionalInformation)
    {
        List<Ingredient> ingredients = new();

        if (additionalInformation is not null)
        {
            foreach (var key in additionalInformation.Keys)
            {
                if (key.StartsWith("strIngredient"))
                {
                    string? ingredient = additionalInformation[key].GetString();

                    if (!string.IsNullOrEmpty(ingredient))
                    {
                        string measureString = "strMeasure" + key[13..];
                        string measure = additionalInformation[measureString].GetString() ?? "";

                        ingredients.Add(new Ingredient(ingredient, measure));
                    }
                }
            }
        }
        return ingredients;
    }

    internal void InsertOrUpdateDrinkRecord(int drinkId, string drinkName)
    {
        if (!_sqlRepo.DrinkRecordExists(drinkId))
        {
            _sqlRepo.InsertDrinkIntoDb(drinkId, drinkName, DateTime.Now);
        }
        else
        {
            _sqlRepo.UpdateDrinkById(drinkId, $"last_searched = '{DateTime.Now:yyyy/MM/dd hh\\:mm\\:ss}'");
        }
    }

    internal void ToggleDrinkIsFavourite(int drinkId, bool state)
    {
        _sqlRepo.UpdateDrinkById(drinkId, $"saved = {Convert.ToInt32(!state)}");
    }    

    internal bool DrinkIsFavourite(int drinkId)
    {
        return _sqlRepo.DrinkIsFavourite(drinkId);
    }
}
