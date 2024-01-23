using System.Text.Json.Serialization;

namespace DrinksInfo.Model
{
    internal record class DrinkMenuItem([property: JsonPropertyName("strDrink")] string Name, [property: JsonPropertyName("idDrink")] string ID);
}
