using DrinksInfoCarDioLogics.Models;
using Newtonsoft.Json;
using RestSharp;
using System.Reflection;
using System.Web;

namespace DrinksInfoCarDioLogics;

public class DrinkService
{
    tableDisplay td = new tableDisplay();

    public void GetCategories()
    {
        var client = new RestClient("http://www.thecocktaildb.com/api/json/v1/1/");
        var request = new RestRequest("list.php?c=list");
        var response = client.ExecuteAsync(request);

        if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
        {
            string rawResponse = response.Result.Content;
            var serialize = JsonConvert.DeserializeObject<Categories>(rawResponse);
            List<Category> returnedList = serialize.CategoriesList;
            td.ShowTable(returnedList, "Categories Menu");
        }
    }

    public bool GetDrinksByCategories(string categoryChosen)
    {
        var client = new RestClient("http://www.thecocktaildb.com/api/json/v1/1/");
        var request = new RestRequest($"filter.php?c={HttpUtility.UrlEncode(categoryChosen)}");
        var response = client.ExecuteAsync(request);

        if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
        {
            string rawResponse = response.Result.Content;
            var serialize = JsonConvert.DeserializeObject<Drinks>(rawResponse);

            if (serialize != null)
            {
                List<Drink> returnedList = serialize.DrinksList;
                td.ShowTable(returnedList, "Drinks Menu");
                return false;
            }
            else if (serialize == null)
            {
                Console.WriteLine("Invalid category!");
                Console.ReadLine();
                return true;
            }
        }

        return true;
    }

    public bool GetDrinks(string drink)
    {
        var client = new RestClient("http://www.thecocktaildb.com/api/json/v1/1/");
        var request = new RestRequest($"lookup.php?i={drink}");
        var response = client.ExecuteAsync(request);

        if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
        {
            string rawResponse = response.Result.Content;
            var serialize = JsonConvert.DeserializeObject<DrinkDetailObject>(rawResponse);
            List<DrinkDetail> returnedList = serialize.DrinkDetailList;

            if (returnedList != null)
            {
                DrinkDetail drinkDetail = returnedList[0];
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

                td.ShowTable(prepList, drinkDetail.StrDrink);
                return false;
            }
            else if (returnedList == null)
            {
                Console.WriteLine("Invalid drink name!");
                Console.ReadLine();
                return true;
            }
        }
        return true;
    } 
}
