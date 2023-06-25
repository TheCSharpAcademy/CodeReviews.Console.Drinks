using LONCHANICK.DrinksApp.Models;
using System.Text.Json;

namespace LONCHANICK.DrinksApp.Request;

public static class DrinksRequest
{
	static public async Task<ListOfCategories> GetDrinkCategories()
	{
		string drinkCategoriesUrl = "https://www.thecocktaildb.com/api/json/v1/1/list.php?c=list";

		using HttpClient client = new HttpClient();

		using var drinkCategoriesStream = await client.GetStreamAsync(drinkCategoriesUrl);

		var drinkCategories = await JsonSerializer
			.DeserializeAsync<ListOfCategories>(drinkCategoriesStream);

		return drinkCategories;
	}

	public static async Task<Drinks> GetDrinksByCategory(string category)
	{
		string drinkCategoryUrl =
			"https://www.thecocktaildb.com/api/json/v1/1/filter.php?c=" + category;

		using HttpClient client = new HttpClient();

		using var steamDrinksByCategory = await client.GetStreamAsync(drinkCategoryUrl);

		var drinkByCategories = await JsonSerializer
			.DeserializeAsync<Drinks>(steamDrinksByCategory);

		return drinkByCategories;
	}

	public static async Task<FullPropertiesDrinkModel> GetDrinksById(string category)
	{
		string drinkCategoryUrl =
			"https://www.thecocktaildb.com/api/json/v1/1/lookup.php?i=" + category;

		using HttpClient client = new HttpClient();

		using var drinkById = await client.GetStreamAsync(drinkCategoryUrl);

		var drinksResult = await JsonSerializer
			.DeserializeAsync<FullPropertiesDrinkModel>(drinkById);

		return drinksResult;
	}

}
