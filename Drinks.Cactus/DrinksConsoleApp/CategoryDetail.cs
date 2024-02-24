using System.Text.Json.Serialization;

namespace DrinksConsoleApp;

public record class CategoryDetail(
    [property: JsonPropertyName("strCategory")] string Name);

