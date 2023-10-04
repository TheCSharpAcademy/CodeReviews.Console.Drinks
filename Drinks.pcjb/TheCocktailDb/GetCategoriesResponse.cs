namespace TheCocktailDb;

using System.Text.Json.Serialization;

public record class GetCategoriesResponse(
    [property: JsonPropertyName("drinks")] List<Category> Categories);