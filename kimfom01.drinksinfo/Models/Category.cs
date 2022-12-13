using System.Text.Json.Serialization;

namespace drinks_info_console.Models;

public class Category
{
    [JsonPropertyName("strCategory")]
    public string? CategoryName { get; set; }
}