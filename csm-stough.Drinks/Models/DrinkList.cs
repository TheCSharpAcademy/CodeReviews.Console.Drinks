using Newtonsoft.Json;

public record DrinkList(
    [property: JsonProperty("drinks")] List<Drink> Drinks
);
