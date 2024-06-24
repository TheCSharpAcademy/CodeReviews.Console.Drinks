using System.Text.Json.Serialization;

namespace DrinksApi.Drinks;
public record class DrinksFilterListDto([property: JsonPropertyName("drinks")] List<DrinkListItemDto> Drinks)
{ }

