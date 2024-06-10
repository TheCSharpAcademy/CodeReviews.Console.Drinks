using System.Text.Json.Serialization;

namespace Drinks.Models;

public class Drink
{
    public string idDrink { get; set; }
    public string strDrink { get; set; }
}

public class DrinksResponse
{
    [property: JsonPropertyName("drinks")]
    public List<Drink> Drinks { get; set; } = new();
}