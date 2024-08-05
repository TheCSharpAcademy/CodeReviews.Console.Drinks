using Newtonsoft.Json;

namespace DrinksInfo.Arashi256.Models
{
    internal class DrinkDetailObject
    {
        [JsonProperty("drinks")]
        public List<DrinkDetail> DrinkDetailList { get; set; }
    }
}
