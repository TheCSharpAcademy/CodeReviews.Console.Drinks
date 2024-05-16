using Newtonsoft.Json;

namespace DrinksInfo.Models;

public class Drinks
{
    [JsonProperty("drinks")]
    public List<Drink>? DrinksList { get; set; }
}

public class Drink
{
    public string? IdDrink { get; set; }
    public string? StrDrink { get; set; }
}
