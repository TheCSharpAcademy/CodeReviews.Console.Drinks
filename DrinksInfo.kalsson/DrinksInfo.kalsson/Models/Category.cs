using Newtonsoft.Json;

namespace DrinksInfo.kalsson.Models;

public class Category
{
    /// <summary>
    /// Represents the category of a drink.
    /// </summary>
    public string strCategory { get; set; }
}

public class Categories
{
    /// <summary>
    /// Represents a list of categories for drinks.
    /// </summary>
    [JsonProperty("drinks")]
    public List<Category> CategoriesList { get; set; }
}