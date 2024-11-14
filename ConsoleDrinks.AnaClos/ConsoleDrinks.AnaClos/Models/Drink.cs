using Newtonsoft.Json;

namespace ConsoleDrinks.AnaClos.Models;

public class Drink
{
    public string strDrink { get; set; }
    public int idDrink { get; set; }
}

public class Drinks
{
    [JsonProperty("drinks")]
    public List<Drink> DrinksList { get; set; }
}