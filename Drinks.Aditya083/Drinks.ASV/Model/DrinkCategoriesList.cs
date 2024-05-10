using System.Text.Json.Serialization;

namespace Drinks.ASV.Model;

public class DrinkCategoriesList
{
    public struct DrinkCategory
    {
        public string strCategory { get; set; }
    }
    [JsonPropertyName("drinks")]
    public List<DrinkCategory> ?DrinkTypes { get; set; }
}