using Newtonsoft.Json;

namespace Drinks_Info.Models
{
    public class Drink
    {
        public int IdDrink { get; set; } = 0;
        public string StrDrink { get; set; } = "";
    }

    public class Drinks
    {
        [JsonProperty("drinks")]
        public List<Drink> DrinkList { get; set; } = [];
    }
}