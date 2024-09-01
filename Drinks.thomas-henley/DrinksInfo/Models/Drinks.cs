using Newtonsoft.Json;

namespace DrinksInfo.Models;

public class Drinks
{
    [JsonProperty("drinks")]
    public required List<Drink> DrinksList { get; set; }
}

public class Drink
{
    [JsonProperty("idDrink")]
    public required string Id { get; set; }
    
    [JsonProperty("strDrink")]
    public required string Name { get; set; }
}