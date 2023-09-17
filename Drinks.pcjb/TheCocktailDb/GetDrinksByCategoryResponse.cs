namespace TheCocktailDb;

using System.Text.Json.Serialization;

public record class GetDrinksByCategoryResponse(
    [property: JsonPropertyName("drinks")] List<Drink> Drinks);