using System.Text.Json;
using System.Text.Json.Serialization;

namespace DrinksInfo.Models;

internal record class DrinkDetailResponse
(
    [property: JsonPropertyName("drinks")]IEnumerable<DrinkDetail> Details
);

internal record DrinkDetail
{
    [JsonPropertyName("strDrink")]
    public string Drink { get; init; } = string.Empty;
    [JsonPropertyName("strCategory")]
    public string Category { get; init; } = string.Empty;
    [JsonPropertyName("strAlcoholic")]
    public string Alcoholic { get; init; } = string.Empty;
    [JsonPropertyName("strGlass")]
    public string Glass { get; init; } = string.Empty;
    [JsonPropertyName("strInstructions")]
    public string Instructions { get; init; } = string.Empty;
    [JsonExtensionData]
    public Dictionary<string, JsonElement> AdditionalInformation { get; init; } = new();
}

internal record DrinkDetailDto
{
    public string Drink { get; init; } = string.Empty;
    public string Category { get; init; } = string.Empty;
    public string Alcoholic { get; init; } = string.Empty;
    public string Glass { get; init; } = string.Empty;
    public string Instructions { get; init; } = string.Empty;
    public IEnumerable<Ingredient>? Ingredients { get; init; }
}

internal record class Ingredient (string Name, string Measurement);
internal record class Drink(
    [property: JsonPropertyName("strDrink")] string drinkName,
    [property: JsonPropertyName("strDrinkThumb")] string drinkThumbUrl,
    [property: JsonPropertyName("idDrink")] int drinkId
);

internal record class DrinkResponse(
    [property: JsonPropertyName("drinks")] IEnumerable<Drink> Drinks
);

