using Newtonsoft.Json;

namespace DrinksProject.Models
{
    public class Category
    {
        [JsonProperty("strCategory")]
        public string StrCategory { get; set; }
    }

    public class Categories
    {
        [JsonProperty("drinks")]
        public List<Category> CategoriesList { get; set; }
    }

}
