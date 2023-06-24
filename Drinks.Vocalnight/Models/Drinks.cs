using Newtonsoft.Json;

namespace DrinksInfo
{

    public class Drink : IDrinksJson
    {
        public string StrDrink { get; set; }

        public string GetName()
        {
            return this.StrDrink;
        }

        public void ChangeName(string name)
        {
            this.StrDrink = name;
        }

    }
    public class Drinks
    {
        [JsonProperty("drinks")]

        public List<Drink> DrinksList { get; set; } 
    }
}
