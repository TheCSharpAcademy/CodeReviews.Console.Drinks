using System.Text.Json.Serialization;

namespace DrinksInfo.BBualdo.Models;

public record class DrinksResponse([property: JsonPropertyName("drinks")] List<Drinks> Drinks);