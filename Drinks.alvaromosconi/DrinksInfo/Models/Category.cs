using System.Text.Json.Serialization;

namespace DrinksInfo.Models;
internal record class Category(
    [property: JsonPropertyName("strCategory")] string Name
);

internal record class CategoryResponse(
    [property: JsonPropertyName("drinks")] IEnumerable<Category> Categories
);