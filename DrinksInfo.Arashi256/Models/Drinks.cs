using Newtonsoft.Json;

namespace DrinksInfo.Arashi256.Models
{
    internal class Drinks
    {
        [JsonProperty("drinks")]
        public List<Drink> DrinksList { get; set; }
    }
}
