using System.Text.Json.Serialization;

namespace DrinksConsoleApp;

public record class Drinks(
    [property: JsonPropertyName("drinks")] List<Category> Categories);

