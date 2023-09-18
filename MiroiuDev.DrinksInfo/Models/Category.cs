using Newtonsoft.Json;

namespace MiroiuDev.DrinksInfo.Models;

internal class Category
{
    [JsonProperty("strCategory")]
    internal string Name { get; set; } = "";
}