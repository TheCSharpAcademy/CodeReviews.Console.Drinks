using System.Text.Json.Serialization;

namespace DrinksConsoleApp;

public record class DrinkCategory(
    [property: JsonPropertyName("drinks")] List<CategoryDetail> Categories);

