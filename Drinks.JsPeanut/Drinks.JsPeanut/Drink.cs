using Newtonsoft.Json;

namespace Drinks.JsPeanut
{
    class Drink
    {
        public string idDrink { get; set; }
        public string strDrink { get; set; }
    }

    class Drinks
    {
        [JsonProperty("drinks")]
        public List<Drink> drinkList { get; set;}
    }
}
