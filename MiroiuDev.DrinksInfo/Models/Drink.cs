using Newtonsoft.Json;

namespace MiroiuDev.DrinksInfo.Models;
public class Drink
{
    [JsonProperty("idDrink")]
    public string Id { get; set; } = "";

    [JsonProperty("strDrink")]
    public string Name { get; set; } = "";

    [JsonProperty("strCategory")]
    public string Category { get; set; } = "";

    [JsonProperty("strAlcoholic")]
    public string Alcoholic { get; set; } = "";

    [JsonProperty("strInstructions")]
    public string Instructions { get; set; } = "";
}
