using Newtonsoft.Json;

namespace MiroiuDev.DrinksInfo.Models;

internal class DrinkDetails
{
    [JsonProperty("drinks")]
    internal List<DrinkDetail> DrinkDetailsList { get; set; } = new();
}