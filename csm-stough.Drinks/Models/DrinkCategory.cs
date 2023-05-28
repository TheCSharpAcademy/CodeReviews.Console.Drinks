using Newtonsoft.Json;

public record class DrinkCategory(
    [property: JsonProperty("strCategory")] string Name
    )
{
    public override string ToString()
    {
        return Name;
    }
}