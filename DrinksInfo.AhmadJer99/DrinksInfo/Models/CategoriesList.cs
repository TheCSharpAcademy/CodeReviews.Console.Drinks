using Newtonsoft.Json;

namespace DrinksInfo.Models;

public class CategoriesList
{
    [JsonProperty("drinks")]
    public Category[]? Drinks { get; set; }
}

public class Category
{
    [JsonProperty("strCategory")]
    public string? DrinkCategoryName { get; set; }
}