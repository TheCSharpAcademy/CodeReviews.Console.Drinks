namespace Drinks.barakisbrown.Models;

using Newtonsoft.Json;

public class Category
{
	public Category()
	{
	}

	public string strCategory { get; set; }
}

public class Categories
{
	[JsonProperty("drinks")]
	public List<Category> CategoriesList { get; set; }
}

