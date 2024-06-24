using System.Text.Json.Serialization;

namespace DrinksApi.Drinks;

public record class DrinkListItemDto(
    [property: JsonPropertyName("idDrink")] string IdDrink,
    [property: JsonPropertyName("strDrink")] string Name,
    [property: JsonPropertyName("strDrinkThumb")] string ThumbnailUrl
    )
{ }