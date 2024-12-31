using Newtonsoft.Json;

namespace Drinks.iamnikitakostin.Models;

public class Drinks
{
    [JsonProperty("drinks")]
    public List<Drink> DrinksList { get; set; }
}

public class Drink
{
    public string idDrink { get; set; }
    public string strDrink { get; set; }
}