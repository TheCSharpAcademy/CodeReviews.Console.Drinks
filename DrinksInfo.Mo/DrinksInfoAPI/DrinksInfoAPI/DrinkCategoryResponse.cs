using System.Text.Json.Serialization;

public class DrinkCategoryResponse
{
    [JsonPropertyName("drinks")]
    public List<DrinkCategory> Drinks { get; set; } 
}