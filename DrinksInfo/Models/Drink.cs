using Newtonsoft.Json;

public record Drink([property: JsonProperty("strDrink")] string Name, [property: JsonProperty("strDrinkThumb")] string Thumbnail, [property: JsonProperty("idDrink")][property: JsonConverter(typeof(StringToIntConverter))] int Id);

public record DrinksResponse([property: JsonProperty("drinks")] List<Drink> Drinks);
