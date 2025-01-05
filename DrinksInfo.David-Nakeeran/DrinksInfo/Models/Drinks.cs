using System.Text.Json.Serialization;

namespace DrinksInfo.Models;

internal class Drinks
{
    [JsonPropertyName("drinks")]
    public List<Drink>? DrinkList { get; set; }
}