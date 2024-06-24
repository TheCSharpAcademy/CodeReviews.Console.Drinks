using System.Text.Json.Serialization;

namespace DrinksApi.Categories;

public record class CategoryDto([property: JsonPropertyName("strCategory")] string StrCategory)
{
    public override string ToString()
    {
        return StrCategory;
    }
}