using System.Text.Json.Serialization;

namespace DrinksConsoleApp;

public record class DrinkCategories(
    [property: JsonPropertyName("drinks")] List<Category> Categories);

