using Newtonsoft.Json;

namespace MiroiuDev.DrinksInfo.Models
{
    internal class Drinks
    {
        [JsonProperty("drinks")]
        internal List<Drink> DrinksList { get; set; } = new();
    }
}
