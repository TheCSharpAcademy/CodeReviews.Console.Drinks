using System.Text.Json.Serialization;

namespace Drinks.K_MYR.Models;

internal record class CategoryResponse
(
    [property: JsonPropertyName("drinks")]
   IEnumerable<Category> Categories
);

internal record class Category
{
    [property: JsonPropertyName("strCategory")]
    public string Name {  get; set; } = string.Empty;
}
