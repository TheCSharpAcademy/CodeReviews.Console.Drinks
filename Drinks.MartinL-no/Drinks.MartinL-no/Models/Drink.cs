using System.Text.Json.Serialization;

namespace Drinks.MartinL_no.Models;

internal record class Drink(
    [property: JsonPropertyName("idDrink")] int Id,
    [property: JsonPropertyName("strDrink")] string Name
    );

internal record class DrinksResponse(
    [property: JsonPropertyName("drinks")] IEnumerable<Drink> drinks
    );