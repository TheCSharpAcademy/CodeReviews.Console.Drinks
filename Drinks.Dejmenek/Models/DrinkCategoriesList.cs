using System.Text.Json.Serialization;

namespace Drinks.Dejmenek.Models
{
    public class DrinkCategoriesList
    {
        [JsonPropertyName("drinks")]
        public List<DrinkCategory>? DrinkCategories { get; set; }
    }
}
