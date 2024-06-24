using System.Text.Json.Serialization;

public record class DrinkRoot(
    [property: JsonPropertyName("drinks")] Drink[] drinks);

public record class Drink(
    [property: JsonPropertyName("strDrink")] string DrinkName,
    [property: JsonPropertyName("idDrink")] string Id)
{
    public string Id { get; set; }
}

