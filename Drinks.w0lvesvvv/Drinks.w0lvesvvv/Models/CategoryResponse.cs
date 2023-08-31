using Newtonsoft.Json;

namespace Drinks.w0lvesvvv.Models
{
    public class CategoryResponse
    {
        [JsonProperty("drinks")]
        public List<Category>? ListCategories { get; set; }
    }

    public class Category
    {
        [JsonProperty("strCategory")]
        public string? Category_name { get; set; }
    }

}
