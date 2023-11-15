using Newtonsoft.Json;

namespace Drinks.JsPeanut
{
    class Category
    {
        public string StrCategory { get; set; }
    }

    class Categories
    {
        [JsonProperty("drinks")]
        public List<Category> CategoriesList { get; set; }
    }
}
