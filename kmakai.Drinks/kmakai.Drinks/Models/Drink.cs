
using Newtonsoft.Json;

namespace kmakai.Drinks.Models;

public class Drink
{
    public string idDrink { get; set; }
    public string strDrink { get; set; }
}

public class DrinksList
{
    [JsonProperty("drinks")]
    public List<Drink> drinks { get; set; }
}