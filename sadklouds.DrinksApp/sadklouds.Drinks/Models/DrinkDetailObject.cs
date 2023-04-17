using System.Text.Json.Serialization;

namespace sadklouds.Drinks.Models
{
    public class DrinkDetailObject
    {
        [JsonPropertyName("drinks")]
        public List<DrinkDetailModel> DrinkDetailList { get; set; }
    }

}
