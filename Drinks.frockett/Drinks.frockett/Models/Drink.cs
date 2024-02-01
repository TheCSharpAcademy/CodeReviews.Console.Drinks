using Newtonsoft.Json;

namespace Drinks.frockett.Models
{
    public class DrinksL
    {
        [JsonProperty("drinks")]
        public List<Drink> DrinksList { get; set; }
    }

    public class Drink
    {
        public string IdDrink {  get; set; }
        public string StrDrink { get; set; }
    }
}
