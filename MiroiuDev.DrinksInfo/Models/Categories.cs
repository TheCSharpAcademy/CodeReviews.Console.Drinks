using Newtonsoft.Json;

namespace MiroiuDev.DrinksInfo.Models;

internal class Categories
{
    [JsonProperty("drinks")]
    internal List<Category> CategoriesList { get; set; } = new();
}