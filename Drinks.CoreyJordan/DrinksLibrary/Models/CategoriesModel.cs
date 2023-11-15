using Newtonsoft.Json;

namespace DrinksLibrary.Models;
public class CategoriesModel
{
    [JsonProperty("drinks")]
    public List<CategoryModel> CategoriesList { get; internal set; } = new List<CategoryModel>();
}
