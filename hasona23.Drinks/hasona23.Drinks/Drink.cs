
using System.Text.Json.Serialization;
namespace hasona23.Drinks;

public class DrinksResponse
{
    [JsonPropertyName("drinks")]
    public List<Drink>? Drinks { get; set; }
}

public record  Drink(
        [property: JsonPropertyName("strDrink")] string Name,
        [property: JsonPropertyName("strCategory")] string Category,
        [property: JsonPropertyName("strIngredient1")] string? Ingredient1,
        [property: JsonPropertyName("strIngredient2")] string? Ingredient2,
        [property: JsonPropertyName("strIngredient3")] string? Ingredient3,
        [property: JsonPropertyName("strIngredient4")] string? Ingredient4,
        [property: JsonPropertyName("strIngredient5")] string? Ingredient5,
        [property: JsonPropertyName("strIngredient6")] string? Ingredient6,
        [property: JsonPropertyName("strIngredient7")] string? Ingredient7,
        [property: JsonPropertyName("strIngredient8")] string? Ingredient8,
        [property: JsonPropertyName("strIngredient9")] string? Ingredient9,
        [property: JsonPropertyName("strIngredient10")] string? Ingredient10,
        [property: JsonPropertyName("strIngredient11")] string? Ingredient11,
        [property: JsonPropertyName("strIngredient12")] string? Ingredient12,
        [property: JsonPropertyName("strIngredient13")] string? Ingredient13,
        [property: JsonPropertyName("strIngredient14")] string? Ingredient14,
        [property: JsonPropertyName("strIngredient15")] string? Ingredient15
    )
{
    // Method to collect all non-null ingredients into a list
    public override string ToString()
    {
        return this.Name;
    }
    public IEnumerable<string> GetIngredients()
    {
        var ingredients = new List<string?>
            {
                Ingredient1, Ingredient2, Ingredient3, Ingredient4, Ingredient5,
                Ingredient6, Ingredient7, Ingredient8, Ingredient9, Ingredient10,
                Ingredient11, Ingredient12, Ingredient13, Ingredient14, Ingredient15
            };

        // Return only the non-null ingredients
        return ingredients.Where(i => !string.IsNullOrEmpty(i))!;
    }
}