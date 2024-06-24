using System.Text.Json.Serialization;

    internal record class Category(
        [property: JsonPropertyName("strCategory")] string Name);

    internal record class CategoryResponse(
        [property: JsonPropertyName("drinks")] IEnumerable<Category> Categories);