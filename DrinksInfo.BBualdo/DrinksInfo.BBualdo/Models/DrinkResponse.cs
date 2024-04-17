using System.Text.Json.Serialization;

namespace DrinksInfo.BBualdo.Models;

public record class DrinkResponse([property: JsonPropertyName("drinks")] List<Drink> Drinks);