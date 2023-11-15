using Newtonsoft.Json;

namespace Drinks_Info.Models
{
	internal class Category
	{
        public string strCategory { get; set; }
    }

	internal class Categories
	{
        [JsonProperty("drinks")]
        public List<Category> CategoriesList { get; set; }
    }
}
