using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace DrinksInfo.Models
{
  public class Drink
  {
    [JsonProperty("strDrink")]
    public string Name { get; set; }

    [JsonProperty("idDrink")]
    public int DrinkId { get; set; }
  }

  public class Drinks
  {
    [JsonProperty("drinks")]
    public List<Drink> DrinksList { get; set; } = new List<Drink>();
  }
}
