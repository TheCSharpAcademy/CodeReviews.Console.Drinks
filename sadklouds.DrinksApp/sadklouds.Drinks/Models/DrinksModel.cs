using System.Text.Json.Serialization;

namespace sadklouds.Drinks.Models
{

    public class DrinksModel
    {
        [JsonPropertyName("drinks")]
        public List<DrinkModel> DrinksList { get; set; }
    }

}
