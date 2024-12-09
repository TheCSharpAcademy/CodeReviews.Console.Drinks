using Newtonsoft.Json;

namespace DrinksProject.Models
{
    public class Drinks
    {
        [JsonProperty("drinks")]
        public List<Drink> DrinksList { get; set; }
    }
    public class Drink
    {
        [JsonProperty("idDrink")]
        public string IdDrink { get; set; }
        [JsonProperty("strDrink")]
        public string StrDrink { get; set; }

    }

}
