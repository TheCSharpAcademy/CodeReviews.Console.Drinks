using System.Text.Json.Serialization;

namespace Kolejarz.Drinks.ConsoleRunner.DTO;

internal record Drink
{
    [JsonPropertyName("strDrink")]
    public string DrinkName { get; set; }

    [JsonPropertyName("strDrinkThumb")]
    public Uri Thumbnail { get; set; }

    [JsonPropertyName("idDrink")]
    public string Id { get; set; }

    public override string ToString() => DrinkName;
}
