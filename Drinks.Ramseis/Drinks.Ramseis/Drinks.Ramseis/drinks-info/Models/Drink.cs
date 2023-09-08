using Newtonsoft.Json;

namespace Drinks.Ramseis
{
    public class Drinks
    {
        [JsonProperty("drinks")]
        public List<Drink> DrinksList { get; set; } = new();
    }

    public class Drink
    {
        public string idDrink { get; set; } = "";
        public string strDrink { get; set; } = "";
    }
}
