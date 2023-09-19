using Newtonsoft.Json;

namespace MiroiuDev.DrinksInfo.Models
{
    public class Drinks
    {
        [JsonProperty("drinks")]
        public List<Drink> DrinksList { get; set; } = new();
    }
}
