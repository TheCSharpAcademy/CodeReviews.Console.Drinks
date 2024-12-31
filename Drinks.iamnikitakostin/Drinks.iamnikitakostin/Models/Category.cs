using Newtonsoft.Json;

namespace Drinks.iamnikitakostin.Models;

public class Category
{
    public string StrCategory { get; set; }
}

public class Categories
{
    [JsonProperty("drinks")]
    public List<Category> CategoriesList { get; set; }
}