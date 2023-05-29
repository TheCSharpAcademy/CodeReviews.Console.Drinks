using Newtonsoft.Json;

namespace DrinksLibrary.Models;
public class DrinkCategoriesModel
{
    [JsonProperty("drinks")]
    public List<DrinkCategoryModel> CategoriesList { get; internal set; }
}
