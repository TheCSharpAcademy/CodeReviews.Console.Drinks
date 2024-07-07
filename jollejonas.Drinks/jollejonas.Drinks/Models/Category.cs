using System.Text.Json.Serialization;

namespace jollejonas.Drinks.Models;

public class Category
{
    [JsonPropertyName("strCategory")]
    public string StrCategory { get; set; }
}
