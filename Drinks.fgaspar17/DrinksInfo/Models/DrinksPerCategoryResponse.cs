using System.Text.Json.Serialization;

namespace DrinksInfo;

public class DrinksPerCategoryResponse
{
    [property: JsonPropertyName("drinks")]
    public List<Drink>? Drinks { get; set; }
}

public class Drink()
{
    [property: JsonPropertyName("idDrink")]
    public string? Id { get; set; }
    [property: JsonPropertyName("strDrink")]
    public string? Name { get; set; }
    [property: JsonPropertyName("strDrinkThumb")]
    public string? ImageUrl { get; set; }
}