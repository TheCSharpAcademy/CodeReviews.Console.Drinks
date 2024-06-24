using System.Text.Json.Serialization;

namespace DrinksInfo;

public class DrinkResponse
{
    [JsonPropertyName("drinks")]
    public List<Drink> Drinks { get; set; }
}

