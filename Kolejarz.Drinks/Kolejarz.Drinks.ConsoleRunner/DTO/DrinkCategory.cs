using System.Text.Json.Serialization;

namespace Kolejarz.Drinks.ConsoleRunner.DTO;

internal record DrinkCategory
{
    [JsonPropertyName("strCategory")]
    public string CategoryName { get; set; }

    public override string ToString() => CategoryName;
}
