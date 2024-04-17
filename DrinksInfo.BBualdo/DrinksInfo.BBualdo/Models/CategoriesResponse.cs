using System.Text.Json.Serialization;

namespace DrinksInfo.BBualdo.Models;

public record class CategoriesResponse([property: JsonPropertyName("drinks")] List<Category> Categories);