using HttpRequests.Models;
using System.Collections.Specialized;
using System.Configuration;
using System.Net.Http.Headers;
using System.Text.Json;
namespace HttpRequests.Services;

public class DrinkService
{
	private readonly HttpClient _httpClient = new HttpClient();
	NameValueCollection _uri = ConfigurationManager.AppSettings;

	public DrinkService()
	{
		_httpClient.DefaultRequestHeaders.Accept.Clear();
		_httpClient.DefaultRequestHeaders.Accept.Add(
		new MediaTypeWithQualityHeaderValue("application/json"));
	}

	public async Task<List<Drink>>? GetCategoriesAsync()
	{
		var apiResponse = await _httpClient.GetAsync(_uri.Get("Categories"));
		var jsonResponse = await apiResponse.Content.ReadAsStringAsync();
		var root = JsonSerializer.Deserialize<Repositories.Repositories.Root>(jsonResponse);
		List<Drink> categories = new List<Drink>();

		foreach (var item in root.drinks)
		{
			categories.Add(new Drink() { Category = item.strCategory });
		}

		return categories;
	}

	public async Task<List<Drink>> GetDrinksAsync(string? category)
	{
		var apiResponse = await _httpClient.GetAsync(_uri.Get("Drinks") + category);
		var jsonResponse = await apiResponse.Content.ReadAsStringAsync();
		var root = JsonSerializer.Deserialize<Repositories.Repositories.Root>(jsonResponse);
		var drinks = new List<Drink>();

		foreach (var item in root.drinks)
		{
			drinks.Add(new Drink() { DrinkName = item.strDrink, IdDrink = item.idDrink });
		}

		return drinks;
	}

	internal async Task<Drink>? GetDrinkDetailsAsync(string? drinkId)
	{
		var apiResponse = await _httpClient.GetAsync(_uri.Get("Details") + drinkId);
		apiResponse.EnsureSuccessStatusCode();
		var jsonResponse = await apiResponse.Content.ReadAsStringAsync();
		var root = JsonSerializer.Deserialize<Repositories.Repositories.Root>(jsonResponse);

		var drink = new Drink()
		{
			DrinkName = root.drinks[0].strDrink,
			IdDrink = root.drinks[0].idDrink,
			Alcoholic = root.drinks[0].strAlcoholic,
			Glass = root.drinks[0].strGlass,
			Instructions = root.drinks[0].strInstructions,
			Ingredient1 = root.drinks[0].strIngredient1,
			Ingredient2 = root.drinks[0].strIngredient2,
			Ingredient3 = root.drinks[0].strIngredient3,
			Ingredient4 = root.drinks[0].strIngredient4,
			Ingredient5 = root.drinks[0].strIngredient5,
			Ingredient6 = root.drinks[0].strIngredient6,
			Ingredient7 = root.drinks[0].strIngredient7,
			Ingredient8 = root.drinks[0].strIngredient8,
			Ingredient9 = root.drinks[0].strIngredient9,
			Ingredient10 = root.drinks[0].strIngredient10,
			Ingredient11 = root.drinks[0].strIngredient11,
			Ingredient12 = root.drinks[0].strIngredient12,
			Ingredient13 = root.drinks[0].strIngredient13,
			Ingredient14 = root.drinks[0].strIngredient14,
			Ingredient15 = root.drinks[0].strIngredient15,
			Measure1 = root.drinks[0].strMeasure1,
			Measure2 = root.drinks[0].strMeasure2,
			Measure3 = root.drinks[0].strMeasure3,
			Measure4 = root.drinks[0].strMeasure4,
			Measure5 = root.drinks[0].strMeasure5,
			Measure6 = root.drinks[0].strMeasure6,
			Measure7 = root.drinks[0].strMeasure7,
			Measure8 = root.drinks[0].strMeasure8,
			Measure9 = root.drinks[0].strMeasure9,
			Measure10 = root.drinks[0].strMeasure10,
			Measure11 = root.drinks[0].strMeasure11,
			Measure12 = root.drinks[0].strMeasure12,
			Measure13 = root.drinks[0].strMeasure13,
			Measure14 = root.drinks[0].strMeasure14,
			Measure15 = root.drinks[0].strMeasure15,
		};

		return drink;
	}
}
