using Newtonsoft.Json;

namespace kmakai.Drinks.Models;

public class DrinksCategoryList
{
    [JsonProperty("drinks")]
    public List<Category> Categories { get; set; }
};
public class Category
{
    [JsonProperty("strCategory")]
    public string Name { get; set; }
}