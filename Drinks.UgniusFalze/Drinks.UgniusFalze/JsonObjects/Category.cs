using System.Text.Json.Serialization;

namespace Drinks.UgniusFalze;

public record Category(
    [property: JsonPropertyName("strCategory")]
    string StrCategory);