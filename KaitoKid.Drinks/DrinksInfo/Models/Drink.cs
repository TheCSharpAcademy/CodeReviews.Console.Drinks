using Newtonsoft.Json;

namespace DrinksInfo.Models
{
    public class Drink
    {
        public string IdDrink {  get; set; }
        public string StrDrink { get; set; }
    }

    public class Drinks
    {
        [JsonProperty("drinks")]
        public List<Drink> DrinkList { get; set; }
    }

}
