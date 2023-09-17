namespace TheCocktailDb;

using System.Text.Json.Serialization;

public record class Drink(
    [property: JsonPropertyName("idDrink")] string Id,
    [property: JsonPropertyName("strDrink")] string Name);
