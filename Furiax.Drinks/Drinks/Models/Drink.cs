using Newtonsoft.Json;

namespace Drinks_Info.Models
{
	internal class Drink
	{
        public string idDrink { get; set; }
        public string strDrink { get; set; }
    }
	internal class Drinkss
	{
        [JsonProperty("drinks")]
        public List<Drink>DrinksList { get; set; }
    }
}
