using Newtonsoft.Json;

namespace DrinksInfo.HopelessCoding.Models;

public class Category
{
    // strCategory from API JSON file
    public string strCategory {  get; set; }
}

public class Categories
{
    [JsonProperty("drinks")]
    public List<Category> CategoriesList { get; set; }
}