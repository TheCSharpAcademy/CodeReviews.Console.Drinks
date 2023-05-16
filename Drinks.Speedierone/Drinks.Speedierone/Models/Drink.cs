using Newtonsoft.Json;

namespace Drinks_List.Models
{
    public class Drinks
    {
        [JsonProperty("drinks")]
        public List<Drink> Drinkslist { get; set; }
    }

    public class Drink
    {
        public string idDrink { get; set;}
        public string strDrink { get; set;}
    }
}
