using Newtonsoft.Json;

namespace MiroiuDev.DrinksInfo.Models;

public class Categories
{
    [JsonProperty("drinks")]
    public List<Category> CategoriesList { get; set; } = new();
}