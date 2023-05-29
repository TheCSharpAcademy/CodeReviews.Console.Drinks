using Newtonsoft.Json;

namespace DrinksLibrary.Models;
public class DrinkCategories
{
    [JsonProperty("drinks")]
    public List<DrinkCategory> CategoriesList { get; internal set; }
}
