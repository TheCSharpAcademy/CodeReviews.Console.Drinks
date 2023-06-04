using Newtonsoft.Json;

namespace DrinksInfo
{
    public class DrinkModel
    {
        public string strDrink { get; set; }

        public string strAlcoholic { get; set; }

        public string strGlass { get; set; }

        public string strInstructions { get; set; }

    }

    public class DrinkInformation
    {
        [JsonProperty("drinks")]

        public List<DrinkModel> DrinkModel { get; set; }
    }
}
