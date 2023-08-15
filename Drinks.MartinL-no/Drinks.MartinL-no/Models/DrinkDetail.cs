using System.Text.Json;
using System.Text.Json.Serialization;

namespace Drinks.MartinL_no.Models;

internal class DrinkDetails
{
    [JsonPropertyName("strDrink")]
    public string Name { get; set; }
    [JsonPropertyName("strCategory")]
    public string Category { get; set; }
    [JsonPropertyName("strAlcoholic")]
    public string Alcoholic { get; set; }
    [JsonPropertyName("strGlass")]
    public string Glass { get; set; }
    [JsonPropertyName("strInstructions")]
    public string Instructions { get; set; }
    [JsonExtensionData]
    public Dictionary<string, JsonElement>? RemainingJsonFields { get; set; }
}

internal record class DrinkDetailsResponse
{
    public IEnumerable<DrinkDetails> Drinks { get; set; }
}
