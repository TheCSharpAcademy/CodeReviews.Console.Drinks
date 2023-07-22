using Newtonsoft.Json;

namespace Drinks.JsPeanut
{
    class Drink
    {
        public string IdDrink { get; set; }
        public string StrDrink { get; set; }
    }

    class Drinks
    {
        [JsonProperty("drinks")]
        public List<Drink> DrinkList { get; set;}
    }
}
