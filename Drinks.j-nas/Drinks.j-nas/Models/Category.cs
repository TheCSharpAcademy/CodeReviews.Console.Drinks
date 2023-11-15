using Newtonsoft.Json;

namespace Drinks.j_nas.Models
{
    public class Category
    {
        [JsonProperty("strCategory")]
        public string StrCategory { get; set; }
    }

    public class Categories
    {
        [JsonProperty("drinks")]
        public List<Category>? CategoriesList { get; set; }
    }
}
