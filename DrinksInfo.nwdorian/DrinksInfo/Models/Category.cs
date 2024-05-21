using System.Text.Json.Serialization;

namespace DrinksInfo.Models;
public class Category
{
    public string strCategory { get; set; }
}

public class Categories
{
    [JsonPropertyName("drinks")]
    public List<Category> CategoriesList { get; set; }
}