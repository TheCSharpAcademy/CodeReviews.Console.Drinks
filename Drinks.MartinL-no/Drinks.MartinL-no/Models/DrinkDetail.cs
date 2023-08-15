using System.Text.Json.Serialization;

namespace Drinks.MartinL_no.Models;

internal record class DrinkDetail(
    [property: JsonPropertyName("strDrink")] string Name,
    [property: JsonPropertyName("strCategory")] string Category,
    [property: JsonPropertyName("strAlcoholic")] string Alcoholic,
    [property: JsonPropertyName("strGlass")] string Glass,
    [property: JsonPropertyName("strInstructions")] string Instructions
    );

internal record class DrinkDetailsResponse
{
    public List<DrinkDetail> drinks { get; set; }
}
