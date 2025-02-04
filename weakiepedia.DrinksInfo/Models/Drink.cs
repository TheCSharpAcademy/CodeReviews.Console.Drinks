using Newtonsoft.Json;

namespace DrinksInfo.Models;

public class Drink
{
    [JsonProperty("strDrink")]
    public string DrinkName { get; set; }
    [JsonProperty("idDrink")]
    public string DrinkId { get; set; }
}
    
public class Drinks
{
    [JsonProperty("drinks")]
    public List<Drink> DrinksList { get; set; }
}