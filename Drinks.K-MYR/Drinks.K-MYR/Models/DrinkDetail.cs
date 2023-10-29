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
    public string Drink { get; set; }
    [JsonPropertyName("strCategory")]
    public string Category { get; set; }
    [JsonPropertyName("strTags")]
    public string Tags { get; set; }
    [JsonPropertyName("strAlcoholic")]
    public string Alcohlic { get; set; }
    [JsonPropertyName("strGlass")]
    public string Glass { get; set; }
    [JsonPropertyName("strInstructions")]
    public string Instructions { get; set; }
    [JsonExtensionData]
    public Dictionary<string, JsonElement>? AdditionalInformation { get; set; }
}

internal class DrinkDetailDto
{
    public string Drink { get; set; }

    public string Category { get; set; }

    public string Tags { get; set; }

    public string Alcohlic { get; set; }

    public string Glass { get; set; }

    public string Instructions { get; set; }

    public List<Ingredient> Ingredients { get; set; }
}

