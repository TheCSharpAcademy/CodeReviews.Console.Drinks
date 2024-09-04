using System.Collections.Generic;
using Newtonsoft.Json;
namespace DrinksInfoLibrary.Models;

internal class Category
{
	public string StrCategory {get; set;}
}

internal class Categories
{
	[JsonProperty("drinks")]
	internal List<Category> CategoriesList {get; set;}
}
