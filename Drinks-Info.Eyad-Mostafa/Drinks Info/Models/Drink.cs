using Newtonsoft.Json;

namespace Drinks_Info.Models;

internal class Drink
{

    [JsonProperty("strDrink")]
    public string? Name { get; init; }

    [JsonProperty("idDrink")]
    public string? Id { get; init; }

}

class DrinkResponse
{
    [JsonProperty("drinks")]
    public List<Drink>? Drinks { get; init; }
}
