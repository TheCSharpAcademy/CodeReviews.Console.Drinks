using System.Text.Json.Serialization;

namespace DrinksInfo;

public class CategoryResponse
{
    [JsonPropertyName("drinks")]
    public List<Category> Categories { get; set; }
}
