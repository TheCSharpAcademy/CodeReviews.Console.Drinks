using Newtonsoft.Json;

public record class DrinkCategories(
    [property: JsonProperty("drinks")] List<DrinkCategory> Categories
    );
