using System.Text.Json.Serialization;

namespace DrinksInfo.Models;

public class Drink
{
    public string idDrink { get; set; }
    public string strDrink { get; set; }
}

public class Drinks
{
    [JsonPropertyName("drinks")]
    public List<Drink> DrinksList { get; set; }
}