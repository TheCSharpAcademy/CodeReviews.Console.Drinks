using System.Text.Json.Serialization;

namespace drinks_info_console.Models;

public class Categories
{
    [JsonPropertyName("drinks")]
    public List<Category>? CategoryList { get; set; }
}
