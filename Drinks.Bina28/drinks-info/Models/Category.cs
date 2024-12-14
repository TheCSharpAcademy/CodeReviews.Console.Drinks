using Newtonsoft.Json;

namespace Drinks.Bina28.drinks_info.Models
{
	public class Category
	{
		public string strCategory { get; set; }
	}

	public class Categories
	{
		[JsonProperty("drinks")]
		public List<Category> CategoriesList{ get; set; }
	}
}
