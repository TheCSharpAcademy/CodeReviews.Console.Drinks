using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace DrinksInfo.Models
{
  public class Category
  {
    [JsonProperty("strCategory")]
    public string Name { get; set; } = null!;
  }

  public class Categories
  {
    [JsonProperty("drinks")]
    public List<Category> CategoriesList { get; set; } = new List<Category>();
  }
}
