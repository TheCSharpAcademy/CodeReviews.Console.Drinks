using System.Text.Json;
using System.Text.Json.Serialization;

namespace Drinks.kwm0304.Models;

public class DrinkDetail
{
  [JsonPropertyName("strDrink")]
  public string? Name { get; set; }

  [JsonPropertyName("strTags")]
  public string? Tags { get; set; }

  [JsonPropertyName("strInstructions")]
  public string? Instructions { get; set; }

  [JsonPropertyName("strCategory")]
  public string? Category { get; set; }

  [JsonPropertyName("strIBA")]
  public string? Iba { get; set; }

  [JsonPropertyName("strAlcoholic")]
  public string? Alcoholic { get; set; }

  [JsonPropertyName("strGlass")]
  public string? Glass { get; set; }

  [JsonIgnore]
  public List<string> Ingredients { get; set; } = new List<string>();

  [JsonIgnore]
  public List<string> Measures { get; set; } = new List<string>();

  [JsonExtensionData]
  public Dictionary<string, JsonElement>? AdditionalProperties { get; set; }
}