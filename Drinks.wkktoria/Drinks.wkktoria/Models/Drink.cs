using Newtonsoft.Json;

namespace Drinks.wkktoria.Models;

internal class Drink
{
    public string? IdDrink { get; set; }
    public string StrDrink { get; set; } = null!;
}

internal class Drinks
{
    [JsonProperty("drinks")] public List<Drink>? DrinksList { get; set; }
}