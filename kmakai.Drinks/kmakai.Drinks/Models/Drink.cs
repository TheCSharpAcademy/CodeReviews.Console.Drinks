
using Newtonsoft.Json;

namespace kmakai.Drinks.Models;

public class Drink
{
    [JsonProperty("idDrink")]
    public string IdDrink { get; set; }

    [JsonProperty("strDrink")]
    public string StrDrink { get; set; }
}

public class DrinksList
{
    [JsonProperty("drinks")]
    public List<Drink> Drinks { get; set; }
}