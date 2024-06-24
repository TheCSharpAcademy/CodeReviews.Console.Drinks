using System.Text.Json.Serialization;

namespace Drinks.UgniusFalze;

public record Drink(
    [property: JsonPropertyName("strDrink")]
        string StrDrink,
    [property: JsonPropertyName("strDrinkThumb")]
        Uri StrDrinkThumb,
    [property: JsonPropertyName("idDrink")]
        int IdDrink
        );