using Newtonsoft.Json;

namespace DrinksInfo.Models
{
    internal class Drinks
    {
        [JsonProperty("drinks")]

        public List<Drink> DrinkList { get; set; }
    }
}
