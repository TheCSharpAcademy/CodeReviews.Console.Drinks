using System.Text.Json;
using Newtonsoft.Json;

namespace DrinksInfo
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