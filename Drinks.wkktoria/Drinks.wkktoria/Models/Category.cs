using Newtonsoft.Json;

namespace Drinks.wkktoria.Models;

internal class Category
{
    public string? StrCategory { get; set; }
}

internal class Categories
{
    [JsonProperty("drinks")] public List<Category>? CategoriesList { get; set; }
}