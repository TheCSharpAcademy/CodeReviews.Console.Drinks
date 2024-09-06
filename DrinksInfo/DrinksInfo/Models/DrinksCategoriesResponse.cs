using System.Text.Json.Serialization;

namespace DrinksInfo;
public class DrinksCategoriesResponse
{
    [property: JsonPropertyName("drinks")]
    public List<DrinkCategory>? DrinkCategories { get; set; }
}

public class DrinkCategory
{
    [property: JsonPropertyName("strCategory")]
    public string? Name { get; set; }
}