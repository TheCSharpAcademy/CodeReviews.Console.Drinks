using System.Text.Json.Serialization;

namespace DrinksApi.Drinks;

public record class GenericDrinksListDto<T>([property: JsonPropertyName("drinks")] List<T> Drinks) { }