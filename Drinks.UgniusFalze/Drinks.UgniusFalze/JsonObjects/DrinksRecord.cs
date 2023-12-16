using System.Text.Json.Serialization;

namespace Drinks.UgniusFalze;

public record DrinksRecord(
    [property: JsonPropertyName("drinks")]
    List<Drink> Drinks);