using System.Text.Json.Serialization;

namespace Drinks.kwm0304.Models;

public class DrinkResponse<T> where T : class
{
  [JsonPropertyName("drinks")]
  public List<T>? Drinks { get; set; }
}