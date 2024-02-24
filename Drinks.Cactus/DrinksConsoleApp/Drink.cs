using System.Text.Json.Serialization;

namespace DrinksConsoleApp;

public record class Drink(
    [property: JsonPropertyName("strDrink")] string Name,
    [property: JsonPropertyName("idDrink")] string Id);

