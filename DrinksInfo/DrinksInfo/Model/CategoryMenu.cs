using System.Text.Json.Serialization;

namespace DrinksInfo.Model;

internal record class CategoryMenu([property: JsonPropertyName("drinks")] List<Category> Categories);
