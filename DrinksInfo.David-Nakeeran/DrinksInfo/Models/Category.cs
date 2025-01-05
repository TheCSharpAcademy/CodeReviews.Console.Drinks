using System.Text.Json.Serialization;

namespace DrinksInfo.Models;

internal class Category
{
    [JsonPropertyName("strCategory")]
    public string? Name { get; set; }
}