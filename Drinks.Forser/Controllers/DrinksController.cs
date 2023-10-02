using System.Text.Json;

internal class DrinksController
{
    private DrinksApiAccess _apiRepo;

    public DrinksController(DrinksApiAccess apiRepo)
    {
        _apiRepo = apiRepo;
    }
    public async Task<IEnumerable<string>> GetCategories()
    {
        var categories = await _apiRepo.GetCategories();

        return categories.Select(c => c.Name);
    }
    public async Task<IEnumerable<Drink>> GetDrinksByCategory(string category)
    {
        var categories = await _apiRepo.GetDrinksByCategory(category);

        return categories;
    }
    internal async Task<DrinkDetailsDto> GetDrinkById(int drinkId)
    {
        var drinkDetails = await _apiRepo.GetDrinkById(drinkId);

        return new DrinkDetailsDto()
        {
            Name = drinkDetails.DrinkName,
            Alcoholic = drinkDetails.Alcoholic,
            Category = drinkDetails.Category,
            Glass = drinkDetails.Glass,
            Ingredients = GenerateIngredientList(drinkDetails.RemainingApiFields),
            Instructions = drinkDetails.Instructions
        };
    }
    private List<Ingredient> GenerateIngredientList(Dictionary<string, JsonElement>? remainingApiFields)
    {
        var ingredients = new List<Ingredient>();

        var measures = remainingApiFields
            .Where(m => m.Key.StartsWith("strMeasure"))
            .Where(m => m.Value.ValueKind != JsonValueKind.Null)
            .Select(m => new string[] { m.Key.Substring(10), m.Value.GetString() });

        var ingredientsNamesWithMeasures = remainingApiFields
            .Where(i => i.Key.StartsWith("strIngredient"))
            .Where(i => i.Value.ValueKind != JsonValueKind.Null)
            .Select(i => new string[] { i.Key.Substring(13), i.Value.GetString() })
            .Union(measures)
            .GroupBy(pair => pair[0])
            .Select(group => new
            {
                Id = group.Key,
                IngredientDetails = group.Select(g => g[1]).ToList()
            })
            .Where(group => group.IngredientDetails[0] != "");

        foreach (var group in ingredientsNamesWithMeasures)
        {
            var name = group.IngredientDetails[0];
            var measure = group.IngredientDetails.Count() == 2 ? group.IngredientDetails[1] : "";
            ingredients.Add(new Ingredient(name, measure));
        }

        return ingredients;
    }
}