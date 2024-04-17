using System.Text.Json.Serialization;

namespace DrinksInfo.BBualdo.Models;

public record class Drink(
  [property: JsonPropertyName("strDrink")] string Name,
  [property: JsonPropertyName("strAlcoholic")] string Type,
  [property: JsonPropertyName("strInstructions")] string Instructions
  )
{
}