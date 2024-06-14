using Newtonsoft.Json;

public record Drink([property: JsonProperty("strDrink")] string Name, [property: JsonProperty("strDrinkThumb")] string Thumbnail, [property: JsonProperty("idDrink")][property: JsonConverter(typeof(JsonConverter))] int Id)
{
    public override string ToString()
    {
        return Name;
    }
}

public record DrinksResponse([property: JsonProperty("drinks")] List<Drink> Drinks);
