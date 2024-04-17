using System.Text.Json.Serialization;

namespace DrinksInfo.BBualdo.Models;

public record class Category([property: JsonPropertyName("strCategory")] string Name);