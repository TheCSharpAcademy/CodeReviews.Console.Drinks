using DrinksInfo.Models;
using System.Text.Json;

namespace DrinksInfo.Controllers;

internal class DrinksController : IDrinksController
{
    private IDrinksInfoClient _client;
    public DrinksController(IDrinksInfoClient client)
    {
        _client = client;
    }

    public async Task<IEnumerable<Category>> GetCategories()
    {
        return await _client.GetCategories();
    }

    public async Task<IEnumerable<Drink>> GetDrinksByCategory(string category)
    {
        var formattedCategory = category.Replace(" ", "_");
        return await _client.GetDrinksByCategory(formattedCategory);
    }

    public async Task<DrinkDetailDto> GetDrinkInfoById(int drinkId)
    {
        DrinkDetail detail = await _client.GetDrinkInfoById(drinkId);

        return new DrinkDetailDto()
        {
            Drink = detail.Drink,
            Category = detail.Category,
            Alcoholic = detail.Alcoholic,
            Glass = detail.Glass,
            Instructions = detail.Instructions,
            Ingredients = GenerateIngredientsList(detail.AdditionalInformation)
        };
    }

    private IEnumerable<Ingredient> GenerateIngredientsList(Dictionary<string, JsonElement> additionalInformation)
    {
        List<Ingredient> ingredients = new();

        foreach (var key in additionalInformation.Keys)
        {
            if (key.StartsWith("strIngredient"))
            {
                char ingredientNumber = key[key.Length - 1];
                string ingredientName = additionalInformation[key].GetString();

                if (ingredientName != null)
                {
                    string measureKey = $"strMeasure{ingredientNumber}";
                    string measureValue = additionalInformation.ContainsKey(measureKey) ? additionalInformation[measureKey].GetString() : null;

                    ingredients.Add(new Ingredient(ingredientName, measureValue));
                }
            }
        }

        return ingredients;
    }

}
