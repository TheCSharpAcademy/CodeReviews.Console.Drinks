using Newtonsoft.Json;

namespace MiroiuDev.DrinksInfo.Models;

public class Category
{
    [JsonProperty("strCategory")]
    public string Name { get; set; } = "";
}