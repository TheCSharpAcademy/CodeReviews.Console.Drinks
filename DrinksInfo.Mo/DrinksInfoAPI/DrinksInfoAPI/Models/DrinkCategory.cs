using System.Text.Json.Serialization;

public class DrinkCategory
{
    [JsonPropertyName("strCategory")]
    public string? StrCategory { get; set; }
}
