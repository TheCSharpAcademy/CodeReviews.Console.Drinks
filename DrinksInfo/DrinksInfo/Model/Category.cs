using System.Text.Json.Serialization;

namespace DrinksInfo.Model;

internal record class Category([property: JsonPropertyName("strCategory")] string Name);
