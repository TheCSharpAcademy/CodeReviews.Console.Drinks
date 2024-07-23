using Newtonsoft.Json;

namespace Drinks.kjanos89.Models;

public class DrinksClass
{
    [JsonProperty("drinks")]
    public List<Drink> DrinkList { get; set; }
}