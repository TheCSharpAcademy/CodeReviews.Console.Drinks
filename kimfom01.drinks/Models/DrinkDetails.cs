using System.Text.Json.Serialization;

namespace drinks_info_console.Models;

public class DrinkDetails
{
    [JsonPropertyName("drinks")]
    public List<DrinkDetail>? DrinkDetailList { get; set; }
}
