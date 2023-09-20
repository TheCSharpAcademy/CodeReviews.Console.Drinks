using Newtonsoft.Json;

namespace Drinks.j_nas.Models
{
    public class Drink
    {
        [JsonProperty("idDrink")]
        public string IdDrink { get; set; }
        [JsonProperty("strDrink")]
        public string StrDrink { get; set;}
    }

    public class DrinkList
    {
        [JsonProperty("drinks")]
        public List<Drink> Drinks { get; set; }
    }
}
