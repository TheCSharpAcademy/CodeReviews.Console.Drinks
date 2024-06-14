using Newtonsoft.Json;

public record DrinksCategory([property: JsonProperty("strCategory")] string Category)
{
    public override string ToString()
    {
        return $"{Category}";
    }
}

public record DrinkCategories([property: JsonProperty("drinks")] List<DrinksCategory> Categories);
