namespace TheCocktailDb;

using System.Text.Json.Serialization;

public record class LookupDrinksResponse(
    [property: JsonPropertyName("drinks")] List<DrinkDetail> Drinks);