using System.Text.Json.Serialization;

namespace DrinksInfo.Models;

internal class Drink
{
    [JsonPropertyName("idDrink")]
    public string? DrinkId { get; set; }

    [JsonPropertyName("strDrink")]
    public string? Name { get; set; }

}