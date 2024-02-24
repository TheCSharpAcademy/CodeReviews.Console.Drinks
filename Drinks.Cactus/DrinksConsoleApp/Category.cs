using System.Text.Json.Serialization;

namespace DrinksConsoleApp;

public record class Category(
    [property: JsonPropertyName("strCategory")] string Name);

