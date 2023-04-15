using sadklouds.Drinks.Models;
using System.Net.Http.Json;
using System.Reflection;
using System.Web;

namespace sadklouds.Drinks;

public class DrinksService
{
    private HttpClient client = new();
    public List<Category> GetCategories()
    {
        List<Category> categories = new();

        var request = new HttpRequestMessage(HttpMethod.Get, "http://www.thecocktaildb.com/api/json/v1/1/list.php?c=list");

        HttpResponseMessage response = client.SendAsync(request).Result;
        if (response.IsSuccessStatusCode)
        {
            var result = response.Content.ReadFromJsonAsync<Categories>().Result;
            categories = result.CategoryList;
            VisualEngine.ShowTable(categories, "Categories Name");
            return categories;
        }
        return categories;

    }

    public List<DrinkModel> GetDrinksByCategory(string category)
    {
        List<DrinkModel> drinks = new();
        var request = new HttpRequestMessage(HttpMethod.Get, $"https://www.thecocktaildb.com/api/json/v1/1/filter.php?c={HttpUtility.UrlEncode(category)}");
        HttpResponseMessage response = client.SendAsync(request).Result;
        if (response.IsSuccessStatusCode)
        {
            var result = response.Content.ReadFromJsonAsync<DrinksModel>().Result;
            drinks = result.DrinksList;
            VisualEngine.ShowTable(drinks, "Drinks Menu");
            return drinks;
        }
        return drinks;
    }

    public void GetDrink(string id)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, $"https://www.thecocktaildb.com/api/json/v1/1/lookup.php?i={HttpUtility.UrlEncode(id)}");
        HttpResponseMessage response = client.SendAsync(request).Result;
        if (response.IsSuccessStatusCode)
        {
            var result = response.Content.ReadFromJsonAsync<DrinkDetailObject>().Result;
            var returnedList = result.DrinkDetailList;
            DrinkDetailModel drinkDetail = returnedList[0];

            List<object> prepList = new();

            string formattedName = "";

            foreach (PropertyInfo prop in drinkDetail.GetType().GetProperties())
            {

                if (prop.Name.Contains("str"))
                {
                    formattedName = prop.Name.Substring(3);
                }

                if (!string.IsNullOrEmpty(prop.GetValue(drinkDetail)?.ToString()))
                {
                    prepList.Add(new
                    {
                        Key = formattedName,
                        Value = prop.GetValue(drinkDetail)
                    });
                }
            }

            VisualEngine.ShowTable(prepList, drinkDetail.strDrink);

        }
    }

}