using System.Text.Json.Serialization;

namespace DrinksInfo.BBualdo.Models;

public record class Drinks([property: JsonPropertyName("idDrink")] string Id, [property: JsonPropertyName("strDrink")] string Name);