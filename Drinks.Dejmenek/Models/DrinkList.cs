using System.Text.Json.Serialization;

namespace Drinks.Dejmenek.Models
{
    public class DrinkList
    {
        [JsonPropertyName("drinks")]
        public List<Drink>? Drinks { get; set; }
    }
}
