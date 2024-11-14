using Newtonsoft.Json;

namespace ConsoleDrinks.AnaClos.Models;

public class Drink
{
    [JsonProperty("strDrink")]
    public string StrDrink { get; set; }

    [JsonProperty("idDrink")]
    public int IdDrink { get; set; }
}

public class Drinks
{
    [JsonProperty("drinks")]
    public List<Drink> DrinksList { get; set; }
}