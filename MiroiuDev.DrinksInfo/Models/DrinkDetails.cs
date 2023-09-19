using Newtonsoft.Json;

namespace MiroiuDev.DrinksInfo.Models;

public class DrinkDetails
{
    [JsonProperty("drinks")]
    public List<DrinkDetail> DrinkDetailsList { get; set; } = new();
}