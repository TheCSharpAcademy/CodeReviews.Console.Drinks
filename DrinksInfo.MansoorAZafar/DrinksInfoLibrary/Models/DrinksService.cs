using RestSharp;
using Newtonsoft.Json;
using DrinksInfoLibrary.View;
using System.Reflection;

namespace DrinksInfoLibrary.Models;
internal class DrinksService
{
	public List<Category> GetCategories()
	{
		//Create an instance of the request
		 var client = new RestClient("http://www.thecocktaildb.com/api/json/v1/1/");	
		//Run an async request
		var request = new RestRequest("list.php?c=list");
		var response = client.ExecuteAsync(request);
		List<Category> categories = new();

		if(response.Result.StatusCode == System.Net.HttpStatusCode.OK)
		{
			string rawResponse = response.Result.Content;
			var serialize = JsonConvert.DeserializeObject<Categories>(rawResponse);
			
			categories = serialize.CategoriesList;
			TableVisualisationEngine.ShowTable(categories, "Categories Menu");
		}	

		return categories;
	}
	
	public List<Drink> GetDrinksByCategory(string category)
	{
		//Create an instance of the request
		 var client = new RestClient("http://www.thecocktaildb.com/api/json/v1/1/");	
		//Run an async request
		var request = new RestRequest($"filter.php?c={System.Web.HttpUtility.UrlEncode(category)}");
		var response = client.ExecuteAsync(request);
		List<Drink> drinks = new();

		if(response.Result.StatusCode == System.Net.HttpStatusCode.OK)
		{
			string rawResponse = response.Result.Content;
			var serialize = JsonConvert.DeserializeObject<Drinks>(rawResponse);
			
			drinks = serialize.DrinksList;
			TableVisualisationEngine.ShowTable(drinks, "Drinks Menu");
		}	
		return drinks;
	}
	
	public void GetDrink(string drink)
	{
		//Create an instance of the request
		var client = new RestClient("http://www.thecocktaildb.com/api/json/v1/1/");	
		var request = new RestRequest($"lookup.php?i={drink}");
		var response = client.ExecuteAsync(request);

		if(response.Result.StatusCode == System.Net.HttpStatusCode.OK)
		{
			string rawResponse = response.Result.Content;
			var serialize = JsonConvert.DeserializeObject<DrinkDetailObject>(rawResponse);
			
			List<DrinkDetail> returnedList = serialize.DrinkDetailList;
			
			DrinkDetail drinkDetail = returnedList[0];
			List<object> prepList = new(); // to make the properties look nicer and not have 'str' infront of them
			
			string formattedName = "";
			//Loop through every property in the object
			foreach(PropertyInfo prop in drinkDetail.GetType().GetProperties())
			{
				if(prop.Name.Contains("str")) formattedName = prop.Name.Substring(3);
				if(!string.IsNullOrEmpty(prop.GetValue(drinkDetail)?.ToString()))
				{
					prepList.Add(new 
					{
						Key = formattedName,
						Value = prop.GetValue(drinkDetail)		
					});
				}
			}

			TableVisualisationEngine.ShowTable(prepList, drinkDetail.StrDrink );
		}	
	}
}	
