using Newtonsoft.Json;

namespace DrinksInfo.Models;

public class Drink
{
    [JsonProperty("idDrink")] public int IdDrink { get; set; }
    [JsonProperty("strDrink")] public string StrDrink { get; set; }
}

public class DrinksList
{
    [JsonProperty("drinks")] public List<Drink> AllDrinks { get; set; }
}