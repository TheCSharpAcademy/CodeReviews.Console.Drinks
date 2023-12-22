using System.Text.Json.Serialization;

namespace Drinks.UgniusFalze;

public record Categories(
    [property: JsonPropertyName("drinks")] List<Category> DrinkCategories);