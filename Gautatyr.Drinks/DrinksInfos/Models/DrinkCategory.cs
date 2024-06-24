using System.Text.Json.Serialization;

public record class CategoriesRoot(
    [property: JsonPropertyName("drinks")] Categories[] Categories);

public record class Categories([property: JsonPropertyName("strCategory")] string CategoryName)
{
    public int Id { get; set; }
}

