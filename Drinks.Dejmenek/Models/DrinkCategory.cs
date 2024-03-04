using System.Text.Json.Serialization;

namespace Drinks.Dejmenek.Models
{
    public class DrinkCategory
    {
        [JsonPropertyName("strCategory")]
        public string StrCategory { get; set; }
    }
}
