using System.Text.Json.Serialization;

namespace DrinksInfo.Models;

internal class DrinksDetails
{
    [JsonPropertyName("drinks")]
    public List<DrinkDetail>? DrinkDetailList { get; set; }
}