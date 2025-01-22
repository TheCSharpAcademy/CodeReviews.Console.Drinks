using System.Text.Json.Serialization;

namespace Drinks.AshtonLeeSeloka.Repositories;

public record class Categories([property: JsonPropertyName("strCategory")] string Category)
{
}
