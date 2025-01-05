using System.Text.Json.Serialization;

namespace DrinksInfo.Models;

internal class Categories
{
    [JsonPropertyName("drinks")] //Exact property name from JSON response
    public List<Category>? CategoriesList { get; set; }
}
