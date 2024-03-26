using System.Text.Json.Serialization;

namespace Drinks;

public class Category
{
    [property: JsonPropertyName("strCategory")]
    public required string Name { get; set; }
}

public class CategoryResponse
{
    [property: JsonPropertyName("drinks")]
    public List<Category> Categories { get; set; } = [];
}