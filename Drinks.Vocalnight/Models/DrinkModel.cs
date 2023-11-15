using Newtonsoft.Json;

namespace DrinksInfo
{
    public class DrinkModel
    {
        public string StrDrink { get; set; }

        public string StrAlcoholic { get; set; }

        public string StrGlass { get; set; }

        public string StrInstructions { get; set; }

    }

    public class DrinkInformation
    {
        [JsonProperty("drinks")]

        public List<DrinkModel> DrinkModel { get; set; }
    }
}
