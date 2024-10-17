using System.Text.Json.Serialization;

namespace hasona23.Drinks
{
    public class CategoryResponse
    {
        [JsonPropertyName("drinks")]
        public List<DrinkCategory>? Categories { get; set; }
    }
    public record DrinkCategory([property: JsonPropertyName("strCategory")] string Category);
}
