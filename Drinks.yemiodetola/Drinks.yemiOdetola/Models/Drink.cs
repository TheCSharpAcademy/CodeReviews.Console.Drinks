using Newtonsoft.Json;

namespace Drinks.yemiOdetola.Models;

public class Drink
{
  public string IdDrink { get; set; }
  public string StrDrink { get; set; }
}


public class DrinksList
{
  [JsonProperty("drinks")]
  public List<Drink> DrinksListItems { get; set; }
}