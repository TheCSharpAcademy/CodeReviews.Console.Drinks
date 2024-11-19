using System.Reflection;
using System.Web;
using DrinksInfo.Models;
using Newtonsoft.Json;
using RestSharp;

namespace DrinksInfo
{
    public class DrinksService
    {
        public async Task GetCategories()
        {
            var client = new RestClient("https://www.thecocktaildb.com/api/json/v1/1/");
            var request = new RestRequest("list.php?c=list");
            var response = client.ExecuteAsync(request);

            if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string rawResponse = response.Result.Content;

                var serialize = JsonConvert.DeserializeObject<Categories>(rawResponse);

                List<Category> returnedList = serialize.CategoriesList;

                TableVisualisationEngine.ShowTable(returnedList, "Categories Menu");
            }
        }

        public async Task GetDrinksByCategory(string category)
        {
            var client = new RestClient("https://www.thecocktaildb.com/api/json/v1/1/");
            var request = new RestRequest($"filter.php?c={HttpUtility.UrlEncode(category)}");
            var response = client.ExecuteAsync(request);

            if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string rawResponse = response.Result.Content;

                var serialize = JsonConvert.DeserializeObject<Drinks>(rawResponse);

                List<Drink> returnedList = serialize.DrinksList;

                TableVisualisationEngine.ShowTable(returnedList, "Drinks menu");
            }
        }

         internal async Task GetDrink(string drink)
         {
            var client = new RestClient("http://www.thecocktaildb.com/api/json/v1/1/");
            var request = new RestRequest($"lookup.php?i={drink}");
            var response = client.ExecuteAsync(request);

            if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string rawResponse = response.Result.Content;

                var serialize = JsonConvert.DeserializeObject<DrinkDetailObject>(rawResponse);

                List<DrinkDetail> returnedList = serialize.DrinkDetailList;

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

                TableVisualisationEngine.ShowTable(prepList, drinkDetail.strDrink);


            }
         }

         public async Task<List<Category>> GetCategoriesList()
         {
             var client = new RestClient("https://www.thecocktaildb.com/api/json/v1/1/");
             var request = new RestRequest("list.php?c=list");
             var response = client.ExecuteAsync(request);

             List<Category> categories = new();
             if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
             {
                 string rawResponse = response.Result.Content;
                 var serialize = JsonConvert.DeserializeObject<Categories>(rawResponse);
                 categories = serialize.CategoriesList;
                 return categories;
             }

             return categories;
         }

         public async Task<List<Drink>> GetDrinksList(string drink)
         {
            var client = new RestClient("http://www.thecocktaildb.com/api/json/v1/1/");
            var request = new RestRequest($"lookup.php?i={drink}");
            var response = client.ExecuteAsync(request);

            List<Drink> categories = new();
             if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
             {
                 string rawResponse = response.Result.Content;
                 var serialize = JsonConvert.DeserializeObject<Drinks>(rawResponse);
                 categories = serialize.DrinksList;
                 return categories;
             }

             return categories;
         }


    }
}
