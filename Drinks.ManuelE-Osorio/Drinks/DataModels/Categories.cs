using System.Text.Json.Serialization;

namespace DrinksProgram;
public record CategoriesJSON(
    [property:JsonPropertyName("drinks")] List<Categories> Categories);

public record class Categories(
    [property: JsonPropertyName("strCategory")] string Category);