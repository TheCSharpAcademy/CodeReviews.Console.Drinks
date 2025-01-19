using Newtonsoft.Json;

namespace DrinksInfo.Models
{
    internal class Category
    {
        public string strCategory {  get; set; }
    }

    internal class Categories
    {
        [JsonProperty("drinks")]
        public List<Category> CategoriesList { get; set; }
    }
}
