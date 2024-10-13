using Newtonsoft.Json;

namespace DrinksInfo.Models
{
  public class DrinkInfo
  {
    [JsonProperty("strDrink")]
    public string Name { get; set; }

    [JsonProperty("idDrink")]
    public int DrinkId { get; set; }

    [JsonProperty("strAlcoholic")]
    public string Type { get; set; }

    [JsonProperty("strInstructions")]
    public string Instructions { get; set; }

    [JsonProperty("strGlass")]
    public string Glass { get; set; }

    [JsonProperty("strCategory")]
    public string Category { get; set; }
  }

  public class DrinksInformation
  {
    [JsonProperty("drinks")]
    public List<DrinkInfo> ListDrinksInfo { get; set; } = new List<DrinkInfo>();

  }
}
