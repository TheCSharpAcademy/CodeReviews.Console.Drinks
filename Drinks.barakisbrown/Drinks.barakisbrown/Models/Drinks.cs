namespace Drinks.barakisbrown.Models;

using Newtonsoft.Json;

public class Drink
{
    public Drink()
    {
        
    }

    [JsonProperty("idDrink")]
    public string? IdDrink { get; set; }
    [JsonProperty("strDrink")]
    public string? StrDrink { get; set; }

    public override string ToString()
    {
        return $"{StrDrink}";
    }
}

public class Drinks
{
    [JsonProperty("drinks")]
    public List<Drink>? DrinksList { get; set; }
}
