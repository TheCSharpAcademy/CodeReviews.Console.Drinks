using Newtonsoft.Json;

namespace MiroiuDev.DrinksInfo.Models;

public class DrinkDetails
{
    [JsonProperty("drinks")]
    public List<Drink> DrinkDetailsList { get; set; } = new();
}