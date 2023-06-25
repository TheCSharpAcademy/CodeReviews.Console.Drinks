using System.Text.Json.Serialization;
namespace LONCHANICK.DrinksApp.Models;

public class ListOfCategories
{
	[property: JsonPropertyName("drinks")]
	public List<Category>? DrinksCategories { get; set; }

	public override string ToString()
	{
		string content = string.Empty;
		if (DrinksCategories != null)
		{
			foreach (var drink in DrinksCategories)
				content += " " + drink.strCategory + "\n";
		}
		return content;
	}
	public bool Contains(string drink = "")
	{
		string aux = string.Empty;
		if (DrinksCategories != null)
		{
			foreach (var category in DrinksCategories)
			{
				aux = category.strCategory.ToLower();
				drink = drink.ToLower().Trim();
				if (aux.Equals(drink))
					return true;
			}
		}
		return false;
	}
}


public class Category
{
	public string strCategory { get; set; }
}
