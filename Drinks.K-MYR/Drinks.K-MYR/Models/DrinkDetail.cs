using System.Text.Json;
using System.Text.Json.Serialization;

namespace Drinks.K_MYR.Models;


internal record class DrinkDetailResponse
(
    [property: JsonPropertyName("drinks")]
    IEnumerable<DrinkDetail> DrinkDetails
);

internal class DrinkDetail
{
    [JsonPropertyName("strDrink")]
    public string Drink { get; set; } = string.Empty;
    [JsonPropertyName("strCategory")]
    public string Category { get; set; } = string.Empty;
    [JsonPropertyName("strTags")]
    public string Tags { get; set; } = string.Empty;
    [JsonPropertyName("strAlcoholic")]
    public string Alcohlic { get; set; } = string.Empty;
    [JsonPropertyName("strGlass")]
    public string Glass { get; set; } = string.Empty;
    [JsonPropertyName("strInstructions")]
    public string Instructions { get; set; } = string.Empty;
    [JsonExtensionData]
    public Dictionary<string, JsonElement> AdditionalInformation { get; set; } = new();
}

internal class DrinkDetailDto
{
    public string Drink { get; set; } = string.Empty;

    public string Category { get; set; } = string.Empty;

    public string Tags { get; set; } = string.Empty;

    public string Alcohlic { get; set; } = string.Empty;

    public string Glass { get; set; } = string.Empty;

    public string Instructions { get; set; } = string.Empty;

    public List<Ingredient> Ingredients { get; set; } = new();
}
