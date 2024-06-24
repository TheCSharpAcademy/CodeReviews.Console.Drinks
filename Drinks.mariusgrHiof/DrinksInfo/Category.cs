using System.Text.Json.Serialization;

namespace DrinksInfo;

public class Category
{
    [JsonPropertyName("strCategory")]
    public string CategoryName { get; set; }
}

