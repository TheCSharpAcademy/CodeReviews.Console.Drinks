using Newtonsoft.Json;

namespace MiroiuDev.DrinksInfo.Models;
internal class Drink
{
    [JsonProperty("idDrink")]
    internal string Id { get; set; } = "";

    [JsonProperty("strDrink")]
    internal string Name { get; set; } = "";

    [JsonProperty("strCategory")]
    internal string Category { get; set; } = "";

    [JsonProperty("strAlcoholic")]
    internal string Alcoholic { get; set; } = "";

    [JsonProperty("strInstructions")]
    internal string Instructions { get; set; } = "";
}
