using System.Text.Json.Serialization;

namespace Drinks.Models;

public class DrinkCategory
{
    public string strCategory { get; set; }
}

public class DrinkCategoriesResponse
{
    [JsonPropertyName("drinks")]
    public List<DrinkCategory> Drinks { get; set; } = new();
}