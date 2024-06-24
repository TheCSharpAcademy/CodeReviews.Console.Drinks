using System.Text.Json.Serialization;

namespace Drinks.UgniusFalze;

public record DrinkDetailsRecord(
    [property:JsonPropertyName("drinks")]
    List<DrinkDetails> DrinkDetailsList);