namespace TheCocktailDb;

using System.Text.Json.Serialization;

public record class Category(
    [property: JsonPropertyName("strCategory")] string Name);