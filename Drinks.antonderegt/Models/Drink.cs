using System.Text.Json.Serialization;

namespace Drinks.Models;

public class Drink
{
    [property: JsonPropertyName("strDrink")]
    public required string Name { get; set; }
    [property: JsonPropertyName("strDrinkThumb")]
    public required string Thumbnail { get; set; }
    [property: JsonPropertyName("idDrink")]
    public required string Id { get; set; }
}

public class DrinksResponse
{
    [property: JsonPropertyName("drinks")]
    public List<Drink> Drinks { get; set; } = [];
}