using System.Text.Json.Serialization;

namespace DrinksApi.Categories;

public record class CategoryListDto([property: JsonPropertyName("drinks")] List<CategoryDto> Drinks)
{ }

