using System.Text.Json.Serialization;

internal record class Drink(
    [property: JsonPropertyName("idDrink")] int Id,
    [property: JsonPropertyName("strDrink")] string Name);
internal record class DrinkResponse(
    [property: JsonPropertyName("drinks")] IEnumerable<Drink> Drinks);