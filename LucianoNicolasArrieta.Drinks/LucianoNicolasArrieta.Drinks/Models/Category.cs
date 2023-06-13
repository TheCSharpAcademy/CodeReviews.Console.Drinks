using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace LucianoNicolasArrieta.DrinksApp.Models
{
    public class Category
    {
        public string strCategory { get; set; }
    }

    public class Categories
    {
        [JsonProperty("drinks")]
        public List<Category> CategoriesList { get; set; }
    }
}
