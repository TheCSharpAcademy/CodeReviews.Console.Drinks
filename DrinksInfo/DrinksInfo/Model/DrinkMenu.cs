using System.Text.Json.Serialization;

namespace DrinksInfo.Model;

internal record class DrinkMenu([property: JsonPropertyName("drinks")] List<DrinkMenuItem> Drinks);
