using System.Text.Json.Serialization;

namespace DrinksProgram;
public record DrinksByCategoryJSON(
    [property:JsonPropertyName("drinks")] List<DrinksByCategory> Drinks);

public record class DrinksByCategory(
    [property: JsonPropertyName("idDrink"),] string ID,
    [property: JsonPropertyName("strDrink")] string? DrinkName);