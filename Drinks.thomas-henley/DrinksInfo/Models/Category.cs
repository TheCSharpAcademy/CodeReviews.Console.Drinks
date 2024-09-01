using Newtonsoft.Json;

namespace DrinksInfo.Models;

public class Category
{
    [JsonProperty("strCategory")]
    public required string Name { get; set; }
}

public class Categories
{
    [JsonProperty("drinks")] public required List<Category> CategoriesList { get; set; }
}