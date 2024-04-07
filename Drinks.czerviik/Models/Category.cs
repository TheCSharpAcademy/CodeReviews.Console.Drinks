using Newtonsoft.Json;

namespace drinks_info
{
    public class Category : IModelEntity
    {
        [JsonProperty("strCategory")]
        public string Name { get; set; }
    }

    public class Categories
    {
        [JsonProperty("drinks")]
        public List<Category> CategoriesList { get; set; }
    }
}