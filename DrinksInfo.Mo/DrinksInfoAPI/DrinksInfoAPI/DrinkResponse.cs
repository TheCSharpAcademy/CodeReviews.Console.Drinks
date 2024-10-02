using System.Text.Json.Serialization;

public class DrinkResponse
{
    [JsonPropertyName("drinks")]
    public List<Drink> Drinks { get; set; }
}