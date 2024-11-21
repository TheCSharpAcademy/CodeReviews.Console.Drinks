using System.ComponentModel;
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


}

// Youtube video 11:25