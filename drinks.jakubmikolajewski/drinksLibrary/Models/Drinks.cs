using System.Text.Json.Serialization;

namespace drinksLibrary.Models;

public record class Drinks(
    [property: JsonPropertyName("drinks")] List<Drink> DrinkList);

public record class Drink (
    [property: JsonPropertyName("strDrink")] string DrinkName,
    [property: JsonPropertyName("idDrink")] int DrinkId);
