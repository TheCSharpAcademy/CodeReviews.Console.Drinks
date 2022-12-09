using System.Text.Json.Serialization;

namespace drinks_info_console.Models;

public class Drinks
{
    [JsonPropertyName("drinks")]
    public List<Drink>? DrinkList { get; set; }
}
