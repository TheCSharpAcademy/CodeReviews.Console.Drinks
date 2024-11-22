using System.ComponentModel;
using System.Reflection;
using System.Web;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using RestSharp;

public class DrinksService {

    public void GetCategories() {
        var client = new RestClient("http://www.thecocktaildb.com/api/json/v1/1/");
        var request = new RestRequest("list.php?c=list");
        var response = client.ExecuteAsync(request);

        if (response.Result.StatusCode == System.Net.HttpStatusCode.OK) {
            string rawResponse = response.Result.Content;
            var serialize = JsonConvert.DeserializeObject<Categories>(rawResponse);

            List<Category> returnedList = serialize.CategoriesList;

            TableVisualisationEngine.ShowTable(returnedList, "Categories Menu");
            
        }
    }


        public void GetDrinksByCategory(string category) {
        var client = new RestClient("http://www.thecocktaildb.com/api/json/v1/1/");
        var request = new RestRequest($"filter.php?c={HttpUtility.UrlEncode(category)}");
        var response = client.ExecuteAsync(request);

        if (response.Result.StatusCode == System.Net.HttpStatusCode.OK) {
            string rawResponse = response.Result.Content;
            var serialize = JsonConvert.DeserializeObject<Drinks>(rawResponse);

            // serialize.DrinksList SETS the DrinksList property with the deserialized JSON data.
            List<Drink> returnedList = serialize.DrinksList;

            TableVisualisationEngine.ShowTable(returnedList, "Drinks Menu");
            
        }
    }

    internal void GetDrink(string drink)
    {
        var client = new RestClient("http://www.thecocktaildb.com/api/json/v1/1/");
        var request = new RestRequest($"lookup.php?i={drink}");
        var response = client.ExecuteAsync(request);

        if (response.Result.StatusCode == System.Net.HttpStatusCode.OK) {
            string rawResponse = response.Result.Content;

            var serialize = JsonConvert.DeserializeObject<DrinkDetailObject>(rawResponse);

            List<DrinkDetail> returnedList = serialize.DrinkDetailList;

            DrinkDetail drinkDetail = returnedList[0];

            List<object> prepList = new();

            string formattedName = "";

            foreach (PropertyInfo prop in drinkDetail.GetType().GetProperties()) {
                if (prop.Name.Contains("str")) {
                    formattedName = prop.Name.Substring(3);
                }

                if (!string.IsNullOrEmpty(prop.GetValue(drinkDetail)?.ToString())) {
                    prepList.Add (new {
                        Key = formattedName,
                        Value = prop.GetValue(drinkDetail)
                    });
                }
            }

            TableVisualisationEngine.ShowTable(prepList, drinkDetail.strDrink);
        }
    }
}

// Youtube 13:43